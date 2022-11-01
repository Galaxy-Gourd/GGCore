using UnityEngine;

namespace GG.Core.Data
{
    [CreateAssetMenu(
        fileName = "DataPool_",
        menuName = "GG/Pooling/Gamebject Pool Data")]
    public class DataConfigPool : DataConfig
    {
        [Header("Prefab")] 
        [Tooltip("The object being pooled.")]
        public GameObject PoolObject;

        [Header("Values")] 
        public int PoolMinimumInstanceLimit = 0;
        public int PoolMaximumInstanceLimit = -1;
        public int SpilloverAllowance = 0;
    }
}