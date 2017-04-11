// System.Net.HttpWebResponse.Headers

/* This program demonstrates the 'Headers' property of the 'HttpWebResponse' class
It creates a web request and queries for a response.It then displays all the response headers 
onto the console. */

using System;
using System.Net;

class HttpWebResponseSnippet 
{
    public static void Main(string[] args) 
	{
		if (args.Length < 1) 
		{	
			Console.WriteLine("\nPlease enter the url as command line parameter:");
			Console.WriteLine("Example:");
			Console.WriteLine("HttpWebResponse_Headers http://www.microsoft.com/net/");
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
				// Creates an HttpWebRequest for the specified URL. 
				HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url); 
				// Sends the HttpWebRequest and waits for response.
				HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse(); 
				                        
				// Displays all the headers present in the response received from the URI.
				Console.WriteLine("\r\nThe following headers were received in the response:");
				// Displays each header and it's key associated with the response.
				for(int i=0; i < myHttpWebResponse.Headers.Count; ++i)  
					Console.WriteLine("\nHeader Name:{0}, Value :{1}",myHttpWebResponse.Headers.Keys[i],myHttpWebResponse.Headers[i]); 
				// Releases the resources of the response.
				myHttpWebResponse.Close(); 
// </Snippet1>
	    	} 
		catch(WebException e) 
		   {
		       Console.WriteLine("\r\nWebException Raised. The following error occured : {0}",e.Status); 
           }
		catch(Exception e)
		{
			Console.WriteLine("\nThe following Exception was raised : {0}",e.Message);
		}
	}
}