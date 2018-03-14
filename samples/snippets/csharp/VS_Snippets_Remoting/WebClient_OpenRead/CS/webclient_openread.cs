// System.Net.WebClient.OpenRead

/*
This program demonstrates the 'OpenRead' method of 'WebClient' class.
It creates a URI to access a web resource. It then invokes 'OpenRead' tp obtain a 'Stream'
instance which is used to retrieve the web page data. The data read from the stream is then 
displayed on the console.
*/

using System;
using System.Net;
using System.IO;

public class WebClient_OpenRead 
{
	public static void Main() 
	{	
		try 
		{
			Console.Write("\nPlease enter a URI (e.g. http://www.contoso.com): ");
			string uriString = Console.ReadLine();
// <Snippet1>			
			// Create a new WebClient instance.
			WebClient myWebClient = new WebClient();
			// Download home page data. 
			Console.WriteLine("Accessing {0} ...",  uriString);						
			// Open a stream to point to the data stream coming from the Web resource.
			Stream myStream = myWebClient.OpenRead(uriString);

			Console.WriteLine("\nDisplaying Data :\n");
			StreamReader sr = new StreamReader(myStream);
			Console.WriteLine(sr.ReadToEnd());


			// Close the stream. 
			myStream.Close();
// </Snippet1>
		} 
		catch (WebException e) 
		{
			// Display the exception.
			Console.WriteLine ("Webresource access failed!!! WebException : "+ e.Message );						
		}
		catch (Exception e) 
		{
			// Display the exception.
			Console.WriteLine ("The following general exception was raised: "+ e.Message );
		}
	}
}

