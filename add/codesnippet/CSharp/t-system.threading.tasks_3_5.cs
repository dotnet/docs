using System;
using System.Threading;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      var tasks = new Task[3];
      var rnd = new Random();
      for (int ctr = 0; ctr <= 2; ctr++)
         tasks[ctr] = Task.Run( () => Thread.Sleep(rnd.Next(500, 3000)));

      try {
         int index = Task.WaitAny(tasks);
         Console.WriteLine("Task #{0} completed first.\n", tasks[index].Id);
         Console.WriteLine("Status of all tasks:");
         foreach (var t in tasks)
            Console.WriteLine("   Task #{0}: {1}", t.Id, t.Status);
      }
      catch (AggregateException) {
         Console.WriteLine("An exception occurred.");
      }
   }
}
// The example displays output like the following:
//     Task #1 completed first.
//     
//     Status of all tasks:
//        Task #3: Running
//        Task #1: RanToCompletion
//        Task #4: Running