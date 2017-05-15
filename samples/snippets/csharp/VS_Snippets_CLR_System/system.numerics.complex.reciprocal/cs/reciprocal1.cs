// <Snippet1>
using System;
using System.Numerics;

public class Example
{
   public static void Main()
   {
      Complex[] values = { new Complex(1, 1), 
                           new Complex(-1, 1), 
                           new Complex(10, -1),
                           new Complex(3, 5) };
      foreach (Complex value in values)
      {         
         Complex r1 = Complex.Reciprocal(value);                   
         Console.WriteLine("{0:N0} x {1:N2} = {2:N2}", 
                           value, r1, value * r1);
      }
   }
}
// The example displays the following output:
//       (1, 1) x (0.50, -0.50) = (1.00, 0.00)
//       (-1, 1) x (-0.50, -0.50) = (1.00, 0.00)
//       (10, -1) x (0.10, 0.01) = (1.00, 0.00)
//       (3, 5) x (0.09, -0.15) = (1.00, 0.00)
// </Snippet1>