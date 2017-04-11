//<snippet4>
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

class Example
{
   EventHandler externalEvent;

   void Example1()
   {
      CancellationTokenSource cts = new CancellationTokenSource();
      externalEvent +=
         (sender, obj) => { cts.Cancel(); }; //wire up an external requester
      try {
          int val = LongRunningFunc(cts.Token);
      }
      catch (OperationCanceledException) {
          //cleanup after cancellation if required...
          Console.WriteLine("Operation was canceled as expected.");
      }
      finally {
         cts.Dispose();
      }

  }

  private static int LongRunningFunc(CancellationToken token)
  {
      Console.WriteLine("Long running method");
      int total = 0;
      for (int i = 0; i < 100000; i++)
      {
          for (int j = 0; j < 100000; j++)
          {
              total++;
          }
          if (token.IsCancellationRequested)
          { // observe cancellation
              Console.WriteLine("Cancellation observed.");
              throw new OperationCanceledException(token); // acknowledge cancellation
          }
      }
      Console.WriteLine("Done looping");
      return total;
   }

   static void Main()
   {
      Example ex = new Example();

      Thread t = new Thread(new ThreadStart(ex.Example1));
      t.Start();

      Console.WriteLine("Press 'c' to cancel.");
      if (Console.ReadKey(true).KeyChar == 'c')
          ex.externalEvent.Invoke(ex, new EventArgs());

      Console.WriteLine("Press enter to exit.");
      Console.ReadLine();
  }
}

class CancelWaitHandleMiniSnippetsForOverviewTopic
{

  static void CancelByCallback()
  {
      CancellationTokenSource cts = new CancellationTokenSource();
      CancellationToken token = cts.Token;
      WebClient wc = new WebClient();

      // To request cancellation on the token
      // will call CancelAsync on the WebClient.
      token.Register(() => wc.CancelAsync());

      Console.WriteLine("Starting request");
      wc.DownloadStringAsync(new Uri("http://www.contoso.com"));
   }
}
//</snippet4>
