//How to: Cancel by Registering a Callback
//<snippet8>
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

class CancelWithCallback
{

   static void Main(string[] args)
   {
      var cts = new CancellationTokenSource();

      // Start cancelable task.
      Task t = Task.Run(() =>
      {
          DoWork(cts.Token);
      });

      Console.WriteLine("Press 'c' to cancel.");
      char ch = Console.ReadKey(true).KeyChar;
      if (ch == 'c')
      {
          cts.Cancel();
      }
      Console.WriteLine("Press any key to exit.");
      Console.ReadKey();
      cts.Dispose();
   }

   static void DoWork(CancellationToken token)
   {
      WebClient wc = new WebClient();

      // Create an event handler to receive the result.
      wc.DownloadStringCompleted += (obj, e) =>
      {
          // Checks status of WebClient, not external token
          if (!e.Cancelled)
          {
              Console.WriteLine(e.Result + "\r\nPress any key.");
          }
          else
              Console.WriteLine("Download was canceled.");
      };

      // Do not initiate download if the external token
      // has already been canceled.
      if (!token.IsCancellationRequested)
      {
          // Register the callback to a method that can unblock.
          // Dispose of the CancellationTokenRegistration object
          // after the callback has completed.
          using (CancellationTokenRegistration ctr = token.Register(() => wc.CancelAsync()))
          {
              Console.WriteLine("Starting request");
              wc.DownloadStringAsync(new Uri("http://www.contoso.com"));
          }
      }
   }
}
//</snippet8>
