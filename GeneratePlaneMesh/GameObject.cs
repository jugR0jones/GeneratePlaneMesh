using System.Text;

namespace GeneratePlaneMesh;

public class GameObject
{
    public MeshFilter meshFilter;

    public GameObject()
    {
        meshFilter = new MeshFilter();
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder(100000);

        Vector3[] vertices = meshFilter.mesh.vertices;
        stringBuilder.AppendLine("\nVertices [" + vertices.Length + "]");
        for (int i = 0; i < vertices.Length; i++)
        {
            stringBuilder.AppendLine("\t(" + vertices[i].x + ", " + vertices[i].y + ", " + vertices[i].z + ")");
        }
        
        Vector3[] normals = meshFilter.mesh.normals;
        stringBuilder.AppendLine("\nNormals [" + normals.Length + "]");
        for (int i = 0; i < normals.Length; i++)
        {
            stringBuilder.AppendLine("\t(" + normals[i].x + ", " + normals[i].y + ", " + normals[i].z + ")");
        }
        
        Vector2[] uv = meshFilter.mesh.uv;
        stringBuilder.AppendLine("\nUVs [" + uv.Length + "]");
        for (int i = 0; i < uv.Length; i++)
        {
            stringBuilder.AppendLine("\t(" + uv[i].x + ", " + uv[i].y + ")");
        }
        
        int[] triangles = meshFilter.mesh.triangles;
        stringBuilder.AppendLine("Triangles [" + triangles.Length + "]");
        for (int i = 0; i < triangles.Length; i++)
        {
            stringBuilder.AppendLine("\t" + triangles[i]);
        }
        
        return stringBuilder.ToString();
    }
}