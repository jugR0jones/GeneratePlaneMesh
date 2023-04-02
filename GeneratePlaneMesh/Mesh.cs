namespace GeneratePlaneMesh;

public struct Vector3
{
    public static readonly Vector3 up = new Vector3(0.0f, 1.0f, 0.0f);
    
    public float x;
    public float y;
    public float z;

    public Vector3(in float x, in float y, in float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
}

public struct Vector2
{
    public float x;
    public float y;
    
    public Vector2(in float x, in float y)
    {
        this.x = x;
        this.y = y;
    }
}

public class Mesh
{
    public Vector3[] vertices;
    public Vector3[] normals;
    public Vector2[] uv;
    public int[] triangles;

    public int vertexCount = 0;

    public Mesh()
    {
        vertices = Array.Empty<Vector3>();
        normals = Array.Empty<Vector3>();
        uv = Array.Empty<Vector2>();
        triangles = Array.Empty<int>();
    }
    
    public void Clear()
    {
        Array.Clear(vertices);
    }
}