using System;
using System.IO;
using System.Net;
using System.Net.Http;

class HttpClient_Example
{
// <Snippet1>
   static async void Main()
	 {
   
      // Create a New HttpClient object.
      HttpClient client = new HttpClient();
    
      // Call asynchronous network methods in a try/catch block to handle exceptions
      try	
      {
         HttpResponseMessage response = await client.GetAsync("http://www.contoso.com/");
         response.EnsureSuccessStatusCode();
         string responseBody = await response.Content.ReadAsStringAsync();
         // Above three lines can be replaced with new helper method below
         // string responseBody = await client.GetStringAsync(uri);

         Console.WriteLine(responseBody);
      }  
      catch(HttpRequestException e)
      {
         Console.WriteLine("\nException Caught!");	
         Console.WriteLine("Message :{0} ",e.Message);
      }

      // Need to call dispose on the HttpClient object
      // when done using it, so the app doesn't leak resources
      client.Dispose(true);
   }
// </Snippet1>			
}
