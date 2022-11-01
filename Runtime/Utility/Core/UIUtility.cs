using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GG.Core.Core
{
    public static class UIUtility 
    {
        // Checks if an input is on a UI object
        public static bool IsPointerOverUIObject ()
        {
            PointerEventData eventDataCurrentPosition = new PointerEventData (EventSystem.current);
            eventDataCurrentPosition.position = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
            List <RaycastResult> results = new List <RaycastResult> ();
            EventSystem.current.RaycastAll (eventDataCurrentPosition, results);
            return results.Count > 0;
        }


        public static bool IsPositionOverUIObject (Vector2 position)
        {
            PointerEventData eventDataCurrentPosition = new PointerEventData (EventSystem.current);
            eventDataCurrentPosition.position = position;
            List <RaycastResult> results = new List<RaycastResult> ();
            EventSystem.current.RaycastAll (eventDataCurrentPosition, results);
            return results.Count > 0;
        }


        /// <summary>
        /// Calulates Position for RectTransform.position from a transform.position. Does not Work with WorldSpace Canvas!
        /// </summary>
        /// <param name="_Canvas"> The Canvas parent of the RectTransform.</param>
        /// <param name="_Position">Position of in world space of the "Transform" you want the "RectTransform" to be.</param>
        /// <param name="_Cam">The Camera which is used. Note this is useful for split screen and both RenderModes of the Canvas.</param>
        /// <returns></returns>
        public static Vector3 CalculatePositionFromTransformToRectTransform (Canvas _Canvas, Vector3 _Position, Camera _Cam)
        {
            Vector3 Return = Vector3.zero;
            if (_Canvas.renderMode == RenderMode.ScreenSpaceOverlay)
            {
                Return = _Cam.WorldToScreenPoint (_Position);
            }
            else if (_Canvas.renderMode == RenderMode.ScreenSpaceCamera)
            {
                RectTransformUtility.ScreenPointToLocalPointInRectangle (
                    _Canvas.transform as RectTransform, 
                    _Cam.WorldToScreenPoint (_Position), 
                    _Cam, 
                    out var tempVector);
                Return = _Canvas.transform.TransformPoint (tempVector);
            }

            return Return;
        }


        /// <summary>
        /// Calulates Position for RectTransform.position Mouse Position. Does not Work with WorldSpace Canvas!
        /// </summary>
        /// <param name="_Canvas">The Canvas parent of the RectTransform.</param>
        /// <param name="_Cam">The Camera which is used. Note this is useful for split screen and both RenderModes of the Canvas.</param>
        /// <returns></returns>
        public static Vector3 CalculatePositionFromMouseToRectTransform (Canvas _Canvas, Camera _Cam)
        {
            Vector3 Return = Vector3.zero;

            if (_Canvas.renderMode == RenderMode.ScreenSpaceOverlay)
            {
                Return = Input.mousePosition;
            }
            else if (_Canvas.renderMode == RenderMode.ScreenSpaceCamera)
            {
                Vector2 tempVector = Vector2.zero;
                RectTransformUtility.ScreenPointToLocalPointInRectangle (
                    _Canvas.transform as RectTransform,
                    Input.mousePosition,
                    _Cam, out tempVector);
                Return = _Canvas.transform.TransformPoint (tempVector);
            }

            return Return;
        }


        /// <summary>
        /// Calculates Position for "Transform".position from a "RectTransform".position. Does not Work with WorldSpace Canvas!
        /// </summary>
        /// <param name="_Canvas">The Canvas parent of the RectTransform.</param>
        /// <param name="_Position">Position of the "RectTransform" UI element you want the "Transform" object to be placed to.</param>
        /// <param name="_Cam">The Camera which is used. Note this is useful for split screen and both RenderModes of the Canvas.</param>
        /// <returns></returns>
        public static Vector3 CalculatePositionFromRectTransformToTransform (Canvas _Canvas, Vector3 _Position, Camera _Cam)
        {
            Vector3 Return = Vector3.zero;
            if (_Canvas.renderMode == RenderMode.ScreenSpaceOverlay)
            {
                Return = _Cam.ScreenToWorldPoint (_Position);
            }
            else if (_Canvas.renderMode == RenderMode.ScreenSpaceCamera)
            {
                RectTransformUtility.ScreenPointToWorldPointInRectangle (_Canvas.transform as RectTransform, _Cam.WorldToScreenPoint (_Position), _Cam, out Return);
            }
            return Return;
        }
    }
}
