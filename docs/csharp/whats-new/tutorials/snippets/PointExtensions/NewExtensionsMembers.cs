using System.Drawing;
using System.Numerics;

namespace ExtensionMembers;

public static class PointExtensions
{
    extension(Point)
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
    }

    extension(ref Point point)
    {
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

        public void Rotate(int angleInDegrees)
        {
            double theta = ((double)angleInDegrees * Math.PI) / 180.0;
            double sinTheta = Math.Sin(theta);
            double cosTheta = Math.Cos(theta);
            double newX = (double)point.X * cosTheta - (double)point.Y * sinTheta;
            double newY = (double)point.X * sinTheta + (double)point.Y * cosTheta;
            point.X = (int)newX;
            point.Y = (int)newY;
        }
        // </TransformationMethods>
    }

    // <PathIndexer>
    extension(Path path)
    {
        public Point this[int index]
        {
            get
            {
                ValidatePathIndex(path, index);

                Point absolutePoint = Point.Origin;
                for (int current = 0; current <= index; current++)
                {
                    var offset = path.GetOffset(current);
                    absolutePoint += offset;
                }

                return absolutePoint;
            }
            set
            {
                ValidatePathIndex(path, index);

                Point previousPoint = Point.Origin;
                for (int current = 0; current < index; current++)
                {
                    var offset = path.GetOffset(current);
                    previousPoint += offset;
                }

                path.SetOffset(index, (value.X - previousPoint.X, value.Y - previousPoint.Y));
            }
        }
    }

    private static void ValidatePathIndex(Path path, int index)
    {
        if (index < 0 || index >= path.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), index,
                "Index must refer to an offset in the path.");
        }
    }
    // </PathIndexer>
}
