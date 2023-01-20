using UnityEngine;

namespace GG.Core
{
    public class TransformIntroLocalEulerY : TransformIntroLerp
    {
        #region VARIABLES

        [Header("Movement Settings")]
        [SerializeField] private float _startY;
        
        private Vector3 _defaultEuler;
        private Vector3 _targetEuler;

        #endregion VARIABLES
        
        
        #region INITIALIZATION

        protected override void PreStart()
        {
            _defaultEuler = transform.localEulerAngles;
            _targetEuler = _defaultEuler + (Vector3.up * _startY);
        }

        protected override void Tick(float delta)
        {
            float value = _curve.Evaluate(_normalizedProgress);
            transform.localEulerAngles = Vector3.Lerp(_targetEuler, _defaultEuler, value);
        }

        protected override void OnFinished()
        {
            transform.localEulerAngles = _defaultEuler;
        }

        #endregion INITIALIZATION
    }
}