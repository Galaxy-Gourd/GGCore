using System.Collections;
using UnityEngine;

namespace GG.Core
{
    public abstract class TransformIntroLerp : MonoBehaviour
    {
        #region VARIABLES

        [Header("Data")]
        [SerializeField] protected float _duration = 1;
        [SerializeField] protected AnimationCurve _curve;

        private float _elapsed;
        protected float _normalizedProgress;
        
        #endregion VARIABLES


        #region INITIALIZATION

        private IEnumerator Start()
        {
            PreStart();
            
            while (_elapsed < _duration)
            {
                float delta = Time.deltaTime;
                _elapsed += delta;
                _normalizedProgress = _elapsed / _duration;
                
                Tick(delta);

                yield return null;
            }

            OnFinished();
        }

        protected abstract void PreStart();
        protected abstract void Tick(float delta);
        protected abstract void OnFinished();

        #endregion INITIALIZATION
    }
}