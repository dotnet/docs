// <Snippet1>
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

class CancelWithCallback
{
   static void Main()
   {
      var cts = new CancellationTokenSource();
      var token = cts.Token;

      // Start cancelable task.
      Task t = Task.Run( () => {
                    WebClient wc = new WebClient();

                    // Create an event handler to receive the result.
                    wc.DownloadStringCompleted += (obj, e) => {
                               // Check status of WebClient, not external token.
                               if (!e.Cancelled) {
                                  Console.WriteLine("The download has completed:\n");
                                  Console.WriteLine(e.Result + "\n\nPress any key.");
                               }
                               else {
                                  Console.WriteLine("The download was canceled.");
                               }
                    };

                    // Do not initiate download if the external token
                    // has already been canceled.
                    if (!token.IsCancellationRequested) {
                       // Register the callback to a method that can unblock.
                       using (CancellationTokenRegistration ctr = token.Register(() => wc.CancelAsync()))
                       {
                          Console.WriteLine("Starting request\n");
                          wc.DownloadStringAsync(new Uri("http://www.contoso.com"));
                       }
                    }
               }, token);

      Console.WriteLine("Press 'c' to cancel.\n");
      char ch = Console.ReadKey().KeyChar;
      Console.WriteLine();
      if (ch == 'c')
         cts.Cancel();

      Console.WriteLine("Press any key to exit.");
      Console.ReadKey();
      cts.Dispose();
   }
}
// </Snippet1>
