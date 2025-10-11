using System;

namespace ca2226
{
    //<snippet1>
    // This struct violates the rule.
    public struct Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }

        public override int GetHashCode() => HashCode.Combine(X, Y);

        // CA2226: Since 'Point' redefines operator '==', it should also redefine operator '!='
        public static bool operator ==(Point left, Point right)
            => left.X == right.X && left.Y == right.Y;

        // CA2226: Since 'Point' redefines operator '<', it should also redefine operator '>'
        public static bool operator <(Point left, Point right)
            => left.DistanceFromOrigin() < right.DistanceFromOrigin();

        // CA2226: Since 'Point' redefines operator '>=', it should also redefine operator '<='
        public static bool operator >=(Point left, Point right)
            => left.DistanceFromOrigin() >= right.DistanceFromOrigin();

        private double DistanceFromOrigin() => Math.Sqrt(X * X + Y * Y);
    }
    //</snippet1>
}

namespace ca2226_2
{
    //<snippet2>
    // This struct satisfies the rule.
    public struct Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }

        public override int GetHashCode() => HashCode.Combine(X, Y);

        public static bool operator ==(Point left, Point right)
            => left.X == right.X && left.Y == right.Y;

        public static bool operator !=(Point left, Point right)
            => !(left == right);

        public static bool operator <(Point left, Point right)
            => left.DistanceFromOrigin() < right.DistanceFromOrigin();

        public static bool operator >(Point left, Point right)
            => left.DistanceFromOrigin() > right.DistanceFromOrigin();

        public static bool operator >=(Point left, Point right)
            => left.DistanceFromOrigin() >= right.DistanceFromOrigin();

        public static bool operator <=(Point left, Point right)
            => left.DistanceFromOrigin() <= right.DistanceFromOrigin();

        private double DistanceFromOrigin() => Math.Sqrt(X * X + Y * Y);
    }
    //</snippet2>
}
