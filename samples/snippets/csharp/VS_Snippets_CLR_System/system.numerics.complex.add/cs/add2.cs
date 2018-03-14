// <Snippet2>
using System;
using System.Numerics;

public class Example
{
   public static void Main()
   {
      Complex[] values= { new Complex(12.3, -1.4), 
                          new Complex(-6.2, 3.1), 
                          new Complex(8.9, 1.5) };   
      foreach (var c1 in values)
         foreach (var c2 in values)
            Console.WriteLine("{0} + {1} = {2}", c1, c2, c1 + c2);
   }
}
// The example displays the following output:
//       (12.3, -1.4) + (12.3, -1.4) = (24.6, -2.8)
//       (12.3, -1.4) + (-6.2, 3.1) = (6.1, 1.7)
//       (12.3, -1.4) + (8.9, 1.5) = (21.2, 0.1)
//       (-6.2, 3.1) + (12.3, -1.4) = (6.1, 1.7)
//       (-6.2, 3.1) + (-6.2, 3.1) = (-12.4, 6.2)
//       (-6.2, 3.1) + (8.9, 1.5) = (2.7, 4.6)
//       (8.9, 1.5) + (12.3, -1.4) = (21.2, 0.1)
//       (8.9, 1.5) + (-6.2, 3.1) = (2.7, 4.6)
//       (8.9, 1.5) + (8.9, 1.5) = (17.8, 3)
// </Snippet2>