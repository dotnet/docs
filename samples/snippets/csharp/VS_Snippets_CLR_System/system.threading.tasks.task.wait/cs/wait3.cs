// <Snippet3>
using System;
using System.Threading;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      CancellationTokenSource ts = new CancellationTokenSource();

      Task t = Task.Run( () => { Console.WriteLine("Calling Cancel...");
                                 ts.Cancel();
                                 Task.Delay(5000).Wait();
                                 Console.WriteLine("Task ended delay...");
                               });
      try {
         Console.WriteLine("About to wait for the task to complete...");
         t.Wait(ts.Token);
      }
      catch (OperationCanceledException e) {
         Console.WriteLine("{0}: The wait has been canceled. Task status: {1:G}",
                           e.GetType().Name, t.Status);
         Thread.Sleep(6000);
         Console.WriteLine("After sleeping, the task status:  {0:G}", t.Status);
      }
      ts.Dispose();
   }
}
// The example displays output like the following:
//    About to wait for the task to complete...
//    Calling Cancel...
//    OperationCanceledException: The wait has been canceled. Task status: Running
//    Task ended delay...
//    After sleeping, the task status:  RanToCompletion
// </Snippet3>
