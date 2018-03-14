/*System.Net.WebRequest.RequestUri
 * This program demonstrates the 'RequestUri' property of the 'WebRequest' Class 
 Here the 'RequestUri' property displays the request Uri name to the console.*/
using System;
using System.IO;
using System.Net;
using System.Text;

class WebReq
{
	static void Main()
	{
		try	
		{
// <Snippet1>
			// Create a new WebRequest Object to the mentioned URL.
			WebRequest myWebRequest=WebRequest.Create("http://www.contoso.com");
			Console.WriteLine("\nThe Uri that was requested is {0}",myWebRequest.RequestUri);
			// Assign the response object of 'WebRequest' to a 'WebResponse' variable.
			WebResponse myWebResponse=myWebRequest.GetResponse();
			// Get the stream containing content returned by the server.
			Stream streamResponse=myWebResponse.GetResponseStream();
			Console.WriteLine("\nThe Uri that responded to the WebRequest is '{0}'",myWebResponse.ResponseUri);
      StreamReader reader = new StreamReader (streamResponse);
			// Read the content.
      string responseFromServer = reader.ReadToEnd ();
      // Display the content.
      Console.WriteLine("\nThe HTML Contents received:");
      Console.WriteLine (responseFromServer);
      // Cleanup the streams and the response.
      reader.Close ();
      streamResponse.Close ();
      myWebResponse.Close ();
// </Snippet1>
		}

		catch(WebException e)
		{
			Console.WriteLine("\nWebException is raised. ");
			Console.WriteLine("\nThe Error Message is{0} ",e.Message);
			Console.WriteLine("\nStatus:{0}",e.Status);
		}
		catch(Exception e)
		{
			
			Console.WriteLine("\nException is raised ");
			Console.WriteLine("\nMessage:{0} ",e.Message);
		}
	}
}

