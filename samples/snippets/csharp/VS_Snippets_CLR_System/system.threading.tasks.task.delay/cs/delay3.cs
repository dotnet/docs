// <Snippet3>
using System;
using System.Threading;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      CancellationTokenSource source = new CancellationTokenSource();

      var t = Task.Run(async delegate
              {
                 await Task.Delay(1000, source.Token);
                 return 42;
              });
      source.Cancel();
      try {
         t.Wait();
      }
      catch (AggregateException ae) {
         foreach (var e in ae.InnerExceptions)
            Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message);
      }
      Console.Write("Task t Status: {0}", t.Status);
      if (t.Status == TaskStatus.RanToCompletion)
         Console.Write(", Result: {0}", t.Result);
      source.Dispose();
   }
}
// The example displays the following output:
//       TaskCanceledException: A task was canceled.
//       Task t Status: Canceled
// </Snippet3>
