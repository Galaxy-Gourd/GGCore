using System.Collections.Generic;

namespace GGUnityUtility
{
    /// <summary>
    /// Base definition for a system; a system is defined as a class that holds references to components, over
    /// which it iterates and performs some functionality.
    /// </summary>
    /// <typeparam name="T">The component type for this system.</typeparam>
    public abstract class SystemBase<T> where T : ISystemComponent
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