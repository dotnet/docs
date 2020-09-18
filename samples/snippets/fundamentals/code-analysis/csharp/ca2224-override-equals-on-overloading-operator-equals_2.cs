using System;

namespace UsageLibrary
{   
    public class TestBadPoint
    {
        public static void Main()
        {
            BadPoint a = new BadPoint(1,1);
            BadPoint b = new BadPoint(2,2);
            BadPoint a1 = a;
            BadPoint bcopy = new BadPoint(2,2);
            
            Console.WriteLine("a =  {0} and b = {1} are equal? {2}", a, b, a.Equals(b)? "Yes":"No");
            Console.WriteLine("a == b ? {0}", a == b ? "Yes":"No");
            Console.WriteLine("a1 and a are equal? {0}", a1.Equals(a)? "Yes":"No");
            Console.WriteLine("a1 == a ? {0}", a1 == a ? "Yes":"No");
            
            // This test demonstrates the inconsistent behavior of == and Object.Equals.
            Console.WriteLine("b and bcopy are equal ? {0}", bcopy.Equals(b)? "Yes":"No");
            Console.WriteLine("b == bcopy ? {0}", b == bcopy ? "Yes":"No");
        }
    }
}