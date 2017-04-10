// <Snippet10>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

public class SimpleWebExample
{
  public Task<string[]> GetWordCountsSimplified(string[] urls, string name,
                                                CancellationToken token)
  {
      TaskCompletionSource<string[]> tcs = new TaskCompletionSource<string[]>();
      WebClient[] webClients = new WebClient[urls.Length];
      object m_lock = new object();
      int count = 0;
      List<string> results = new List<string>();

      // If the user cancels the CancellationToken, then we can use the
      // WebClient's ability to cancel its own async operations.
      token.Register(() =>
      {
          foreach (var wc in webClients)
          {
              if (wc != null)
                  wc.CancelAsync();
          }
      });


      for (int i = 0; i < urls.Length; i++)
      {
          webClients[i] = new WebClient();

          #region callback
          // Specify the callback for the DownloadStringCompleted
          // event that will be raised by this WebClient instance.
          webClients[i].DownloadStringCompleted += (obj, args) =>
          {

              // Argument validation and exception handling omitted for brevity.

              // Split the string into an array of words,
              // then count the number of elements that match
              // the search term.
              string[] words = args.Result.Split(' ');
              string NAME = name.ToUpper();
              int nameCount = (from word in words.AsParallel()
                               where word.ToUpper().Contains(NAME)
                               select word)
                              .Count();

              // Associate the results with the url, and add new string to the array that
              // the underlying Task object will return in its Result property.
              lock (m_lock)
              {
                 results.Add(String.Format("{0} has {1} instances of {2}", args.UserState, nameCount, name));

                 // If this is the last async operation to complete,
                 // then set the Result property on the underlying Task.
                 count++;
                 if (count == urls.Length)
                 {
                    tcs.TrySetResult(results.ToArray());
                 }
              }
          };
          #endregion

          // Call DownloadStringAsync for each URL.
          Uri address = null;
          address = new Uri(urls[i]);
          webClients[i].DownloadStringAsync(address, address);

      } // end for

      // Return the underlying Task. The client code
      // waits on the Result property, and handles exceptions
      // in the try-catch block there.
      return tcs.Task;
   }
}
// </Snippet10>

public class Example
{
   public static void Main()
   {
      string[] urls = {"http://www.microsoft.com",
                       "http://www.google.com",
                       "http://www.amazon.com",
                       "http://www.adobe.com" };
      string searchTerm = "investor";
      var ex = new SimpleWebExample();
      var t = ex.GetWordCountsSimplified(urls, searchTerm, CancellationToken.None);
      t.Wait();
      foreach (var value in t.Result)
         Console.WriteLine(value);

      Console.ReadLine();
   }
}