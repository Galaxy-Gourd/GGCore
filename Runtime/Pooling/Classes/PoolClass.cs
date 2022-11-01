using System;
using GG.Core.Core;

namespace GG.Core.Classes
{
    public class PoolClass<T> : Pool, IPoolClass
        where T : IPooledInstanceClass, new()
    {
        #region VARIABLES


        
        #endregion VARIABLES
        
        
        #region CREATION
        
        public PoolClass()
        {
            CapacityMin = 0;
            CapacityMax = -1;
        }

        protected override IClientPoolable CreateNewPoolable()
        {
            return new T();
        }
        
        Type IPoolClass.GetClassType()
        {
            return typeof(T);
        }

        #endregion CREATION
    }
}