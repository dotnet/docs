// <Snippet7>
using System;

public class Example
{
   public static void Main()
   {
      float[] values= { Single.MaxValue, 16.354e-12F, 15.098123F, 0F, 
                        -19.069713F, -15.058e17F, Single.MinValue };
      foreach (float value in values)
         Console.WriteLine("Abs({0}) = {1}", value, Math.Abs(value));
   }
}
// The example displays the following output:
//       Abs(3.402823E+38) = 3.402823E+38
//       Abs(1.6354E-11) = 1.6354E-11
//       Abs(15.09812) = 15.09812
//       Abs(0) = 0
//       Abs(-19.06971) = 19.06971
//       Abs(-1.5058E+18) = 1.5058E+18
//       Abs(-3.402823E+38) = 3.402823E+38
// </Snippet7>

