namespace GeneratePlaneMesh;

  public static class GeneratePlane
    {
        /// <summary>
        /// Generate a plane. The size is in metres only.
        /// </summary>
        /// <param name="width">The width in metres.</param>
        /// <param name="length">The height in metres.</param>
        /// <returns></returns>
        public static GameObject Generate(in int width, in int length)
        {
            GameObject gameObject = new GameObject();
            MeshFilter meshFilter = gameObject.meshFilter;
            Mesh mesh = meshFilter.mesh;
            mesh.Clear();
            
            mesh.vertices = Vertices (in width, in length);
            mesh.normals = Normals (in width, in length);
            mesh.uv = UVs (in width, in length);
            mesh.triangles = Triangles (in width, in length);

            return gameObject;
        }

        /// <summary>
        /// Generate the vertex list for the plane.
        /// </summary>
        /// <param name="width">Width in metres.</param>
        /// <param name="length">Length in metres.</param>
        /// <returns></returns>
        private static Vector3[] Vertices(in int width, in int length)
        {
            Vector3[] vertices = new Vector3[(width + 1) * (length + 1)];

            int nextIndex = 0;

            float b = length / 2.0f;
            for (int j = 0; j < length + 1; j++)
            {
                float a = width / 2.0f;
                for (int i = 0; i < width + 1; i++)
                {
                    vertices[nextIndex] = new Vector3(a, 0.0f, b);
                    a -= 1.0f;
                    nextIndex++;
                }

                b -= 1.0f;
            }
            
            return vertices;
          }
        
        /// <summary>
        /// Generate the normals for the plane. These are all upright
        /// </summary>
        /// <returns>The normals.</returns>
        private static Vector3[] Normals (in int width, in int length)
        {
            Vector3[] normals = new Vector3[(width + 1) * (length + 1)];
            for (int i = 0; i < normals.Length; i++)
            {
                normals[i] = Vector3.up;
            }

            return normals;
        }
        
        /// <summary>
        /// Generate the UV vectors.
        /// </summary>
        /// <param name="width">The width of the plane in metres.</param>
        /// <param name="length">The height of the plane in metres.</param>
        /// <returns></returns>
        private static Vector2[] UVs (in int width, in int length)
        {
            Vector2[] uvs = new Vector2[(width + 1) * (length + 1)];

            int nextIndex = 0;            
            
            for (int i = 0; i < width + 1; i++)
            {
                for (int j = 0; j < length + 1; j++)
                {
                    uvs[nextIndex] = new Vector2(i/(float)width, j/(float)length);
                    nextIndex++;
                }
            }

            return uvs;
        }
        
        private static int[] Triangles (in int width, in int length)
        {
            int[] triangles = new int[6 * width * length];

            int nextIndex = 0;
            
            for (int j = 0; j < length; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    // 1
                    triangles[nextIndex + 0] = (j*(width+1)) + i + 1;
                    // 1 + width
                    triangles[nextIndex + 1] = (j + 1) * (width+1) + i;
                    // 1 + width + 1
                    triangles[nextIndex + 2] = (j + 1) * (width+1) + 1 + i;

                    // 1
                    triangles[nextIndex + 3] = (j*(width+1)) + i + 1;
                    // 0
                    triangles[nextIndex + 4] = (j*(width+1)) + i;
                    // 1 + width
                    triangles[nextIndex + 5] = (j + 1) * (width+1) + i;
                    
                    nextIndex += 6;
                }
            }
            
            return triangles;
        }
    }