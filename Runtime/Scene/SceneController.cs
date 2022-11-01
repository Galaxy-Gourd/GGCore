using System;
using UnityEngine.SceneManagement;

namespace GG.Core
{
    public static class SceneController
    {
        #region VARIABLES

        public static Action<int> OnSceneSwitched;
        
        private static int _activeScene;

        #endregion VARIABLES


        #region INITIALIZATION

        internal static void Init()
        {            
            SceneManager.activeSceneChanged -= OnActiveSceneChanged;
            SceneManager.activeSceneChanged += OnActiveSceneChanged;

            RefreshActiveScene();
        }

        #endregion INITIALIZATION


        #region API

        public static void SwitchScene(int scene)
        {
            SceneManager.LoadScene(scene);
            _activeScene = scene;
            OnSceneSwitched?.Invoke(_activeScene);
        }

        #endregion API


        #region SCENE

        private static void OnActiveSceneChanged(UnityEngine.SceneManagement.Scene from, UnityEngine.SceneManagement.Scene to)
        {
            RefreshActiveScene();
        }
        
        private static void RefreshActiveScene()
        {
            _activeScene = SceneManager.GetActiveScene().buildIndex;
            OnSceneSwitched?.Invoke(_activeScene);
        }
 
        #endregion SCENE
    }
}