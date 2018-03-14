// <Snippet1>
using System;
using System.Threading;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      Console.WriteLine("Application executing on thread {0}",
                        Thread.CurrentThread.ManagedThreadId);
      var asyncTask = Task.Run( () => {  Console.WriteLine("Task {0} (asyncTask) executing on Thread {1}",
                                                           Task.CurrentId,
                                                           Thread.CurrentThread.ManagedThreadId);
                                         long sum = 0;
                                         for (int ctr = 1; ctr <= 1000000; ctr++ )
                                            sum += ctr;
                                         return sum;
                                      });
      var syncTask = new Task<long>( () =>  { Console.WriteLine("Task {0} (syncTask) executing on Thread {1}",
                                                                 Task.CurrentId,
                                                                 Thread.CurrentThread.ManagedThreadId);
                                              long sum = 0;
                                              for (int ctr = 1; ctr <= 1000000; ctr++ )
                                                 sum += ctr;
                                              return sum;
                                            });
      syncTask.RunSynchronously();
      Console.WriteLine();
      Console.WriteLine("Task {0} returned {1:N0}", syncTask.Id, syncTask.Result);
      Console.WriteLine("Task {0} returned {1:N0}", asyncTask.Id, asyncTask.Result);
   }
}
// The example displays the following output:
//       Application executing on thread 1
//       Task 1 (syncTask) executing on Thread 1
//       Task 2 (asyncTask) executing on Thread 3
//       1 status: RanToCompletion
//       2 status: RanToCompletion
//
//       Task 2 returned 500,000,500,000
//       Task 1 returned 500,000,500,000
// </Snippet1>
