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
      for (int col = 0; col < rect.columns && !token.IsCancellationRequested; col++) {
         // Assume that we know that the inner loop is very fast.
         // Therefore, polling once per column in the outer loop condition
         // is sufficient.
         for (int row = 0; row < rect.rows; row++) {
            // Simulating work.
            Thread.SpinWait(5_000);
            Console.Write("{0},{1} ", col, row);
         }
      }

      if (token.IsCancellationRequested) {
         // Cleanup or undo here if necessary...
         Console.WriteLine("\r\nCancelling before column {0}.", col);
         Console.WriteLine("Press any key to exit.");

         // If using Task:
         // token.ThrowIfCancellationRequested();
      }
   }
   //</snippet3>
}
//</snippet11>
