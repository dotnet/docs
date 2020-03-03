using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

class HttpClient_Example
{
// <Snippet1>
   // HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
   static readonly HttpClient client = new HttpClient();
    
   static async Task Main()
   {
     // Call asynchronous network methods in a try/catch block to handle exceptions.
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
   }
// </Snippet1>			
}
