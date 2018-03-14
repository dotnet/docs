using System;
using System.IO;
using System.Net;
using System.Net.Http;

class HttpClientHandler_Example
{
// <Snippet1>
   static async void Main()
	 {
      // Create an HttpClientHandler object and set to use default credentials
      HttpClientHandler handler = new HttpClientHandler();
      handler.UseDefaultCredentials = true;

      // Create an HttpClient object
      HttpClient client = new HttpClient(handler);

      // Call asynchronous network methods in a try/catch block to handle exceptions
      try	
      {
         HttpResponseMessage response = await client.GetAsync("http://www.contoso.com/");

         response.EnsureSuccessStatusCode();

         string responseBody = await response.Content.ReadAsStringAsync();
         Console.WriteLine(responseBody);
       }  
       catch(HttpRequestException e)
       {
          Console.WriteLine("\nException Caught!");	
          Console.WriteLine("Message :{0} ",e.Message);
       }

       // Need to call dispose on the HttpClient and HttpClientHandler objects 
       // when done using them, so the app doesn't leak resources
       handler.Dispose(true);
       client.Dispose(true);
   }
// </Snippet1>			
}
