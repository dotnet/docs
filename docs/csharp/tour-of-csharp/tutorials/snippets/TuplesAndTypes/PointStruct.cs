namespace FinalRecord
{
    public static class SampleThree
    {
        // <PointVersion3>
        public record Point(int X, int Y)
        {
            public double Slope() => (double)Y / (double)X;
        }
        // </PointVersion3>
        public static void Main()
        {
            Point pt = new Point(1, 1);
            var pt2 = pt with { Y = 10 };
            // <UseSlope>
            double slope = pt.Slope();
            Console.WriteLine($"The slope of {pt} is {slope}");
            // </UseSlope>
        }
    }
}

namespace MoreStruct
{
    // <RecordStruct>
    public record struct Point(int X, int Y)
    {
        public double Slope() => (double) Y / (double) X;
    }
    // </RecordStruct>
}
