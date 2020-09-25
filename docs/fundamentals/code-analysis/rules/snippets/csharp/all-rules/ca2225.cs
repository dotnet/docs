using System;

namespace ca2225
{
    //<snippet1>
    public struct Point
    {
        private int x, y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return String.Format("({0},{1})", x, y);
        }

        // Violates rule: OperatorOverloadsHaveNamedAlternates.
        public static Point operator +(Point a, Point b)
        {
            return new Point(a.x + b.x, a.y + b.y);
        }

        public int X { get { return x; } }
        public int Y { get { return x; } }
    }
    //</snippet1>
}
