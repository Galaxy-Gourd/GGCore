using UnityEngine;

namespace GG.Core
{
    /// <summary>
    /// Base class for UIViews - these are classes that control the appearance and behavior of UI panels
    /// </summary>
    /// <typeparam name="T">The struct of parameters that this view can receive</typeparam>
    public abstract class UIView<T> : MonoBehaviour 
        where T : struct
    {
        #region VARIABLES

        private bool _isActive;
        protected T _parameters;

        #endregion VARIABLES
        
        
        #region INITIALIZATION

        private void OnEnable()
        {
            SetupCallbacks();
        }

        public virtual void Show(bool force = false)
        {
            if (!_isActive)
            {
                gameObject.SetActive(true);
                _isActive = true;
            }
        }

        public virtual void Show(T parameters, bool force = false)
        {
            if (!_isActive || force)
            {
                SetParameters(parameters);
                Show();
            }
        }
        
        public virtual void Hide(bool force = false)
        {
            if (_isActive || force)
            {          
                gameObject.SetActive(false);
                _isActive = false;
            }
        }

        private void OnDisable()
        {
            CleanupCallbacks();
        }

        #endregion INITIALIZATION
        
        
        #region PARAMETERS

        public void SetParameters(T parameters)
        {
            _parameters = parameters;
            SetParameters();
        }

        protected abstract void SetParameters();

        #endregion PARAMETERS


        #region ACTION SETUP

        protected virtual void SetupCallbacks()
        {
            
        }

        protected virtual void CleanupCallbacks()
        {
            
        }

        #endregion ACTION SETUP
    }
}