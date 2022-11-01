using System;
using UnityEngine;

namespace GG.Core
{
    [DefaultExecutionOrder(-500)]
    public abstract class ProceduralShape<TData> : MonoBehaviour
        where TData : struct
    {
        #region VARIABLES

        

        #endregion VARIABLES


        #region INITIALIZATION

        protected virtual void Awake()
        {
            CreateRenderView();
        }

        /// <summary>
        /// We need to create a mesh or line or whatever to visualize the debug shape
        /// </summary>
        protected abstract void CreateRenderView();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public abstract void Generate(TData data);

        /// <summary>
        /// 
        /// </summary>
        public abstract void ResetShape();

        #endregion INITIALIZATION


        #region UTILITY

        public abstract void SetMaterial(Material material);

        #endregion UTILITY
    }
}