using System.Drawing;
using System.Numerics;

namespace ExtensionMethods;

public static class PointExtensions
{
    // <ExtensionMethods>
    public static Vector2 ToVector(this Point point) =>
        new Vector2(point.X, point.Y);

    public static void Translate(this Point point, int xDist, int yDist)
    {
        point.X += xDist;
        point.Y += yDist;
    }

    public static void Scale(this Point point, int xScale, int yScale)
    {
        point.X *= xScale;
        point.Y *= yScale;
    }

    public static void Rotate(this Point point, int angleInDegress)
    {
        double theta = ((double)angleInDegress * Math.PI) / 180.0;
        double sinTheta = Math.Sin(theta);
        double cosTheta = Math.Cos(theta);
        double newX = (double)point.X * cosTheta - (double)point.Y * sinTheta;
        double newY = (double)point.X * sinTheta + (double)point.Y * cosTheta;
        point.X = (int)newX;
        point.Y = (int)newY;
    }
    // </ExtensionMethods>
}
