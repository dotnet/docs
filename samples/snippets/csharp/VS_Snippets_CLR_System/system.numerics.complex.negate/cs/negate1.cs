// <Snippet1>
using System;
using System.Numerics;

public class Example
{
   public static void Main()
   {
      Complex[] values= { Complex.One, 
                          new Complex(-7.1, 2.5), 
                          new Complex(1.3, -4.2), 
                          new Complex(-3.3, -1.8) };
      foreach (Complex c1 in values)
         Console.WriteLine("{0} --> {1}", c1, Complex.Negate(c1));
   }
}
// The example displays the following output:
//       (1, 0) --> (-1, 0)
//       (-7.1, 2.5) --> (7.1, -2.5)
//       (1.3, -4.2) --> (-1.3, 4.2)
//       (-3.3, -1.8) --> (3.3, 1.8)
// </Snippet1>