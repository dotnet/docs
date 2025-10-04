using System.Drawing;
using System.Numerics;

namespace ExtensionMembers;

public static class PointExtensions
{
    extension(Point point)
    {
        public static Point Origin => Point.Empty;

        // <ArithmeticOperators>
        public static Point operator +(Point left, Point right) =>
            new Point(left.X + right.X, left.Y + right.Y);

        public static Point operator -(Point left, Point right) =>
            new Point(left.X - right.X, left.Y - right.Y);
        // </ArithmeticOperators>

        // <TupleBasedXYOperators>
        public static Point operator *(Point left, (int dx, int dy) scale) =>
            new Point(left.X * scale.dx, left.Y * scale.dy);
        public static Point operator /(Point left, (int dx, int dy) scale) =>
            new Point(left.X / scale.dx, left.Y / scale.dy);
        public static Point operator +(Point left, (int dx, int dy) scale) =>
            new Point(left.X + scale.dx, left.Y + scale.dy);
        public static Point operator -(Point left, (int dx, int dy) scale) =>
            new Point(left.X - scale.dx, left.Y - scale.dy);
        // </TupleBasedXYOperators>

        // <TransformationMethods>
        public Vector2 ToVector() =>
            new Vector2(point.X, point.Y);

        public void Translate(int xDist, int yDist)
        {
            point.X += xDist;
            point.Y += yDist;
        }

        public void Scale(int xScale, int yScale)
        {
            point.X *= xScale;
            point.Y *= yScale;
        }

        public void Rotate(int angleInDegress)
        {
            double theta = ((double)angleInDegress * Math.PI) / 180.0;
            double sinTheta = Math.Sin(theta);
            double cosTheta = Math.Cos(theta);
            double newX = (double)point.X * cosTheta - (double)point.Y * sinTheta;
            double newY = (double)point.X * sinTheta + (double)point.Y * cosTheta;
            point.X = (int)newX;
            point.Y = (int)newY;
        }
        // </TransformationMethods>

    }
}
