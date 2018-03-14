// <Snippet3>
using System;
using System.Numerics;

public class Example
{
   public static void Main()
   {
      Complex[] c = { new Complex(17.3, 14.1), 
                      new Complex(-18.9, 147.2), 
                      new Complex(13.472, -18.115), 
                      new Complex(-11.154, -17.002) };
      string[] formats = { "F2", "N2", "G5" }; 
      
      foreach (Complex c1 in c)
      {
         foreach (string format in formats)
            Console.WriteLine("{0}: {1}    ", format, c1.ToString(format));

         Console.WriteLine();
      }                          
   }
}
// The example displays the following output:
//       F2: (17.30, 14.10)
//       N2: (17.30, 14.10)
//       G5: (17.3, 14.1)
//       
//       F2: (-18.90, 147.20)
//       N2: (-18.90, 147.20)
//       G5: (-18.9, 147.2)
//       
//       F2: (13.47, -18.12)
//       N2: (13.47, -18.12)
//       G5: (13.472, -18.115)
//       
//       F2: (-11.15, -17.00)
//       N2: (-11.15, -17.00)
//       G5: (-11.154, -17.002)
// </Snippet3>