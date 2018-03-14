// <Snippet1>
using System;
using System.Numerics;

public class Example
{
   public static void Main()
   {
      Complex[] values = { new Complex(2.3, 1.4),
                           new Complex(-2.3, 1.4), 
                           new Complex(-2.3, -1.4),
                           new Complex(2.3, -1.4) };
      foreach (Complex value in values)
         Console.WriteLine("Sin(Asin({0})) = {1}", 
                            value, Complex.Sin(Complex.Asin(value)));
   }
}
// The example displays the following output:
//       Sin(Asin((2.3, 1.4))) = (2.3, 1.4)
//       Sin(Asin((-2.3, 1.4))) = (-2.3, 1.4)
//       Sin(Asin((-2.3, -1.4))) = (-2.3, -1.4)
//       Sin(Asin((2.3, -1.4))) = (2.3, -1.4)
// </Snippet1>