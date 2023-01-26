using UnityEngine;

namespace GG.Core
{
    public static class PhysicsController
    {
        #region INITIALIZATION

        internal static void Init()
        {
            
        }

        public static void SetPhysicsMode(bool true3Dfalse2D)
        {
            PhysicsSource.True3Dfalse2D = true3Dfalse2D;
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