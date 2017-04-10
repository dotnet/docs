
// <Snippet1>
using System;
using System.Numerics;

public class Example
{
   public static void Main()
   {
      Complex[] values = { new Complex(12.4, 6.3), 
                           new Complex(12.4, -6.3) };
      foreach (Complex value in values)
      {
         Console.WriteLine("Original value: {0}", value);
         Console.WriteLine("Conjugate:      {0}\n", 
                           Complex.Conjugate(value).ToString());
      }                           
   }
}
// The example displays the following output:
//       Original value: (12.4, 6.3)
//       Conjugate:      (12.4, -6.3)
//       
//       Original value: (12.4, -6.3)
//       Conjugate:      (12.4, 6.3)
// </Snippet1>
