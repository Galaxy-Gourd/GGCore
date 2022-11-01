using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GG.Core
{
    public static class Modules
    {
        #region VARIABLES

        /// <summary>
        /// The modules that are currently active
        /// </summary>
        private static readonly List<Module> _activeModules = new List<Module>();
        
        /// <summary>
        /// The list of modules that have yet to be loaded
        /// </summary>
        private static readonly Dictionary<Module, List<string>> _loadchain = new Dictionary<Module, List<string>>();

        public static Action OnModulesLoadComplete;
        private static bool _hasLoadedForCurrentScene;
        
        #endregion VARIABLES
        
        
        #region INITIALIZATION

        internal static void Init()
        {
            Reset();
            
            SceneController.OnSceneSwitched += OnSceneLoad;
        }

        #endregion INITIALIZATION


        #region SCENE LOAD

        private static void OnSceneLoad(int scene)
        {
            // Tell any existing modules about the scene change
            foreach (Module module in _activeModules)
            {
                module.OnSceneChanged();
            }
        }

        #endregion SCENE LOAD


        #region MODULES

        internal static void LoadModules(Module[] modules)
        {
            // If there are no modules, we still want to call the load complete callback
            if (modules.Length == 0)
            {
                ModulesLoadComplete();
                return;
            }
            
            // Instantiate + instant load
            foreach (Module module in modules)
            {
                // Instantiate dependencies
                if (module.Dependencies != null)
                {
                    foreach (Module dependency in module.Dependencies)
                    {
                        InstantiateModule(dependency);
                    }
                }

                InstantiateModule(module);
            }
            
            // If there are no modules to load, maybe because we tried to load one that was already loaded, we can end the load process
            if (_loadchain.Count == 0)
            {
                ModulesLoadComplete();
                return;
            }

            // Begin loading all modules in the loadchain
            foreach (KeyValuePair<Module, List<string>> module in _loadchain)
            {
                module.Key.StartCoroutine(module.Key.BeginLoad());
            }
        }
        
        private static void InstantiateModule(Module module)
        {
            // Skip if module is in the middle of initialization
            if (module == null || ModuleIsLoading(module.ModuleName))
                return;
            
            // If we're loading a module that already exists, destroy the old module before re-instantiating
            Module active = ModuleIsActive(module.ModuleName);
            if (active)
            {
                if (!active.Swappable)
                    return;
                
                Debug.Log("Replacing module: " + module.ModuleName);
                active.DoDestroyForSwap();
            }

            Module m = Object.Instantiate(module.gameObject).GetComponent<Module>();
            m.transform.name = string.Format(AppConstants.CONST_GONameModule, m.ModuleName);

            // Core modules should NOT be destroyed across scene changes
            if (m is CoreModule)
            {
                Object.DontDestroyOnLoad(m.gameObject);
            }
            
            AddModuleToLoadchain(m);
        }

        private static void AddModuleToLoadchain(Module module)
        {
            List<string> dependencies = new List<string>();
            foreach (Module dependency in module.Dependencies)
            {
                // If the given dependency is not yet active, this module must wait until it has finished loading to load itself
                if (!ModuleIsActive(dependency.ModuleName))
                {
                    dependencies.Add(dependency.ModuleName);
                }
            }
            
            _loadchain.Add(module, dependencies);
        }

        internal static bool DependenciesAreLoadedForModule(Module module)
        {
            // The module can be loaded if all of its dependencies have finished loading
            return _loadchain[module].Count == 0;
        }

        /// <summary>
        /// We receive a callback from individual modules after they are finished loading
        /// </summary>
        internal static void OnModuleLoaded(Module module)
        {
            _loadchain.Remove(module);
            _activeModules.Add(module);
            Debug.Log("Module loaded: " + module.ModuleName);
            
            // Have we finished loading all modules?
            if (_loadchain.Count == 0)
            {
                ModulesLoadComplete();
            }
            else
            {
                // If there are still modules loading, we inform them that this module just finished loading
                foreach (KeyValuePair<Module, List<string>> loadWaiting in _loadchain)
                {
                    if (loadWaiting.Value.Contains(module.ModuleName))
                    {
                        loadWaiting.Value.Remove(module.ModuleName);
                    }
                }
            }
        }

        private static void ModulesLoadComplete()
        {
            foreach (Module m in _activeModules)
            {
                m.OnModulesLoadComplete();
            }
            OnModulesLoadComplete?.Invoke();
            _hasLoadedForCurrentScene = true;
        }

        internal static void OnModuleDestroyed(Module m)
        {
            _activeModules.Remove(m);
        }

        #endregion MODULES


        #region API

        /// <summary>
        /// Allows external classes to subscribe to know when the modules have finished loading
        /// </summary>
        /// <param name="callback"></param>
        public static void SubscribeToLoadComplete(Action callback)
        {
            OnModulesLoadComplete += callback;
            
            // Callback immeidately if the modules have already finished loading
            if (_hasLoadedForCurrentScene)
            {
                callback.Invoke();
            }
        }

        /// <summary>
        /// Returns the first active instance of the module by module type
        /// </summary>
        /// <typeparam name="T">The type of the module</typeparam>
        public static T Get<T>() where T : Module
        {
            Module module = null;
            foreach (Module thisModule in _activeModules)
            {
                if (thisModule.GetType() == typeof(T))
                {
                    module = thisModule;
                    break;
                }
            }

            return module as T;
        }

        #endregion API
        
        
        #region UTILITY

        private static Module ModuleIsActive(string modName)
        {
            foreach (Module thisModule in _activeModules)
            {
                if (thisModule.ModuleName == modName)
                {
                    return thisModule;
                }
            }

            return null;
        }
        
        private static bool ModuleIsLoading(string modName)
        {
            foreach (KeyValuePair<Module, List<string>> thisModule in _loadchain)
            {
                if (thisModule.Key.ModuleName == modName)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion UTILITY


        #region RESET

        /// <summary>
        /// Static classes must manually reset their state to allow for faster enter play mode options
        /// </summary>
        private static void Reset()
        {
            SceneController.OnSceneSwitched -= OnSceneLoad;
            _activeModules.Clear();
            _loadchain.Clear();
            _hasLoadedForCurrentScene = false;
        }

        #endregion RESET
    }
}