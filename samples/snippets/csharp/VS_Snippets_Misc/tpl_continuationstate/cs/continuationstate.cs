// <snippet1> 
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

// Demonstrates how to associate state with task continuations.
class ContinuationState
{
   // Simluates a lengthy operation and returns the time at which
   // the operation completed.
   public static DateTime DoWork()
   {
      // Simulate work by suspending the current thread 
      // for two seconds.
      Thread.Sleep(2000);

      // Return the current time.
      return DateTime.Now;
   }

   static void Main(string[] args)
   {
      // Start a root task that performs work.
      Task<DateTime> t = Task<DateTime>.Run(delegate { return DoWork(); });

      // Create a chain of continuation tasks, where each task is 
      // followed by another task that performs work.
      List<Task<DateTime>> continuations = new List<Task<DateTime>>();
      for (int i = 0; i < 5; i++)
      {
         // Provide the current time as the state of the continuation.
         t = t.ContinueWith(delegate { return DoWork(); }, DateTime.Now);
         continuations.Add(t);
      }

      // Wait for the last task in the chain to complete.
      t.Wait();

      // Print the creation time of each continuation (the state object)
      // and the completion time (the result of that task) to the console.
      foreach (var continuation in continuations)
      {
         DateTime start = (DateTime)continuation.AsyncState;
         DateTime end = continuation.Result;

         Console.WriteLine("Task was created at {0} and finished at {1}.",
            start.TimeOfDay, end.TimeOfDay);
      }
   }
}

/* Sample output:
Task was created at 10:56:21.1561762 and finished at 10:56:25.1672062.
Task was created at 10:56:21.1610677 and finished at 10:56:27.1707646.
Task was created at 10:56:21.1610677 and finished at 10:56:29.1743230.
Task was created at 10:56:21.1610677 and finished at 10:56:31.1779883.
Task was created at 10:56:21.1610677 and finished at 10:56:33.1837083.
*/
// </snippet1> 