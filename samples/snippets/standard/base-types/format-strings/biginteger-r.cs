using System;
using System.Numerics;

public class Example
{
   public static void Main()
   {
      var value = BigInteger.Pow(Int64.MaxValue, 2);
      Console.WriteLine(value.ToString("R"));
   }
}
// The example displays the following output:
//      85070591730234615847396907784232501249
