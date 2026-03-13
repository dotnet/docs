// <AnyTypeAlias>
using Point = (double X, double Y);

namespace MyApp.Geometry;

class Shape
{
    public static double Distance(Point a, Point b)
    {
        var dx = a.X - b.X;
        var dy = a.Y - b.Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }
}
// </AnyTypeAlias>
