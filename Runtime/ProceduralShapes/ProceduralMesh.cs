using UnityEngine;

namespace GG.Core
{
    public abstract class ProceduralMesh<TMeshData> : ProceduralShape<TMeshData>
        where TMeshData : struct
    {
        #region VARIABLES

        [Header("Rendering")]
        [SerializeField] private bool _rendererIsActive = true;
        [SerializeField] private Material _rendererMaterial;

        public Mesh Mesh => _mesh;
        public MeshRenderer Renderer => _renderer;
        
        protected GameObject _rendererObj;
        protected MeshFilter _filter;
        protected MeshRenderer _renderer;
        protected Mesh _mesh;
        protected Vector3[] _vertices;
        protected const float _2pi = Mathf.PI * 2f;

        #endregion VARIABLES
        
        
        #region INITIALIZATION

        protected override void CreateRenderView()
        {
            // Create mesh and renderer
            _rendererObj = new GameObject("[MeshObject]");
            _rendererObj.transform.SetParent(transform);
            _rendererObj.transform.localPosition = Vector3.zero;
            _rendererObj.transform.localEulerAngles = Vector3.zero;
            _rendererObj.transform.localScale = Vector3.one;
            
            // Create filter components
            _filter = _rendererObj.AddComponent<MeshFilter>();
            _renderer = _rendererObj.AddComponent<MeshRenderer>();
            _mesh = new Mesh();
            _filter.mesh = _mesh;
            
            // Setup renderer component
            _renderer.enabled = _rendererIsActive;
            if (_rendererIsActive && _rendererMaterial)
            {
                _renderer.material = _rendererMaterial;
            }
        }

        #endregion INITIALIZATION


        #region GENERATION

        public override void ResetShape()
        {
            _mesh.Clear();
        }

        #endregion GENERATION


        #region UTILITY

        public override void SetMaterial(Material material)
        {
            _renderer.material = material;
        }

        #endregion UTILITY
    }
}