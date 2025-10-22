using System;

namespace ca2224
{
    /*
    //<snippet1>
    // This class violates the rule.
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public static bool operator ==(Point pt1, Point pt2)
        {
            if (ReferenceEquals(pt1, null) || ReferenceEquals(pt2, null))
                return false;

            if (pt1.GetType() != pt2.GetType())
                return false;

            return pt1.X == pt2.X && pt1.Y == pt2.Y;
        }

        public static bool operator !=(Point pt1, Point pt2)
        {
            return !(pt1 == pt2);
        }
    }
    //</snippet1>
    */
}
#pragma warning disable CS0660, CS0661

namespace ca2224_2
{
    //<snippet2>
    // This class satisfies the rule.
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;

            if (GetType() != obj.GetType())
                return false;

            Point pt = (Point)obj;
            return X == pt.X && Y == pt.Y;
        }

        public static bool operator ==(Point? pt1, Point? pt2)
        {
            // Object.Equals calls Point.Equals(Object).
            return Equals(pt1, pt2);
        }

        public static bool operator !=(Point? pt1, Point? pt2)
        {
            // Object.Equals calls Point.Equals(Object).
            return !Equals(pt1, pt2);
        }
    }
    //</snippet2>
}
#pragma warning restore CS0660, CS0661
