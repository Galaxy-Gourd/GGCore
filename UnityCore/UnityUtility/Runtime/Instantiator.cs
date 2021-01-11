using UnityEngine;

namespace GGUnityUtility
{
    /// <summary>
    /// Routes instantiation of unity objects.
    /// </summary>
    public static class Instantiator
    {
        #region Instantiation

        public static Object Instantiate()
        {
            return new GameObject();
        }

        public static Object Instantiate(Object go)
        {
            return Object.Instantiate(go);
        }
        
        public static  GameObject Instantiate(GameObject go)
        {
            return Object.Instantiate(go).gameObject;
        }
    
        public static  GameObject Instantiate(GameObject go, Vector3 p, Quaternion r)
        {
            return Object.Instantiate(go, p, r).gameObject;
        }
        
        public static GameObject Instantiate(GameObject go, Transform parent)
        {
            return Object.Instantiate(go, parent);
        }

        #endregion
    }
}