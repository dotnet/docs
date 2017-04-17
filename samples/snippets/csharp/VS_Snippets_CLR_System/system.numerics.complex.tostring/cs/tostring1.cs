// <Snippet1>
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
      foreach (Complex c1 in c)
         Console.WriteLine(c1.ToString());
   }
}
// The example display the following output:
//       (17.3, 14.1)
//       (-18.9, 147.2)
//       (13.472, -18.115)
//       (-11.154, -17.002)
// </Snippet1>