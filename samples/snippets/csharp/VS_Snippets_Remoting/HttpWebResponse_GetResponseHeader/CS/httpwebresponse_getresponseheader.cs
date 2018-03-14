// System.Net.HttpWebResponse.GetResponseHeader

/* This program demonstrates the 'GetResponseHeader' method of the 'HttpWebResponse' class
It creates a web request and queries for a response.If the site requires authentication it 
will respond with a challenge string which is extracted using 'GetResponse()' method.*/

using System;
using System.Net;

class HttpWebResponseSnippet 
{
    public static void Main(string[] args) 
	{
		if (args.Length < 1) 
		{	
			Console.WriteLine("\nPlease enter a protected resource url as command line parameter:");
			Console.WriteLine("Example:");
			Console.WriteLine("HttpWebResponse_GetResponseHeader http://www.microsoft.com/net/");
		} 
		else 
		{
			GetPage(args[0]);
		}
		Console.WriteLine("Press any key to continue...");
		Console.ReadLine();
		return;
    }

// <Snippet1>         
   public static void GetPage(String url) 
	{
	try 
 			{	
				Uri ourUri = new Uri(url);
				// Creates an HttpWebRequest for the specified URL. 
				HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(ourUri); 
				HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
				Console.WriteLine("\nThe server did not issue any challenge.  Please try again with a protected resource URL.");
				// Releases the resources of the response.
				myHttpWebResponse.Close(); 
			} 
		catch(WebException e) 
		   {
			    HttpWebResponse response = (HttpWebResponse)e.Response;
				if (response != null)
				{
					if (response.StatusCode == HttpStatusCode.Unauthorized)
					{
						string challenge = null;
						challenge= response.GetResponseHeader("WWW-Authenticate");
						if (challenge != null)
							Console.WriteLine("\nThe following challenge was raised by the server:{0}",challenge);
					}
					else
						Console.WriteLine("\nThe following WebException was raised : {0}",e.Message);
				}
				else
					Console.WriteLine("\nResponse Received from server was null");

			}
		catch(Exception e)
		{
			Console.WriteLine("\nThe following Exception was raised : {0}",e.Message);
		}
	}
}
// </Snippet1>