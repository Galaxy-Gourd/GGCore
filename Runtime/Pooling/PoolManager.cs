using System.Collections.Generic;
using GG.Core.Classes;
using GG.Core.Core;
using GG.Core.Data;
using GG.Core.GameObjects;
using UnityEngine;

namespace GG.Core
{
    /// <summary>
    /// Controls runtime instantiation of pooled objects.
    /// </summary>
    public static class PoolManager
    {
        #region VARIABLES

        /// <summary>
        /// List of our current gameObject pools
        /// </summary>
        private static readonly List<PoolGameObject> _gameObjectPools = new List<PoolGameObject>();

        /// <summary>
        /// 
        /// </summary>
        private static readonly List<IPoolClass> _classPools = new List<IPoolClass>();

        #endregion VARIABLES


        #region GAMEOBJECTS
        
        public static GameObject Pooled(
            DataConfigPool data, 
            Vector3 p, 
            Quaternion r,
            bool updatePoolProperties = false)
        {
            if (updatePoolProperties)
            {
                GetAndSetPoolData(data);
            }
            
            return Pooled(data.PoolObject, p, r);
        }

        public static GameObject Pooled(
            GameObject go, 
            Transform t,
            bool resetLocalValues = true)
        {
            GameObject g = Pooled(go);
            g.transform.SetParent(t);

            if (resetLocalValues)
            {
                g.transform.localPosition = Vector3.zero;
                g.transform.localEulerAngles = Vector3.zero;
                g.transform.localScale = Vector3.one;
            }
            
            g.SetActive(true);
            
            return g;
        }
        
        public static GameObject Pooled(
            DataConfigPool data, 
            Transform t,
            bool updatePoolProperties = true)
        {
            if (updatePoolProperties)
            {
                GetAndSetPoolData(data);
            }
            
            return Pooled(data.PoolObject, t);
        }
        
        public static GameObject Pooled(
            GameObject go, 
            Vector3 p, 
            Quaternion r)
        {
            GameObject g = Pooled(go);
            g.transform.SetPositionAndRotation(p, r);
            g.SetActive(true);
            
            return g;
        }

        /// <summary>
        /// Returns the next available pooled gameObject.
        /// </summary>
        public static GameObject Pooled(GameObject go)
        {
            // Find the pool for the associated gameObject
            IPool targetPool = GetPoolForObject(go);

            // Return next pooled item
            PooledInstanceGameObject g = targetPool.GetNext() as PooledInstanceGameObject;
            g.OnAnonymousDisable();
            return g.gameObject;
        }
        
        public static T PooledMonoBehavior<T> (GameObject go, bool createIfNotFound = true)
            where T : Component
        {
            if (go.GetComponent<T>() == null)
            {
                Debug.LogError("POOL ERROR: Component not found on target GameObject!");
                return null;
            }
            
            return GetPoolForObject(go, createIfNotFound).GetNext() as T;
        }
        
        public static T PooledMonoBehavior<T> (GameObject go, Transform parent, bool createIfNotFound = true)
            where T : Component
        {
            if (go.GetComponent<T>() == null)
            {
                Debug.LogError("POOL ERROR: Component not found on target GameObject!");
                return null;
            }

            PooledInstanceGameObject g = GetPoolForObject(go, createIfNotFound).GetNext() as PooledInstanceGameObject;
            g.transform.SetParent(parent);
            return g.GetComponent<T>();
        }
        
        #endregion GAMEOBJECTS


        #region CLASSES

        public static T Pooled<T> (bool createIfNotFound = true)
            where T : class, IPooledInstanceClass, new()
        {
            return GetClassPool<T>().GetNext() as T;
        }

        public static void RelinquishAll<T>()
            where T : class, IPooledInstanceClass, new()
        {
            PoolClass<T> pool = GetClassPool<T>(false);
            ((IPool)pool)?.RelinquishAll();
        }
        
