using UnityEngine;

namespace GG.Core
{
    public class TransformIntroLocalScale : TransformIntroLerp
    {
        #region VARIABLES

        [Header("Movement Settings")]
        [SerializeField] private float _startScale;

        private float _defaultScale;
        
        #endregion VARIABLES
        
        
        #region INITIALIZATION

        protected override void PreStart()
        {
            _defaultScale = transform.localScale.x;
        }

        protected override void Tick(float delta)
        {
            float value = _curve.Evaluate(_normalizedProgress);
            transform.localScale = Vector3.Lerp((Vector3.one * _startScale), Vector3.one * _defaultScale, value);
        }

        protected override void OnFinished()
        {
            transform.localScale = Vector3.one * _defaultScale;
        }

        #endregion INITIALIZATION
        
    }
}