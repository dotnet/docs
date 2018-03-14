// <Snippet1>
using System;
using System.Numerics;

public class Example
{
   public static void Main()
   {
      Complex c1 = new Complex(1.2, 2.3);
      Complex[] values = { new Complex(1.2, 2.3), 
                           new Complex(0.5, 0.75), 
                           new Complex(3.0, -5.0) };
      foreach (Complex c2 in values)
         Console.WriteLine("{0} / {1} = {2:N2}", c1, c2, 
                           Complex.Divide(c1, c2));
   }
}
// The example displays the following output:
//       (1.2, 2.3) / (1.2, 2.3) = (1.00, 0.00)
//       (1.2, 2.3) / (0.5, 0.75) = (2.86, 0.31)
//       (1.2, 2.3) / (3, -5) = (-0.23, 0.38)
// </Snippet1>