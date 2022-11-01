using GG.Core.Core;
using UnityEngine;

namespace GG.Core.GameObjects
{
    /// <summary>
    /// Base class for GameObject pools. Used automatically by Pool.cs
    /// </summary>
    public class PoolGameObject : Pool
    {
        #region VARIABLES

        internal GameObject PooledGameObject;

        #endregion VARIABLES


        #region CREATION

        protected override IClientPoolable CreateNewPoolable()
        {
            GameObject newObj = PoolManager.Instantiate(PooledGameObject);
            return newObj.AddComponent<PooledInstanceGameObject>();
        }

        #endregion CREATION
    }
}