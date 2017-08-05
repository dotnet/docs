public class Point
{
    public double X { get; }
    public double Y { get; }

    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }
}

public class LabeledPoint
{
    public double X { get; private set; }
    public double Y { get; private set; }
    public string Label { get; set; }

    // Providing the value for a default argument:
    public LabeledPoint(double x, double y, string label = default)
    {
        X = x;
        Y = y;
        this.Label = label;
    }

    public static LabeledPoint MovePoint(LabeledPoint source, 
        double xDistance, double yDistance)
    {
        // return a default value:
        if (source == null)
            return default;

        return new LabeledPoint(source.X + xDistance, source.Y + yDistance, 
        source.Label);
    }

    public static LabeledPoint FindClosestLocation(IEnumerable<LabeledPoint> sequence, 
        Point location)
    {
        // initialize variable:
        LabeledPoint rVal = default;
        double distance = double.MaxValue;

        foreach (var pt in sequence)
        {
            var thisDistance = Math.Sqrt((pt.X - location.X) * (pt.X - location.X) +
                (pt.Y - location.Y) * (pt.Y - location.Y));
            if (thisDistance < distance)
            {
                distance = thisDistance;
                rVal = pt;
            }
        }

        return rVal;
    }

    public static LabeledPoint ClosestToOrigin(IEnumerable<LabeledPoint> sequence)
        // Pass default value of an argument.
        => FindClosestLocation(sequence, default);
}
