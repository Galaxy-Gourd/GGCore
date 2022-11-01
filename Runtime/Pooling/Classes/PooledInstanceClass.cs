using GG.Core.Core;

namespace GG.Core.Classes
{
    public abstract class PooledInstanceClass : IPooledInstanceClass
    {
        #region VARIABLES

        public bool AvailableInPool { get; set; }

        #endregion VARIABLES


        #region POOLING

        public virtual void OnInstanceCreated(Pool pool)
        {
            
        }

        public virtual void Claim()
        {
            
        }

        public virtual void Relinquish()
        {
            
        }

        public virtual void Recycle()
        {
            
        }

        public virtual void DeleteFromPool()
        {
            
        }

        #endregion POOLING
    }
}