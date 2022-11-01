using UnityEngine;

namespace GG.Core
{
    internal static class PhysicsController
    {
        #region INITIALIZATION

        internal static void Init()
        {
            
        }
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void CreatePhysicsSource()
        {
            GameObject physicsSource = new GameObject(AppConstants.CONST_GONamePhysicsSource);
            physicsSource.AddComponent<PhysicsSource>();
        }

        #endregion INITIALIZATION
    }
}