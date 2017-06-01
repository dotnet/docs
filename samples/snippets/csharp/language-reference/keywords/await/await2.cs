using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

class Example
{
   static void Main()
   {
      string[] args = Environment.GetCommandLineArgs();
      if (args.Length < 2)
         throw new ArgumentNullException("No URLs specified on the command line.");
      
      long characters = GetPageLengthsAsync(args).Result;
      Console.WriteLine($"{args.Length - 1} pages, {characters:N0} characters");
   }

   private static async Task<long> GetPageLengthsAsync(string[] args)
   {
      var client = new HttpClient();
      long pageLengths = 0;

      for (int ctr = 1; ctr < args.Length; ctr++) {
         var uri = new Uri(Uri.EscapeUriString(args[ctr]));
         string pageContents = await client.GetStringAsync(uri);
         Interlocked.Add(ref pageLengths, pageContents.Length);
      }
      return pageLengths;
   }
}
