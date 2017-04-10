// <Snippet3>
using System;

public class Example
{
   public static void Main()
   {
      Double value = .1;
      Double result1 = value * 10;
      Double result2 = 0;
      for (int ctr = 1; ctr <= 10; ctr++)
         result2 += value;

      Console.WriteLine(".1 * 10:           {0:R}", result1);
      Console.WriteLine(".1 Added 10 times: {0:R}", result2);
   }
}
// The example displays the following output:
//       .1 * 10:           1
//       .1 Added 10 times: 0.99999999999999989
// </Snippet3>
