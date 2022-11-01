using System.Collections.Generic;
using UnityEngine;

namespace GG.Core
{
    public class MeshCircle : ProceduralMesh<DataMeshCircle>
    {
        #region VARIABLES

        /// <summary>
        /// The vertices of the circle mesh around the outside of the circle
        /// </summary>
        public List<Vector3> OuterSurfacePoints => _surfacePoints;
        
        private readonly List<Vector3> _circleVertices = new List<Vector3>();
        private readonly List<Vector2> _uvs = new List<Vector2>();
        private readonly List<int> _tris = new List<int>();
        private readonly List<Vector3> _surfacePoints = new List<Vector3>();
        
        private const float CONST_Rad = 3.14285f / 180f;//one degree = val radians

        #endregion VARIABLES


        #region INITIALIZATION

        protected override void Awake()
        {
            base.Awake();
            
            
        }

        #endregion INITIALIZATION


        #region MESH

        public override void Generate(DataMeshCircle data)
        {
            float radius = data.Radius;
            int deltaAngle = data.DeltaAngle;

            Vector3 center = transform.position + data.CenterPosition;
            _circleVertices.Add(center);
            _uvs.Add(new Vector2(0.5f, 0.5f));
            int triangleCount = 0;

            float x1 = radius * Mathf.Cos(0);
            float y1 = radius * Mathf.Sin(0);
            float z1 = 0;
            _circleVertices.Add(new Vector3(x1, y1, z1));
            _uvs.Add(new Vector2((x1 + radius) / 2 * radius, (y1 + radius) / 2 * radius));

            for (int i = 0; i < 359; i = i + deltaAngle)
            {
                float x2 = radius * Mathf.Cos((i + deltaAngle) * CONST_Rad);
                float y2 = radius * Mathf.Sin((i + deltaAngle) * CONST_Rad);
                float z2 = 0;
                Vector3 point2 = new Vector3(x2, y2, z2);
            
                _circleVertices.Add(point2);
           
                _uvs.Add(new Vector2((x2 + radius)/ 2 * radius, (y2 +radius)/ 2 * radius));

                _tris.Add(0);
                _tris.Add(triangleCount  + 2);
                _tris.Add(triangleCount  + 1);

                triangleCount++;
                _surfacePoints.Add(point2);
            }

            _mesh.vertices = _circleVertices.ToArray();
            _mesh.triangles = _tris.ToArray();
            _mesh.uv = _uvs.ToArray();
        }

        public override void ResetShape()
        {
            base.ResetShape();
            
            _circleVertices.Clear();
            _uvs.Clear();
            _tris.Clear();
            _surfacePoints.Clear();
        }

        #endregion MESH
    }
}