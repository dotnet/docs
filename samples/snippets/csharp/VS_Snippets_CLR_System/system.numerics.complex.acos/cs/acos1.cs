// <Snippet1>
using System;
using System.Numerics;

public class Example
{
   public static void Main()
   {
      Complex[] values = { new Complex(.5, 2), 
                           new Complex(.5, -2),
                           new Complex(-.5, 2),
                           new Complex(-.3, -.8) };
      foreach (Complex value in values)
         Console.WriteLine("Cos(ACos({0})) = {1}", value, 
                           Complex.Cos(Complex.Acos(value)));
   }
}
// The example displays the following output:
//       Cos(ACos((0.5, 2))) = (0.5, 2)
//       Cos(ACos((0.5, -2))) = (0.5, -2)
//       Cos(ACos((-0.5, 2))) = (-0.5, 2)
//       Cos(ACos((-0.3, -0.8))) = (-0.3, -0.8)
// </Snippet1>