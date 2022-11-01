using UnityEngine;

namespace GG.Core.Core
{
    public static class TransformUtility
    {
        // Sets the layer of an object and can changes the layer of the children.
        public static void SetLayer (Transform parentObject, int layerIndex, bool includeChildren)
        {
            parentObject.gameObject.layer = layerIndex;
            if (includeChildren)
            {
                Transform [] _transformChildren = parentObject.GetComponentsInChildren <Transform> ();         
                for (int i = 0; i < _transformChildren.Length; i++)            
                    _transformChildren [i].gameObject.layer = layerIndex;
            }      
        }


        // Deletes all children under parentObject.
        public static void DeleteChildren (Transform parentObject)
        {      
            foreach (Transform child in parentObject)
            {
                GameObject.Destroy (child.gameObject);
            }
        }


        // Traverses all parents of childObject until it detects one with a specific script.
        // Example: _trapData = (TrapData)TransformUtility.FindComponentInParent (gameObject, typeof(TrapData));
        public static Component FindComponentInParent (GameObject childObject, System.Type _componentType)
        {
            Transform t = childObject.transform;
            while (t.parent != null)
            {
                if (t.parent.GetComponent (_componentType))
                    return t.parent.GetComponent (_componentType);
                t = t.parent.transform;
            }      
            return null;      
        }


        // Finds child with name in all hierarchy children
        public static Transform FindDeepChild (this Transform aParent, string aName)
        {
            var result = aParent.Find (aName);
            if (result != null)
                return result;
            foreach (Transform child in aParent)
            {
                result = child.FindDeepChild (aName);
                if (result != null)
                    return result;
            }
            return null;
        }
    }
}
