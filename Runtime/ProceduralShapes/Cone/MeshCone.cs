using UnityEngine;

namespace GG.Core
{
    public class MeshCone : ProceduralMesh<DataMeshCone>
    {
        #region VARIABLES

        

        #endregion VARIABLES


        #region INITIALIZATION

        protected override void Awake()
        {
            base.Awake();
            
            
        }

        #endregion INITIALIZATION
        
        
        #region MESH
        
        public override void Generate(DataMeshCone data)
        {
            _mesh.Clear();

            //
            _rendererObj.transform.localEulerAngles = new Vector3(-90, 0, 0);
            _rendererObj.transform.localPosition = new Vector3(0, 0, data.Height);
            
            int nbSides = data.NBSides;
            float bottomRadius = data.BottomRadius;
            float topRadius = data.TopRadius;
            float height = data.Height;
            int nbVerticesCap = data.NBSides + 1;

            #region Vertices

            // bottom + top + sides
            _vertices = new Vector3[nbVerticesCap + nbVerticesCap + nbSides * 2 + 2];

            // Bottom cap
            _vertices[0] = new Vector3(0f, 0f, 0f);
            for (var idx = 1; idx <= nbSides; idx++)
            {
                float rad = (float)(idx) / nbSides * _2pi;
                _vertices[idx] = new Vector3(Mathf.Cos(rad) * bottomRadius, 0f, Mathf.Sin(rad) * bottomRadius);
            }

            // Top cap
            _vertices[nbSides + 1] = new Vector3(0f, height, 0f);
            for (var idx = nbSides + 2; idx <= nbSides * 2 + 1; idx++)
            {
                float rad = (float)(idx - nbSides - 1) / nbSides * _2pi;
                _vertices[idx] = new Vector3(Mathf.Cos(rad) * topRadius, height, Mathf.Sin(rad) * topRadius);
            }

            // Sides
            int v = 0;
            for (var idx = nbSides * 2 + 2; idx <= _vertices.Length - 4; idx += 2)
            {
                float rad = (float)v / nbSides * _2pi;
                _vertices[idx] = new Vector3(Mathf.Cos(rad) * topRadius, height, Mathf.Sin(rad) * topRadius);
                _vertices[idx + 1] = new Vector3(Mathf.Cos(rad) * bottomRadius, 0, Mathf.Sin(rad) * bottomRadius);
                v++;
            }

            _vertices[^2] = _vertices[nbSides * 2 + 2];
            _vertices[^1] = _vertices[nbSides * 2 + 3];

            #endregion

            #region Triangles

            int nbTriangles = nbSides + nbSides + nbSides * 2;
            int[] triangles = new int[nbTriangles * 3 + 3];

            // Bottom cap
            int tri = 0;
            int i = 0;
            while (tri < nbSides - 1)
            {
                triangles[i] = 0;
                triangles[i + 1] = tri + 1;
                triangles[i + 2] = tri + 2;
                tri++;
                i += 3;
            }

            triangles[i] = 0;
            triangles[i + 1] = tri + 1;
            triangles[i + 2] = 1;
            tri++;
            i += 3;

            // Top cap
            //tri++;
            while (tri < nbSides * 2)
            {
                triangles[i] = tri + 2;
                triangles[i + 1] = tri + 1;
                triangles[i + 2] = nbVerticesCap;
                tri++;
                i += 3;
            }

            triangles[i] = nbVerticesCap + 1;
            triangles[i + 1] = tri + 1;
            triangles[i + 2] = nbVerticesCap;
            tri++;
            i += 3;
            tri++;

            // Sides
            while (tri <= nbTriangles)
            {
                triangles[i] = tri + 2;
                triangles[i + 1] = tri + 1;
                triangles[i + 2] = tri + 0;
                tri++;
                i += 3;

                triangles[i] = tri + 1;
                triangles[i + 1] = tri + 2;
                triangles[i + 2] = tri + 0;
                tri++;
                i += 3;
            }

            #endregion

            _mesh.vertices = _vertices;
            _mesh.triangles = triangles;

            _mesh.RecalculateBounds();
            _mesh.RecalculateNormals();
            _mesh.RecalculateTangents();
            _mesh.Optimize();
        }
        
        public override void ResetShape()
        {
            base.ResetShape();
            
            
        }

        #endregion MESH
    }
}