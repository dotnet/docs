// <Snippet1>
using System;
using System.Numerics;

public class Example
{
   public static void Main()
   {
      Complex[] values = { new Complex(12.5, -6.3), 
                           new Complex(-17.8, 1.7), 
                           new Complex(14.4, 8.9) };
      foreach (var value in values)
         Console.WriteLine("{0} + {1}i", value.Real, value.Imaginary);
   }
}
// The example displays the following output:
//       12.5 + -6.3i
//       -17.8 + 1.7i
//       14.4 + 8.9i
// </Snippet1>