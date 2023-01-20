using System;
using UnityEngine;

namespace GG.Core.Data
{
    [CreateAssetMenu(
        fileName = "DAT_Pool_",
        menuName = "GG/Pooling/Gamebject Pool Data")]
    public class DataConfigPool : DataConfig
    {
        #region DATA

        [Header("Prefab")] 
        [Tooltip("The object being pooled.")]
        public GameObject PoolObject;

        [Header("Values")] 
        public int PoolMinimumInstanceLimit = 0;
        public int PoolMaximumInstanceLimit = -1;
        public int SpilloverAllowance = 0;

        #endregion DATA


        #region VALIDATION

        public Action OnValidated;
        private void OnValidate()
        {
            if (Application.isPlaying)
            {
                if (PoolMaximumInstanceLimit == 0)
                {
                    PoolMaximumInstanceLimit = -1;
                }
                
                OnValidated?.Invoke();
            }
        }

        #endregion VALIDATION
    }
}