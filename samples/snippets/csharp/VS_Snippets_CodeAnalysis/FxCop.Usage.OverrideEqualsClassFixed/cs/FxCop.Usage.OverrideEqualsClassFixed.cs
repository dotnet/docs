//<Snippet1>
using System; 

namespace Samples
{    
    public class Point    
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
            if (obj == null)                
                return false;             
                
            if (GetType() != obj.GetType())                
                return false;             
            
            Point point = (Point)obj;             
            
            if (_X != point.X)                
                return false;             
                
            return _Y == point.Y;        
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
}
//</Snippet1>