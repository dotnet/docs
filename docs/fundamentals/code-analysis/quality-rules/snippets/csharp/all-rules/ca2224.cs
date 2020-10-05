using System;

namespace ca2224
{
    //<snippet1>
    public class BadPoint
    {
        private int y;
        private static int NextId;

        static BadPoint()
        {
            NextId = -1;
        }
        public BadPoint(int x, int y)
        {
            this.X = x;
            this.y = y;
            Id = ++(BadPoint.NextId);
        }

        public override string ToString()
        {
            return String.Format("([{0}] {1},{2})", Id, X, y);
        }

        public int X { get; }
        public int Y { get { return X; } }
        public int Id { get; }

        public override int GetHashCode()
        {
            return Id;
        }
        // Violates rule: OverrideEqualsOnOverridingOperatorEquals.

        // BadPoint redefines the equality operator to ignore the id value.
        // This is different from how the inherited implementation of
        // System.Object.Equals behaves for value types.
        // It is not safe to exclude the violation for this type.
        public static bool operator ==(BadPoint p1, BadPoint p2)
        {
            return ((p1.X == p2.X) && (p1.y == p2.y));
        }

        // The C# compiler and rule OperatorsShouldHaveSymmetricalOverloads require this.
        public static bool operator !=(BadPoint p1, BadPoint p2)
        {
            return !(p1 == p2);
        }
    }
    //</snippet1>

    //<snippet2>
    public class TestBadPoint
    {
        public static void Main_ca2224()
        {
            BadPoint a = new BadPoint(1, 1);
            BadPoint b = new BadPoint(2, 2);
            BadPoint a1 = a;
            BadPoint bcopy = new BadPoint(2, 2);

            Console.WriteLine("a =  {0} and b = {1} are equal? {2}", a, b, a.Equals(b) ? "Yes" : "No");
            Console.WriteLine("a == b ? {0}", a == b ? "Yes" : "No");
            Console.WriteLine("a1 and a are equal? {0}", a1.Equals(a) ? "Yes" : "No");
            Console.WriteLine("a1 == a ? {0}", a1 == a ? "Yes" : "No");

            // This test demonstrates the inconsistent behavior of == and Object.Equals.
            Console.WriteLine("b and bcopy are equal ? {0}", bcopy.Equals(b) ? "Yes" : "No");
            Console.WriteLine("b == bcopy ? {0}", b == bcopy ? "Yes" : "No");
        }
    }
    //</snippet2>

    //<snippet3>
    public struct GoodPoint
    {
        private int y;

        public GoodPoint(int x, int y)
        {
            this.X = x;
            this.y = y;
        }

        public override string ToString()
        {
            return String.Format("({0},{1})", X, y);
        }

        public int X { get; }

        public int Y { get { return X; } }

        // Violates rule: OverrideEqualsOnOverridingOperatorEquals,
        // but does not change the meaning of equality;
        //  the violation can be excluded.

        public static bool operator ==(GoodPoint px, GoodPoint py)
        {
            return px.Equals(py);
        }

        // The C# compiler and rule OperatorsShouldHaveSymmetricalOverloads require this.
        public static bool operator !=(GoodPoint px, GoodPoint py)
        {
            return !(px.Equals(py));
        }
    }
    //</snippet3>

    //<snippet4>
    public class TestGoodPoint
    {
        public static void Main_ca2224_2()
        {
            GoodPoint a = new GoodPoint(1, 1);
            GoodPoint b = new GoodPoint(2, 2);
            GoodPoint a1 = a;
            GoodPoint bcopy = new GoodPoint(2, 2);

            Console.WriteLine("a =  {0} and b = {1} are equal? {2}", a, b, a.Equals(b) ? "Yes" : "No");
            Console.WriteLine("a == b ? {0}", a == b ? "Yes" : "No");
            Console.WriteLine("a1 and a are equal? {0}", a1.Equals(a) ? "Yes" : "No");
            Console.WriteLine("a1 == a ? {0}", a1 == a ? "Yes" : "No");

            // This test demonstrates the consistent behavior of == and Object.Equals.
            Console.WriteLine("b and bcopy are equal ? {0}", bcopy.Equals(b) ? "Yes" : "No");
            Console.WriteLine("b == bcopy ? {0}", b == bcopy ? "Yes" : "No");
        }
    }
    //</snippet4>
}

namespace ca2224_2
{
    //<snippet5>
    // Violates this rule
    public class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }

        public int Y { get; }

        public override int GetHashCode()
        {
            return X ^ Y;
        }

        public static bool operator ==(Point point1, Point point2)
        {
            if (point1 == null || point2 == null)
                return false;

            if (point1.GetType() != point2.GetType())
                return false;

            if (point1.X != point2.X)
                return false;

            return point1.Y == point2.Y;
        }

        public static bool operator !=(Point point1, Point point2)
        {
            return !(point1 == point2);
        }
    }
    //</snippet5>
}

namespace ca2224_3
{
    //<snippet6>
    public class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }

        public int Y { get; }

        public override int GetHashCode()
        {
            return X ^ Y;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (GetType() != obj.GetType())
                return false;

            Point point = (Point)obj;

            if (X != point.X)
                return false;

            return Y == point.Y;
        }

        public static bool operator ==(Point point1, Point point2)
        {
            return Object.Equals(point1, point2);
        }

        public static bool operator !=(Point point1, Point point2)
        {
            return !Object.Equals(point1, point2);
        }
    }
    //</snippet6>
}

namespace ca2224_4
{
    //<snippet7>
    // Violates this rule
    public struct Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }

        public int Y { get; }

        public override int GetHashCode()
        {
            return X ^ Y;
        }

        public static bool operator ==(Point point1, Point point2)
        {
            if (point1.X != point2.X)
                return false;

            return point1.Y == point2.Y;
        }

        public static bool operator !=(Point point1, Point point2)
        {
            return !(point1 == point2);
        }
    }
    //</snippet7>
}

namespace Samples
{
    //<snippet8>
    public struct Point : IEquatable<Point>
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }

        public int Y { get; }

        public override int GetHashCode()
        {
            return X ^ Y;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Point))
                return false;

            return Equals((Point)obj);
        }

        public bool Equals(Point other)
        {
            if (X != other.X)
                return false;

            return Y == other.Y;
        }

        public static bool operator ==(Point point1, Point point2)
        {
            return point1.Equals(point2);
        }

        public static bool operator !=(Point point1, Point point2)
        {
            return !point1.Equals(point2);
        }
    }
    //</snippet8>
}
