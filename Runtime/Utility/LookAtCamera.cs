﻿using UnityEngine;

namespace GG.Core
{
    /// <summary>
    /// Basic Utility to aim the gameObject at the camera.
    /// </summary>
    public class LookAtCamera : MonoBehaviour
    {

        private Transform cameraTransform;
        public bool flip;

        private void Start()
        {
            cameraTransform = Camera.main.transform;
        }

        void Update()
        {
            if (cameraTransform != null)
            {
                if (!flip)
                {
                    transform.LookAt(cameraTransform);
                }
                else
                {
                    transform.LookAt(2 * transform.position - cameraTransform.position);
                }
            }

        }
    }
}
