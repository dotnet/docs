// System.Net.WebResponse.ContentLength;System.Net.WebResponse.ContentType

/* This program demonstrates the 'ContentLength' and 'ContentType' property of 'WebResponse' class
It creates a web request and queries for a response.It then prints the content length and content type
of the entity body in the response onto the console */

using System;
using System.Net;
using System.IO;
using System.Text;

class WebResponseSnippet 
{
    public static void Main(string[] args) 
    {
      if (args.Length < 1) 
		{	
			Console.WriteLine("\nPlease enter the Url as command line parameter:");
			Console.WriteLine("Example:");
			Console.WriteLine("WebResponse_ContentLength_Type http://www.microsoft.com/net/");
		} 
		else 
		{
			GetPage(args[0]);
		}
      Console.WriteLine("Press any key to continue...");
		Console.ReadLine();
      return;
    }

   public static void GetPage(String url) 
	{
	   try 
      {
// <Snippet1>
// <Snippet2>

                     // Create a 'WebRequest' with the specified url.
			WebRequest myWebRequest = WebRequest.Create("http://www.contoso.com"); 

			// Send the 'WebRequest' and wait for response.
			WebResponse myWebResponse = myWebRequest.GetResponse(); 

			// Display the content length and content type received as headers in the response object.
			Console.WriteLine("\nContent length :{0}, Content Type : {1}", 
			                             myWebResponse.ContentLength, 
			                             myWebResponse.ContentType);  
			
			// Release resources of response object.
			myWebResponse.Close(); 
			
// </Snippet1>
// </Snippet2>			
        	} 
		catch(WebException e) 
			{
            Console.WriteLine("\nWebException raised. Status is: {0}",e.Status); 
        	}
		catch(Exception e)
			{
			Console.WriteLine("\nThe following Exception was raised.Message is: {0}",e.Message);
			}
	}
}
