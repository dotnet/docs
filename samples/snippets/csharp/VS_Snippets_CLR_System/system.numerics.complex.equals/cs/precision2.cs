using System;
// <Snippet7>
using System.Numerics;

public class Example
{
   public static void Main()
   {
      float n1 = 1.430718e-12f;
      Complex c1 = new Complex(1.430718e-12, 0);
      double difference = .0001;
      
      // Compare the values
      bool result = (Math.Abs(c1.Real - n1) <= c1.Real * difference) &
                    c1.Imaginary == 0;
      Console.WriteLine("{0} = {1}: {2}", c1, n1, result);       
   }
}
// The example displays the following output:
//       (1.430718E-12, 0) = 1.430718E-12: True
// </Snippet7>
