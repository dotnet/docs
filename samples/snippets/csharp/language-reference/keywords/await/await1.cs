using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      string[] args = Environment.GetCommandLineArgs();
      if (args.Length > 1)
         GetPageSizeAsync(args[1]).Wait();
      else
         Console.WriteLine("Enter at least one URL on the command line.");
   }

   private static async Task GetPageSizeAsync(string url)  
   {  
       var client = new HttpClient();  
       var uri = new Uri(Uri.EscapeUriString(url));
       byte[] urlContents = await client.GetByteArrayAsync(uri);
       Console.WriteLine($"{url}: {urlContents.Length/2:N0} characters");  
   }  
}
// The following call from the command line:
//    await1 http://docs.microsoft.com
// displays output like the following: 
//   http://docs.microsoft.com: 7,967 characters


