// <Snippet1>
using System;
using System.Threading;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      Task[] tasks = new Task[5];
      for (int ctr = 0; ctr <= 4; ctr++) {
         int factor = ctr;
         tasks[ctr] = Task.Run(() => Thread.Sleep(factor * 250 + 50));
      }
      int index = Task.WaitAny(tasks);
      Console.WriteLine("Wait ended because task #{0} completed.",
                        tasks[index].Id);
      Console.WriteLine("\nCurrent Status of Tasks:");
      foreach (var t in tasks)
         Console.WriteLine("   Task {0}: {1}", t.Id, t.Status);
   }
}
// The example displays output like the following:
//       Wait ended because task #1 completed.
//
//       Current Status of Tasks:
//          Task 1: RanToCompletion
//          Task 2: Running
//          Task 3: Running
//          Task 4: Running
//          Task 5: Running
// </Snippet1>
