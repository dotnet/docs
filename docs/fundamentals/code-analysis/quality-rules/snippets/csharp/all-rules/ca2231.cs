using System;

namespace ca2231
{
    //<snippet1>
    public struct PointWithoutHash
    {
        private int x, y;

        public PointWithoutHash(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return String.Format("({0},{1})", x, y);
        }

        public int X { get { return x; } }

        public int Y { get { return x; } }

        // Violates rule: OverrideGetHashCodeOnOverridingEquals.
        // Violates rule: OverrideOperatorEqualsOnOverridingValueTypeEquals.
        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(PointWithoutHash))
                return false;

            PointWithoutHash p = (PointWithoutHash)obj;
            return ((this.x == p.x) && (this.y == p.y));
        }
    }
    //</snippet1>
}
