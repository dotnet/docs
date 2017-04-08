using System;
using System.Numerics;

public class Example
{
   public static void Main()
   {
      // <Snippet2>
      Complex c1 = new Complex(2.3, 3.7);
      Complex c2 = new Complex(1.4, 2.3);
      Complex c3 = c1 / c2;
      // </Snippet2>
      Console.WriteLine(c3);
   }
}
