using GG.Core.Core;
using UnityEngine;

namespace GG.Core.GameObjects
{
    /// <summary>
    /// This script is added to gameObjects when they are created for pooled use.
    /// Manages the gameObject lifecycle in relation to the pool ownership status.
    /// </summary>
    public class PooledInstanceGameObject : MonoBehaviour, IClientPoolable
    {
        #region VARIABLES
        
        public bool AvailableInPool { get; set; }
        
        private GameObject _go;
        private IPool _pool;
        private bool _deactivateCacheFlag;
        private bool _destroyCacheFlag;
        private bool _activateCacheFlag;
        private bool _anonymousFlag;
        
        #endregion VARIABLES


        #region LIFECYCLE
        
        private void OnEnable()
        {
            if (!_activateCacheFlag)
            {
                _pool?.ClaimInstance(this);
            }
            else
            {
                _activateCacheFlag = false;
            }
        }
        
        private void OnDisable()
        {
            if (_anonymousFlag)
            {
                _anonymousFlag = false;
                return;
            }
            
            if (!_deactivateCacheFlag)
            {
                _pool.RelinquishInstance(this);
            }
            else
            {
                _deactivateCacheFlag = false;
            }
        }
        
        /// <summary>
        /// We use "anonymous" disable to allow us to disable the gameObject without the gameobject
        /// being returned to the pool (so that other MonoBehaviour components, such as interpolators,can respond to the OnDisable event).
        /// </summary>
        internal void OnAnonymousDisable()
        {
            _anonymousFlag = true;
            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            if (!_destroyCacheFlag)
            {
                _pool.DeleteFromInstance(this);
            }
        }

        #endregion LIFECYCLE


        #region POOLING

        void IClientPoolable.OnInstanceCreated(Pool pool)
        {
            _pool = pool;
            _go = gameObject;
        }

        void IClientPoolable.Claim()
        {
            AvailableInPool = false;
            if (!_go.activeSelf)
            {
                _activateCacheFlag = true;
                _go.SetActive(true);
            }
        }

        void IClientPoolable.Relinquish()
        {
            AvailableInPool = true;
            if (_go.activeSelf)
            {
                _deactivateCacheFlag = true;
                _go.SetActive(false);
            }
        }

        void IClientPoolable.Recycle()
        {
            _deactivateCacheFlag = true;
            _activateCacheFlag = true;
            _go.SetActive(false);
            _go.SetActive(true);
        }

        void IClientPoolable.DeleteFromPool()
        {
            _destroyCacheFlag = true;
            Destroy(_go);
        }

        #endregion POOLING
    }
}