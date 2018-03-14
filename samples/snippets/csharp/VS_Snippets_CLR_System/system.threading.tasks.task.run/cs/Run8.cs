// <Snippet8>
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      var tasks = new List<Task<int>>();
      var source = new CancellationTokenSource();
      var token = source.Token;
      int completedIterations = 0;

      for (int n = 0; n <= 19; n++)
         tasks.Add(Task.Run( () => { int iterations = 0;
                                     for (int ctr = 1; ctr <= 2000000; ctr++) {
                                         if (token.IsCancellationRequested)
                                            return iterations;
                                         iterations++;
                                     }
                                     Interlocked.Increment(ref completedIterations);
                                     if (completedIterations >= 10)
                                        source.Cancel();
                                     return iterations; }, token));

      Console.WriteLine("Waiting for the first 10 tasks to complete...\n");
      try  {
         Task.WaitAll(tasks.ToArray());
      }
      catch (AggregateException) {
         Console.WriteLine("Status of tasks:\n");
         Console.WriteLine("{0,10} {1,20} {2,14:N0}", "Task Id",
                           "Status", "Iterations");
         foreach (var t in tasks)
            Console.WriteLine("{0,10} {1,20} {2,14}",
                              t.Id, t.Status,
                              t.Status != TaskStatus.Canceled ? t.Result.ToString("N0") : "n/a");
      }
   }
}
// The example displays output like the following:
//    Status of tasks:
//
//       Task Id               Status     Iterations
//             1      RanToCompletion      2,000,000
//             2      RanToCompletion      2,000,000
//             3      RanToCompletion      2,000,000
//             4      RanToCompletion      2,000,000
//             5      RanToCompletion      2,000,000
//             6      RanToCompletion      2,000,000
//             7      RanToCompletion      2,000,000
//             8      RanToCompletion      2,000,000
//             9      RanToCompletion      2,000,000
//            10      RanToCompletion      1,658,326
//            11      RanToCompletion      1,988,506
//            12      RanToCompletion      2,000,000
//            13      RanToCompletion      1,942,246
//            14      RanToCompletion        950,108
//            15      RanToCompletion      1,837,832
//            16      RanToCompletion      1,687,182
//            17      RanToCompletion        194,548
//            18             Canceled    Not Started
//            19             Canceled    Not Started
//            20             Canceled    Not Started
// </Snippet8>
