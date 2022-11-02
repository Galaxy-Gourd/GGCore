using System.Collections;
using UnityEngine;

namespace GG.Core
{
    /// <summary>
    /// A module defines a set of funtionality to be included in a scene. Modules are prefabs. Every scene should have in its hierarchy
    /// a ModuleLoader object, which contains a list of modules to be loaded in that scene.
    /// </summary>
    public abstract class Module : MonoBehaviour
    {
        #region VARIABLES

        [Header("Module Metadata")]
        [SerializeField] internal string ModuleName;
        [SerializeField] internal Module[] Dependencies;

        protected internal virtual bool Swappable => false;

        #endregion VARIABLES
        
        
        #region INITIALIZATION

        protected internal IEnumerator BeginLoad()
        {
            // Wait to load this module until all of its dependencies are loaded
            while (!Modules.DependenciesAreLoadedForModule(this))
            {
                yield return null;
            }
            
            yield return LoadModule();
            Modules.OnModuleLoaded(this);
        }

        protected abstract IEnumerator LoadModule();

        protected internal virtual void OnModulesLoadComplete()
        {
            
        }
        
        #endregion INITIALIZATION


        #region UTILITY

        protected internal virtual void OnSceneChanged()
        {
            
        }

        #endregion UTILITY


        #region CLEANUP

        internal void DoDestroy()
        {
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            Modules.OnModuleDestroyed(this);
            OnModuleDestroy();
        }

        protected virtual void OnModuleDestroy()
        {
            
        }

        #endregion CLEANUP
    }
}