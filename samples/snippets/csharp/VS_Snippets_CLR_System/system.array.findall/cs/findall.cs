// <Snippet1>
using System;
using System.Collections.Generic;

public class Example
{
   public static void Main()
   {
      // Get an array of n random integers.
      int[] values = GetArray(50, 0, 1000);
      int lBound = 300;
      int uBound = 600;
      int[] matchedItems = Array.FindAll(values, x =>  
                                       x >= lBound && x <= uBound);  
      for (int ctr = 0; ctr < matchedItems.Length; ctr++) {
         Console.Write("{0}  ", matchedItems[ctr]);
         if ((ctr + 1) % 12 == 0)
            Console.WriteLine();
      }
   }

   private static int[] GetArray(int n, int lower, int upper)
   {
      Random rnd = new Random();
      List<int> list = new List<int>();
      for (int ctr = 1; ctr <= n; ctr++)
         list.Add(rnd.Next(lower, upper + 1));

      return list.ToArray();
   }
}
// The example displays output similar to the following:
//       542  398  356  351  348  301  562  599  575  400  569  306
//       535  416  393  385
// </Snippet1>
