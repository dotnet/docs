namespace PointEvolution;

// <PointVersion2>
public record Point(int X, int Y)
{
    public double Slope() => (double)Y / (double)X;
}
// </PointVersion2>

public static class Expected
{
    public static void Example()
    {
        // <Version2Usage>
        Point pt = new Point(1, 1);
        double slope = pt.Slope();
        Console.WriteLine($"The slope of {pt} is {slope}");
        // </Version2Usage>
    }
}
