// <Snippet2>
using System;

public class Example
{
   public static void Main()
   {
      Double value1 = 4.565e153;
      Double value2 = 6.9375e172;
      Double result = value1 * value2;
      Console.WriteLine("PositiveInfinity: {0}", 
                         Double.IsPositiveInfinity(result));
      Console.WriteLine("NegativeInfinity: {0}\n", 
                        Double.IsNegativeInfinity(result));

      value1 = -value1;
      result = value1 * value2;
      Console.WriteLine("PositiveInfinity: {0}", 
                         Double.IsPositiveInfinity(result));
      Console.WriteLine("NegativeInfinity: {0}", 
                        Double.IsNegativeInfinity(result));
   }
}                                                                 

// The example displays the following output:
//       PositiveInfinity: True
//       NegativeInfinity: False
//       
//       PositiveInfinity: False
//       NegativeInfinity: True
// </Snippet2>
