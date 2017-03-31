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
    }
}
//</Snippet1>