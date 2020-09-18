using System;

namespace UsageLibrary
{ 
    public class TestGoodPoint
    {
        public static void Main()
        {
            GoodPoint a = new GoodPoint(1,1);
            GoodPoint b = new GoodPoint(2,2);
            GoodPoint a1 = a;
            GoodPoint bcopy = new GoodPoint(2,2);
            
            Console.WriteLine("a =  {0} and b = {1} are equal? {2}", a, b, a.Equals(b)? "Yes":"No");
            Console.WriteLine("a == b ? {0}", a == b ? "Yes":"No");
            Console.WriteLine("a1 and a are equal? {0}", a1.Equals(a)? "Yes":"No");
            Console.WriteLine("a1 == a ? {0}", a1 == a ? "Yes":"No");
            
            // This test demonstrates the consistent behavior of == and Object.Equals.
            Console.WriteLine("b and bcopy are equal ? {0}", bcopy.Equals(b)? "Yes":"No");
            Console.WriteLine("b == bcopy ? {0}", b == bcopy ? "Yes":"No");
        }
    }
}