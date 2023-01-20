using UnityEngine;

namespace GG.Core
{
    public class TransformIntroLocalPositionY : TransformIntroLerp
    {
        #region VARIABLES

        [Header("Movement Settings")]
        [SerializeField] private float _startY;
        
        private Vector3 _defaultPosition;
        private Vector3 _targetPosition;

        #endregion VARIABLES
        
        
        #region INITIALIZATION

        protected override void PreStart()
        {
            _defaultPosition = transform.localPosition;
            _targetPosition = _defaultPosition + (Vector3.up * _startY);
        }

        protected override void Tick(float delta)
        {
            float value = _curve.Evaluate(_normalizedProgress);
            transform.localPosition = Vector3.Lerp(_targetPosition, _defaultPosition, value);
        }

        protected override void OnFinished()
        {
            transform.localPosition = _defaultPosition;
        }

        #endregion INITIALIZATION
    }
}