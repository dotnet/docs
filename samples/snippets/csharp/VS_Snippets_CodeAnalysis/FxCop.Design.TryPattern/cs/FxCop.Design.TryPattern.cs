//<Snippet1>
using System;

namespace Samples
{
    public struct Point
    {
        private readonly int _X;
        private readonly int _Y;

        public Point(int axisX, int axisY)
        {
            _X = axisX;
            _Y = axisY;
        }
        
        public int X
        {
            get { return _X; }
        }

        public int Y
        {
            get { return _Y; }
        }

        public override int GetHashCode()
        {
            return _X ^ _Y;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Point))
                return false;

            return Equals((Point)obj);
        }

        public bool Equals(Point other)
        {
            if (_X != other._X)
                return false;

            return _Y == other._Y;
        }

        public static bool operator ==(Point point1, Point point2)
        {
            return point1.Equals(point2);
        }

        public static bool operator !=(Point point1, Point point2)
        {
            return !point1.Equals(point2);
        }

        // Does not violate this rule
        public static bool TryParse(string value, out Point result)
        {
            // TryParse Implementation
            result = new Point(0,0);
            return false;
        }
    }
}
//</Snippet1>
