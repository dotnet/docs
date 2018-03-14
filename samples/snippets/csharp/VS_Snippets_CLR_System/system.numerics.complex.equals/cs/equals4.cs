// <Snippet8>
using System;
using System.Numerics;

public class Example
{
   public static void Main()
   {
      float n1 = 1.430718e-12f;
      Complex c1 = new Complex(1.430718e-12, 0);
      Console.WriteLine("{0} = {1}: {2}", c1, n1, c1.Equals(n1));
   }
}
// The example displays the following output:
//       (1.430718E-12, 0) = 1.430718E-12: False
// </Snippet8>
