using GeneratePlaneMesh;

internal static class Program
{
    private static void Main(string[] args)
    {
        GameObject plane = GeneratePlane.Generate(3, 1);
        
        Console.WriteLine(plane.ToString());
    }
}
