// <Snippet6>
using System;
using System.Collections.Generic;

public class Example
{
   public static void Main()
   {
      Random rnd = new Random();
      int[]  numbers = new int[4];
      int total = 0;
      for (int ctr = 0; ctr <= 2; ctr++) {
         int number = rnd.Next(1001);
         numbers[ctr] = number;
         total += number;
      }   
      numbers[3] = total;
      object[] values = new object[numbers.Length];
      numbers.CopyTo(values, 0);
      Console.WriteLine("{0} + {1} + {2} = {3}", values);   
   }
}
// The example displays output like the following:
//        477 + 956 + 901 = 2334
// </Snippet6>
