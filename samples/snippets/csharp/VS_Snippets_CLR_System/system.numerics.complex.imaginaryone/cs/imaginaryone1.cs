// <Snippet1>
using System;
using System.Numerics;

public class Example
{
   public static void Main()
   {
      Complex value = Complex.ImaginaryOne;
      Console.WriteLine(value.ToString());
      
      // Instantiate a complex number with real part 0 and imaginary part 1.
      Complex value1 = new Complex(0, 1);
      Console.WriteLine(value.Equals(value1));
   }
}
// The example displays the following output:
//       (0, 1)
//       True
// </Snippet1>