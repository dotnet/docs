//<Snippet1>
using System;

namespace UsageLibrary
{
    public struct GoodPoint
    {
        private int x,y;
        
        public GoodPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        
        public override string ToString()
        {
            return String.Format("({0},{1})",x,y);
        }
        
        public int X {get {return x;}}
        
        public int Y {get {return x;}}
        
        // Violates rule: OverrideEqualsOnOverridingOperatorEquals,
        // but does not change the meaning of equality;
        //  the violation can be excluded.
        
        public static bool operator== (GoodPoint px, GoodPoint py)
        {
            return px.Equals(py);
        }
        
        // The C# compiler and rule OperatorsShouldHaveSymmetricalOverloads require this.
        public static bool operator!= (GoodPoint px, GoodPoint py)
        {
            return !(px.Equals(py));
        }
    }
}
//</Snippet1>
