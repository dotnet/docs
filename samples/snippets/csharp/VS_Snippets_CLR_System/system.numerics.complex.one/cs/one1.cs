// <Snippet1>
using System;
using System.Numerics;

public class Example
{
   public static void Main()
   {
      Complex value = Complex.One;
      Console.WriteLine(value.ToString());
      
      // Instantiate a complex number with real part 1 and imaginary part 0.
      Complex value1 = new Complex(1, 0);
      Console.WriteLine(value.Equals(value1));
   }
}
// The example displays the following output:
//       (1, 0)
//       True
// </Snippet1>