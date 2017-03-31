// <Snippet3>
using System;
using System.Collections.Generic;

public class Example
{
   public static void Main()
   {
      Double[] values = GetData();
      // Compute mean.
      Console.WriteLine("Sample mean: {0}, N = {1}",
                        GetMean(values), values.Length);
   }

   private static Double[] GetData()
   {
      Random rnd = new Random();
      List<Double> values = new List<Double>();
      for (int ctr = 1; ctr <= 200000000; ctr++) {
         values.Add(rnd.NextDouble());
         if (ctr % 10000000 == 0)
            Console.WriteLine("Retrieved {0:N0} items of data.",
                              ctr);
      }
      return values.ToArray();
   }

   private static Double GetMean(Double[] values)
   {
      Double sum = 0;
      foreach (var value in values)
         sum += value;

      return sum / values.Length;
   }
}
// The example displays output like the following:
//    Retrieved 10,000,000 items of data.
//    Retrieved 20,000,000 items of data.
//    Retrieved 30,000,000 items of data.
//    Retrieved 40,000,000 items of data.
//    Retrieved 50,000,000 items of data.
//    Retrieved 60,000,000 items of data.
//    Retrieved 70,000,000 items of data.
//    Retrieved 80,000,000 items of data.
//    Retrieved 90,000,000 items of data.
//    Retrieved 100,000,000 items of data.
//    Retrieved 110,000,000 items of data.
//    Retrieved 120,000,000 items of data.
//    Retrieved 130,000,000 items of data.
//
//    Unhandled Exception: OutOfMemoryException.
// </Snippet3>
