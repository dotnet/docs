// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      float result1 = 1.867e38f + 2.385e38f;
      Console.WriteLine("{0} (Positive Infinity: {1})", 
                        result1, Single.IsPositiveInfinity(result1));
      
      float result2 = 1.5935e25f * 7.948e20f;
      Console.WriteLine("{0} (Positive Infinity: {1})", 
                        result2, Single.IsPositiveInfinity(result2));
   }
}
// The example displays the following output:
//    Infinity (Positive Infinity: True)
//    Infinity (Positive Infinity: True)
// </Snippet1>
