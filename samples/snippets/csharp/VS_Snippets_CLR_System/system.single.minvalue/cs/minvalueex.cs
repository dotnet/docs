// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      float result1 = -8.997e37f + -2.985e38f;       
      Console.WriteLine("{0} (Negative Infinity: {1})", 
                        result1, Single.IsNegativeInfinity(result1));
      
      float result2 = -1.5935e25f * 7.948e32f;
      Console.WriteLine("{0} (Negative Infinity: {1})", 
                        result2, Single.IsNegativeInfinity(result2));
   }
}
// The example displays the following output:
//    -Infinity (Negative Infinity: True)
//    -Infinity (Negative Infinity: True)
// </Snippet1>
