//<Snippet10>
using System;
using System.Threading;
using System.Threading.Tasks;

class CancelNewStyleEvents
{
   // New-style MRESlim that supports unified cancellation
   // in its Wait methods.
   static ManualResetEventSlim mres = new ManualResetEventSlim(false);

   static void Main()
   {
      var cts = new CancellationTokenSource();

      // Pass the same token source to the delegate and to the task instance.
      Task.Run(() => DoWork(cts.Token), cts.Token);
      Console.WriteLine("Press c to cancel, p to pause, or s to start/restart,");
      Console.WriteLine("or any other key to exit.");

      // New-style UI thread.
         bool goAgain = true;
         while (goAgain)
         {
             char ch = Console.ReadKey(true).KeyChar;

             switch (ch)
             {
                 case 'c':
                     // Token can only be canceled once.
                     cts.Cancel();
                     break;
                 case 'p':
                     mres.Reset();
                     break;
                 case 's':
                     mres.Set();
                     break;
                 default:
                     goAgain = false;
                     break;
             }

             Thread.Sleep(100);
         }
         cts.Dispose();
     }

     static void DoWork(CancellationToken token)
     {

         while (true)
         {
             if (token.IsCancellationRequested)
             {
                 Console.WriteLine("Canceled while running.");
                 token.ThrowIfCancellationRequested();
             }

             // Wait on the event to be signaled
             // or the token to be canceled,
             // whichever comes first. The token
             // will throw an exception if it is canceled
             // while the thread is waiting on the event.
             //<snippet6>
             try
             {
                 // mres is a ManualResetEventSlim
                 mres.Wait(token);
             }
             catch (OperationCanceledException)
             {
                 // Throw immediately to be responsive. The
                 // alternative is to do one more item of work,
                 // and throw on next iteration, because
                 // IsCancellationRequested will be true.
                 Console.WriteLine("The wait operation was canceled.");
                 throw;
             }

             Console.Write("Working...");
             // Simulating work.
             Thread.SpinWait(500000);
             //</snippet6>
         }
     }
 }
 //</Snippet10>
