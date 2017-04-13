//<Snippet1>
using System; 

namespace Samples
{    
    // Violates this rule    
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
    }
}
//</Snippet1>