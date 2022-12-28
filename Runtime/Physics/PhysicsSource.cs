using UnityEngine;

namespace GG.Core
{
    internal class PhysicsSource : MonoBehaviour, ITickable
    {
        #region SINGLETON

        private static PhysicsSource _instance;
        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;            
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        #endregion SINGLETON


        #region VARIABLES

        public TickGroup TickGroup => TickGroup.Physics;
        private const bool CONST_Use2D = true;

        #endregion VARIABLES


        #region INITIALIZATION

        private void OnEnable()
        {
            TickRouter.Register(this);
        }

        private void OnDisable()
        {
            TickRouter.Unregister(this);
        }

        #endregion INITIALIZATION


        #region TICK

        void ITickable.Tick(float delta)
        {
            if (CONST_Use2D)
            {
                Physics2D.Simulate(delta);
            }
            else
            {
                Physics.Simulate(delta);
            }
        }

        #endregion TICK
    }
}