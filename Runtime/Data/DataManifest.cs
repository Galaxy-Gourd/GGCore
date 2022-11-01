using UnityEngine;

namespace GG.Core
{
    public class DataManifest<T>: ScriptableObject
    {
        public T[] Manifest;
    }
}