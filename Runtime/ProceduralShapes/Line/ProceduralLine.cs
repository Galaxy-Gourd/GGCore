using UnityEngine;

namespace GG.Core
{
    public class ProceduralLine : ProceduralShape<DataLine>
    {
        #region VARIABLES

        private GameObject _rendererObj;
        private LineRenderer _line;

        #endregion VARIABLES
        
        
        #region INITIALIZATION

        protected override void CreateRenderView()
        {
            // Create line object
            _rendererObj = new GameObject();
            _rendererObj.transform.SetParent(transform);
            _rendererObj.transform.localPosition = Vector3.zero;
            _rendererObj.transform.localEulerAngles = Vector3.zero;
            _rendererObj.transform.localScale = Vector3.one;
            
            // Add line
            _line = _rendererObj.AddComponent<LineRenderer>();
            _line.useWorldSpace = true;
        }

        public override void Generate(DataLine data)
        {
            _line.SetPositions(data.Points);
            _line.startColor = data.Color;
            _line.endColor = data.Color;
            _line.startWidth = data.Width;
            _line.endWidth = data.Width;
        }

        public override void ResetShape()
        {
            
        }

        #endregion INITIALIZATION


        #region UTILITY

        public override void SetMaterial(Material material)
        {
            _line.material = material;
        }

        #endregion UTILITY
    }
}