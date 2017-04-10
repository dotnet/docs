// <Snippet1>
using System;
using System.Numerics;

public class Example
{
   public static void Main()
   {
      Complex[] values = { new Complex(2.5, 1.5), 
                           new Complex(2.5, -1.5), 
                           new Complex(-2.5, 1.5), 
                           new Complex(-2.5, -1.5) };
      foreach (Complex value in values)
         Console.WriteLine("Tan(Atan({0})) = {1}", 
                            value, Complex.Tan(Complex.Atan(value)));
   }
}
// The example displays the following output:
//       Tan(Atan((2.5, 1.5))) = (2.5, 1.5)
//       Tan(Atan((2.5, -1.5))) = (2.5, -1.5)
//       Tan(Atan((-2.5, 1.5))) = (-2.5, 1.5)
//       Tan(Atan((-2.5, -1.5))) = (-2.5, -1.5)
// </Snippet1>