// <snippet1> 
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// Demonstrates how to use Task<TResult>.FromResult to create a task 
// that holds a pre-computed result.
class CachedDownloads
{
   // Holds the results of download operations.
   static ConcurrentDictionary<string, string> cachedDownloads =
      new ConcurrentDictionary<string, string>();

   // Asynchronously downloads the requested resource as a string.
   public static Task<string> DownloadStringAsync(string address)
   {
      // First try to retrieve the content from cache.
      string content;
      if (cachedDownloads.TryGetValue(address, out content))
      {
         return Task.FromResult<string>(content);
      }

      // If the result was not in the cache, download the 
      // string and add it to the cache.
      return Task.Run(async () =>
      {
         content = await new WebClient().DownloadStringTaskAsync(address);
         cachedDownloads.TryAdd(address, content);
         return content;
      });
   }

   static void Main(string[] args)
   {
      // The URLs to download.
      string[] urls = new string[]
      {
         "http://msdn.microsoft.com",
         "http://www.contoso.com",
         "http://www.microsoft.com"
      };

      // Used to time download operations.
      Stopwatch stopwatch = new Stopwatch();

      // Compute the time required to download the URLs.
      stopwatch.Start();
      var downloads = from url in urls
                      select DownloadStringAsync(url);
      Task.WhenAll(downloads).ContinueWith(results =>
      {
         stopwatch.Stop();

         // Print the number of characters download and the elapsed time.
         Console.WriteLine("Retrieved {0} characters. Elapsed time was {1} ms.",
            results.Result.Sum(result => result.Length),
            stopwatch.ElapsedMilliseconds);
      })
      .Wait();

      // Perform the same operation a second time. The time required
      // should be shorter because the results are held in the cache.
      stopwatch.Restart();
      downloads = from url in urls
                  select DownloadStringAsync(url);
      Task.WhenAll(downloads).ContinueWith(results =>
      {
         stopwatch.Stop();

         // Print the number of characters download and the elapsed time.
         Console.WriteLine("Retrieved {0} characters. Elapsed time was {1} ms.",
            results.Result.Sum(result => result.Length),
            stopwatch.ElapsedMilliseconds);
      })
      .Wait();
   }
}

/* Sample output:
Retrieved 27798 characters. Elapsed time was 1045 ms.
Retrieved 27798 characters. Elapsed time was 0 ms.
*/
// </snippet1>