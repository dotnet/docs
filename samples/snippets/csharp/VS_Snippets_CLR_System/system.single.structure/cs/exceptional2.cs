// <Snippet2>
using System;

public class Example
{
   public static void Main()
   {
      float value1 = 3.065e35f;
      float value2 = 6.9375e32f;
      float result = value1 * value2;
      Console.WriteLine("PositiveInfinity: {0}", 
                         Single.IsPositiveInfinity(result));
      Console.WriteLine("NegativeInfinity: {0}\n", 
                        Single.IsNegativeInfinity(result));

      value1 = -value1;
      result = value1 * value2;
      Console.WriteLine("PositiveInfinity: {0}", 
                         Single.IsPositiveInfinity(result));
      Console.WriteLine("NegativeInfinity: {0}", 
                        Single.IsNegativeInfinity(result));
   }
}                                                                 

// The example displays the following output:
//       PositiveInfinity: True
//       NegativeInfinity: False
//       
//       PositiveInfinity: False
//       NegativeInfinity: True
// </Snippet2>
