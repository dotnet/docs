//<Snippet1>
using System; 

namespace Samples
{    
    public struct Point : IEquatable<Point>    
    {        
        private readonly int _X;        
        private readonly int _Y;         
        
        public Point(int x, int y)        
        {            
            _X = x;            
            _Y = y;        
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
    }
}
//</Snippet1>