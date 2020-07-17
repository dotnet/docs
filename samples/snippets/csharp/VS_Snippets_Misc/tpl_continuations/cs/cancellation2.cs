// <Snippet8>
using System;
using System.Threading;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      var cts = new CancellationTokenSource();
      CancellationToken token = cts.Token;
      cts.Cancel();

      var t = Task.FromCanceled(token);
      var continuation = t.ContinueWith( (antecedent) => {
                                            Console.WriteLine("The continuation is running.");
                                          } , TaskContinuationOptions.NotOnCanceled);
      try {
         t.Wait();
      }
      catch (AggregateException ae) {
         foreach (var ie in ae.InnerExceptions)
            Console.WriteLine("{0}: {1}", ie.GetType().Name, ie.Message);

         Console.WriteLine();
      }
      finally {
         cts.Dispose();
      }

      Console.WriteLine("Task {0}: {1:G}", t.Id, t.Status);
      Console.WriteLine("Task {0}: {1:G}", continuation.Id,
                        continuation.Status);
   }
}
// The example displays the following output:
//       TaskCanceledException: A task was canceled.
//
//       Task 1: Canceled
//       Task 2: Canceled
// </Snippet8>
