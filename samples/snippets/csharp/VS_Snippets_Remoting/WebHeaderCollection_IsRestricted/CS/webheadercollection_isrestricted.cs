/*This program demonstrates the "IsRestricted" method of "WebHeaderCollection".
  It checks if the first header returned in the response is a restricted header or not.
*/

using System;
using System.Net;

public class CheckRestricted {

	public static void Main() {
// <Snippet1>
		try {
			// Create a web request for "www.msn.com".
		 	HttpWebRequest myHttpWebRequest = (HttpWebRequest) WebRequest.Create("http://www.msn.com");

			// Get the associated response for the above request.
		 	HttpWebResponse myHttpWebResponse = (HttpWebResponse) myHttpWebRequest.GetResponse();

			// Get the headers associated with the response.
			WebHeaderCollection myWebHeaderCollection = myHttpWebResponse.Headers;
			
			for (int i = 0; i < myWebHeaderCollection.Count;i++)	
			{
  			// Check if the first response header is restricted.
			if(WebHeaderCollection.IsRestricted(myWebHeaderCollection.AllKeys[i]))
				Console.WriteLine("'{0}' is a restricted header", myWebHeaderCollection.AllKeys[i]);
			else
				Console.WriteLine("'{0}' is not a restricted header", myWebHeaderCollection.AllKeys[i]);
			}
			myHttpWebResponse.Close();
		}
		catch(WebException e) {
			Console.WriteLine("\nWebException is thrown.\nMessage is:" + e.Message);
			if(e.Status == WebExceptionStatus.ProtocolError) {
				Console.WriteLine("Status Code : {0}", ((HttpWebResponse)e.Response).StatusCode);
				Console.WriteLine("Status Description : {0}", ((HttpWebResponse)e.Response).StatusDescription);
				Console.WriteLine("Server : {0}", ((HttpWebResponse)e.Response).Server);
			}
		}
		catch(Exception e) {
			Console.WriteLine("Exception is thrown. Message is :" + e.Message);
		}

	}
// </Snippet1>
};
