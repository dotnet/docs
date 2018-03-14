// <Snippet1>
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      var tasks = new List<Task<long>>();
      for (int ctr = 1; ctr <= 10; ctr++) {
         int delayInterval = 18 * ctr;
         tasks.Add(Task.Run(async () => { long total = 0;
                                          await Task.Delay(delayInterval);
                                          var rnd = new Random();
                                          // Generate 1,000 random numbers.
                                          for (int n = 1; n <= 1000; n++)
                                             total += rnd.Next(0, 1000);
                                          return total; } ));
      }
      var continuation = Task.WhenAll(tasks);
      try {
         continuation.Wait();
      }
      catch (AggregateException)
      { }
   
      if (continuation.Status == TaskStatus.RanToCompletion) {
         long grandTotal = 0;
         foreach (var result in continuation.Result) {
            grandTotal += result;
            Console.WriteLine("Mean: {0:N2}, n = 1,000", result/1000.0);
         }
   
         Console.WriteLine("\nMean of Means: {0:N2}, n = 10,000",
                           grandTotal/10000);
      }
      // Display information on faulted tasks.
      else {
         foreach (var t in tasks) {
            Console.WriteLine("Task {0}: {1}", t.Id, t.Status);
         }
      }
   }
}
// The example displays output like the following:
//       Mean: 506.34, n = 1,000
//       Mean: 504.69, n = 1,000
//       Mean: 489.32, n = 1,000
//       Mean: 505.96, n = 1,000
//       Mean: 515.31, n = 1,000
//       Mean: 499.94, n = 1,000
//       Mean: 496.92, n = 1,000
//       Mean: 508.58, n = 1,000
//       Mean: 494.88, n = 1,000
//       Mean: 493.53, n = 1,000
//
//       Mean of Means: 501.55, n = 10,000
// </Snippet1>
