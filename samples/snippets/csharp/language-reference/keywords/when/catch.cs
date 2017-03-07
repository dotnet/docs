using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
   static void Main()
   {
      Console.WriteLine(MakeRequest().Result);
   }

   public static async Task<string> MakeRequest()
   { 
       var client = new System.Net.Http.HttpClient();
       var streamTask = client.GetStringAsync("https://localHost:10000");
       try {
           var responseText = await streamTask;
           return responseText;
       } 
       catch (HttpRequestException e) when (e.Message.Contains("301")) {
           return "Site Moved";
       }
       catch (HttpRequestException e) when (e.Message.Contains("404")) {
           return "Page Not Found";
       }
       catch (HttpRequestException e) {
           return e.Message;
       }
   }
}
