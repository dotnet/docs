//<snippet11>
using System;
using System.Threading;
using System.Threading.Tasks;

public struct Rectangle
{
   public int columns;
   public int rows;
}

class CancelByPolling
{
   static void Main()
   {
      var tokenSource = new CancellationTokenSource();
      // Toy object for demo purposes
      Rectangle rect = new Rectangle() { columns = 1000, rows = 500 };

      // Simple cancellation scenario #1. Calling thread does not wait
      // on the task to complete, and the user delegate simply returns
      // on cancellation request without throwing.
      Task.Run(() => NestedLoops(rect, tokenSource.Token), tokenSource.Token);

      // Simple cancellation scenario #2. Calling thread does not wait
      // on the task to complete, and the user delegate throws
      // OperationCanceledException to shut down task and transition its state.
      // Task.Run(() => PollByTimeSpan(tokenSource.Token), tokenSource.Token);

      Console.WriteLine("Press 'c' to cancel");
      if (Console.ReadKey(true).KeyChar == 'c') {
          tokenSource.Cancel();
          Console.WriteLine("Press any key to exit.");
      }

      Console.ReadKey();
      tokenSource.Dispose();
  }

   //<snippet3>
   static void NestedLoops(Rectangle rect, CancellationToken token)
   {
      for (int x = 0; x < rect.columns && !token.IsCancellationRequested; x++) {
         for (int y = 0; y < rect.rows; y++) {
            // Simulating work.
            Thread.SpinWait(5000);
            Console.Write("{0},{1} ", x, y);
         }

         // Assume that we know that the inner loop is very fast.
         // Therefore, checking once per row is sufficient.
         if (token.IsCancellationRequested) {
            // Cleanup or undo here if necessary...
            Console.WriteLine("\r\nCancelling after row {0}.", x);
            Console.WriteLine("Press any key to exit.");
            // then...
            break;
            // ...or, if using Task:
            // token.ThrowIfCancellationRequested();
         }
      }
   }
   //</snippet3>
}
//</snippet11>
