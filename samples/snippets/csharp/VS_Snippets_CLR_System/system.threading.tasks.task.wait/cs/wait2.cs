// <Snippet2>
using System;
using System.Threading;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      CancellationTokenSource cts = new CancellationTokenSource();
      CancellationToken token = cts.Token;
      
      Task.Run( () => {
                   cts.Cancel();
                   if (token.IsCancellationRequested)
                      Console.WriteLine("Cancellation requested in Task {0}.", 
                                        Task.CurrentId);
                } , token);
      Task t2 = Task.Run( () => {
                             for (int ctr = 0; ctr <= Int32.MaxValue; ctr++) 
                             {}
                             Console.WriteLine("Task {0} finished.",
                                               Task.CurrentId);
                          } );
      try {
         t2.Wait(token);
      }   
      catch (OperationCanceledException) {
         Console.WriteLine("OperationCanceledException in Task {0}: The operation was cancelled.",
                           t2.Id);
      }
      finally {
         cts.Dispose();
      }
   }
}
// The example displays the following output:
//       Cancellation requested in Task 1.
//       OperationCanceledException in Task 2: The operation was cancelled.
// </Snippet2>

