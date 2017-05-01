// <Snippet1>
using System;
using System.Numerics;

public class Example
{
   public static void Main()
   {
      Complex value = Complex.Zero;
      Console.WriteLine(value.ToString());
      
      // Instantiate a complex number with real part 0 and imaginary part 1.
      Complex value1 = new Complex(0, 0);
      Console.WriteLine(value.Equals(value1));
   }
}
// The example displays the following output:
//       (0, 0)
//       True
// </Snippet1>