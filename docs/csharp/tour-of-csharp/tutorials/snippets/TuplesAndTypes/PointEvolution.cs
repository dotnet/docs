namespace PointEvolution;

public static class SampleTwo
{
    // <PointVersion2>
    public record Point(int X, int Y);

    public static void Main()
    {
        Point pt = new Point(1, 1);
        var pt2 = pt with { Y = 10 };
        Console.WriteLine($"The two points are {pt} and {pt2}");
    }
    // </PointVersion2>
}
