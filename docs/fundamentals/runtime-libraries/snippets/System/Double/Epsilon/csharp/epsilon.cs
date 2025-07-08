// <Snippet5>
using System;

public class Example
{
   public static void Main()
   {
      double[] values = { 0, Double.Epsilon, Double.Epsilon * .5 };

      for (int ctr = 0; ctr <= values.Length - 2; ctr++)
      {
         for (int ctr2 = ctr + 1; ctr2 <= values.Length - 1; ctr2++)
         {
            Console.WriteLine($"{values[ctr]:r} = {values[ctr2]:r}: {values[ctr].Equals(values[ctr2])}");
         }
         Console.WriteLine();
      }
   }
}
// The example displays the following output:
//       0 = 4.94065645841247E-324: False
//       0 = 0: True
//
//       4.94065645841247E-324 = 0: False
// </Snippet5>