        private static PoolClass<T> GetClassPool<T> (bool createIfNotFound = true)
            where T : class, IPooledInstanceClass, new()
        {
            // Find the pool for the associated data type
            PoolClass<T> result = null;
            foreach (IPoolClass pool in _classPools)
            {
                // Try and match data types
                if (pool.GetClassType() == typeof(T))
                {
                    result = pool as PoolClass<T>;
                    break;
                }
            }
            
            // If we haven't yet found a pool, we need to create a new instance of one
            if (result == null && createIfNotFound)
            {
                result = new PoolClass<T>()
                {
                    PoolLabel = "classPool_" + typeof(T)
                };
                _classPools.Add(result);
            }

            return result;
        }

        #endregion CLASSES


        #region INSTANTIATION

        internal static GameObject Instantiate(GameObject go)
        {
            return Object.Instantiate(go).gameObject;
        }
        
        internal static GameObject Instantiate(GameObject go, Transform parent)
        {
            return Object.Instantiate(go, parent).gameObject;
        }

        #endregion INSTANTIATION


        #region UTILITY
        
        public static void SetObjectPoolCapacity(
            GameObject go,
            int capacityMin, 
            int capacityMax)
        {
            IPool targetPool = GetPoolForObject(go, false);
            targetPool.CapacityMin = capacityMin;
            targetPool.CapacityMax = capacityMax;
        }
        
        public static void SetObjectPoolCapacityMin(
            GameObject go,
            int capacityMin)
        {
            IPool targetPool = GetPoolForObject(go, false);
            targetPool.CapacityMin = capacityMin;
        }
        
        public static void SetObjectPoolCapacityMax(
            GameObject go,
            int capacityMax)
        {
            IPool targetPool = GetPoolForObject(go, false);
            targetPool.CapacityMax = capacityMax;
        }
        
        public static void SetObjectPoolSpilloverAllowance(
            GameObject go,
            int spilloverAllowance)
        {
            IPool targetPool = GetPoolForObject(go, false);
            targetPool.SpilloverAllowance = spilloverAllowance;
        }
        
        public static void DeleteGameObjectPool(GameObject go)
        {
            PoolGameObject p = GetPoolForObject(go, false);
            if (p != null)
            {
                ((IPool) p).Clear();
                _gameObjectPools.Remove(p);
            }
        }

        /// <summary>
        /// Finds and returns the pool for the given object; if none exists, a pool is created
        /// </summary>
        private static PoolGameObject GetPoolForObject(GameObject go, bool createIfNotFound = true)
        {
            // Find the pool for the associated gameObject
            PoolGameObject targetPool = null;
            foreach (var pool in _gameObjectPools)
            {
                if (pool.PooledGameObject == go)
                {
                    targetPool = pool;
                    break;
                }
            }
    
            // If the target is null, there doesn't exist a pool for this GameObject yet
            if (targetPool == null && createIfNotFound)
            {
                targetPool = new PoolGameObject
                {
                    PooledGameObject = go,
                    PoolLabel = "[POOL_" + go.transform.name + "]"
                };
                    
                _gameObjectPools.Add(targetPool);
            }

            return targetPool;
        }
        
        public static void GetAndSetPoolData(DataConfigPool data)
        {
            PoolGameObject targetPool = GetPoolForObject(data.PoolObject);
            targetPool.CapacityMin = data.PoolMinimumInstanceLimit;
            targetPool.CapacityMax = data.PoolMaximumInstanceLimit;
            targetPool.SpilloverAllowance = data.SpilloverAllowance;
        }

        #endregion UTILITY
        
        
        #region RESET

        /// <summary>
        /// Resets static values to prevent issues related to domain reloading
        /// </summary>
        internal static void Init()
        {
            for (int i = _gameObjectPools.Count - 1; i >= 0; i--)
            {
                DeleteGameObjectPool(_gameObjectPools[i].PooledGameObject);
            }
            _gameObjectPools.Clear();
        }

        #endregion RESET
    }
}
