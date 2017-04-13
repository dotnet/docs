// <Snippet1>
using System;
using System.Numerics;

public class Example
{
   public static void Main()
   {
      Complex c1 = new Complex(4.93, 6.87);
      Complex[] values = { new Complex(12.5, 9.6), 
                           new Complex(4.3, -8.1), 
                           new Complex(-1.9, 7.4), 
                           new Complex(-5.3, -6.6) };

      foreach (var c2 in values)
         Console.WriteLine("{0} - {1} = {2}", c1, c2, 
                           Complex.Subtract(c1, c2));
   }
}
// The example displays the following output:
//       (4.93, 6.87) - (12.5, 9.6) = (-7.57, -2.73)
//       (4.93, 6.87) - (4.3, -8.1) = (0.63, 14.97)
//       (4.93, 6.87) - (-1.9, 7.4) = (6.83, -0.53)
//       (4.93, 6.87) - (-5.3, -6.6) = (10.23, 13.47)
// </Snippet1>