// <Snippet1>
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class Example
{
   private static Object lockObj = new Object();
   private static Object rndLock = new Object();

   public static void Main()
   {
      Random rnd = new Random();
      var tasks = new List<Task<Double>>();
      ShowThreadInformation("Application");

      Task<Double> t = Task.Run( () => { ShowThreadInformation("Main Task(Task #" + Task.CurrentId.ToString() + ")");
                                         for (int ctr = 1; ctr <= 20; ctr++)
                                           tasks.Add(Task.Factory.StartNew(
                                              () => { ShowThreadInformation("Task #" + Task.CurrentId.ToString());
                                                      long s = 0;
                                                      for (int n = 0; n <= 999999; n++) {
                                                         lock (rndLock) {
                                                            s += rnd.Next(1, 1000001);
                                                         }
                                                      }
                                                      return s/1000000.0;
                                                    } ));

                                        Task.WaitAll(tasks.ToArray());
                                        Double grandTotal = 0;
                                        Console.WriteLine("Means of each task: ");
                                        foreach (var child in tasks) {
                                           Console.WriteLine("   {0}", child.Result);
                                           grandTotal += child.Result;
                                        }
                                        Console.WriteLine();
                                        return grandTotal / 20;
                                   } );
      Console.WriteLine("Mean of Means: {0}", t.Result);
   }

  private static void ShowThreadInformation(String taskName)
  {
      String msg = null;
      Thread thread = Thread.CurrentThread;
      lock(lockObj) {
         msg = String.Format("{0} thread information\n", taskName) +
               String.Format("   Background: {0}\n", thread.IsBackground) +
               String.Format("   Thread Pool: {0}\n", thread.IsThreadPoolThread) +
               String.Format("   Thread ID: {0}\n", thread.ManagedThreadId);
      }
      Console.WriteLine(msg);
   }
}
// The example displays output like the following:
//       Application thread information
//          Background: False
//          Thread Pool: False
//          Thread ID: 1
//
//       Main Task(Task #1) thread information
//          Background: True
//          Thread Pool: True
//          Thread ID: 3
//
//       Task #2 thread information
//          Background: True
//          Thread Pool: True
//          Thread ID: 4
//
//       Task #4 thread information
//          Background: True
//          Thread Pool: True
//          Thread ID: 10
//
//       Task #3 thread information
//          Background: True
//          Thread Pool: True
//          Thread ID: 9
//
//       Task #5 thread information
//          Background: True
//          Thread Pool: True
//          Thread ID: 3
//
//       Task #7 thread information
//          Background: True
//          Thread Pool: True
//          Thread ID: 5
//
//       Task #6 thread information
//          Background: True
//          Thread Pool: True
//          Thread ID: 7
//
//       Task #8 thread information
//          Background: True
//          Thread Pool: True
//          Thread ID: 6
//
//       Task #9 thread information
//          Background: True
//          Thread Pool: True
//          Thread ID: 8
//
//       Task #10 thread information
//          Background: True
//          Thread Pool: True
//          Thread ID: 9
//
//       Task #11 thread information
//          Background: True
//          Thread Pool: True
//          Thread ID: 10
//
//       Task #12 thread information
//          Background: True
//          Thread Pool: True
//          Thread ID: 6
//
//       Task #13 thread information
//          Background: True
//          Thread Pool: True
//          Thread ID: 4
//
//       Task #14 thread information
//          Background: True
//          Thread Pool: True
//          Thread ID: 3
//
//       Task #15 thread information
//          Background: True
//          Thread Pool: True
//          Thread ID: 7
//
//       Task #16 thread information
//          Background: True
//          Thread Pool: True
//          Thread ID: 5
//
//       Task #17 thread information
//          Background: True
//          Thread Pool: True
//          Thread ID: 8
//
//       Task #18 thread information
//          Background: True
//          Thread Pool: True
//          Thread ID: 9
//
//       Task #19 thread information
//          Background: True
//          Thread Pool: True
//          Thread ID: 10
//
//       Task #20 thread information
//          Background: True
//          Thread Pool: True
//          Thread ID: 4
//
//       Task #21 thread information
//          Background: True
//          Thread Pool: True
//          Thread ID: 7
//
//       Means of each task:
//          500038.740584
//          499810.422703
//          500217.558077
//          499868.534688
//          499295.505866
//          499893.475772
//          499601.454469
//          499828.532502
//          499606.183978
//          499700.276056
//          500415.894952
//          500005.874751
//          500042.237016
//          500092.764753
//          499998.798267
//          499623.054718
//          500018.784823
//          500286.865993
//          500052.68285
//          499764.363303
//
//       Mean of Means: 499908.10030605
// </Snippet1>
