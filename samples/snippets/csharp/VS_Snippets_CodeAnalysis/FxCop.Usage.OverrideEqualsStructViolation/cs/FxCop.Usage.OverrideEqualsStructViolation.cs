//<Snippet1>
using System; 

namespace Samples
{    
    // Violates this rule    
    public struct Point    
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
        
        public static bool operator ==(Point point1, Point point2)        
        {            
            if (point1._X != point2._X)                
                return false;                        
                
            return point1._Y == point2._Y;        
        }         
        
        public static bool operator !=(Point point1, Point point2)        
        {            
            return !(point1 == point2);        
        }    
    }
}
//</Snippet1>