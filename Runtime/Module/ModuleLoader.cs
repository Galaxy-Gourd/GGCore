using System;
using UnityEngine;

namespace GG.Core
{
    /// <summary>
    /// Collects and controls module instances at runtime.
    /// </summary>
    [DefaultExecutionOrder(-500)]
    public class ModuleLoader : MonoBehaviour
    {
        #region VARIABLES
        
        [SerializeField] private Module[] _modules;

        #endregion VARIABLES
        

        #region INITIALIZATION

        private void Awake()
        {
            Modules.LoadModules(_modules);
        }

        #endregion INITIALIZATION
    }
}