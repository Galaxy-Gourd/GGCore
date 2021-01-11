using System.Collections.Generic;
using UnityEngine;

namespace GGUnityUtility
{
    public class MonoSystemBase<T> : MonoBehaviour where T : ISystemComponent
    {
        #region Variables

        /// <summary>
        /// The list of currently registered components for this system.
        /// </summary>
        protected readonly List<T> Components = new List<T>();

        #endregion Variables
        
        
        #region Registration

        public void AddComponent(T component)
        {
            Components.Add(component);
        }
        
        public void RemoveComponent(T component)
        {
            Components.Remove(component);
        }

        #endregion Registration
    }
}