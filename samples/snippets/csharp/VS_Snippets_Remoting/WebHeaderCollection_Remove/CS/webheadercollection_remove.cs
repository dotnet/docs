/*
 This program demonstrates the "Remove" method of "WebHeaderCollection" class.
 It uses the "Remove" method of "WebHeaderCollection" to remove the 'Cache-Control' header from the request.
 The 'Cache-Control' header is used to specify the directive that must be followed by all caching mechanisms
 in the Request-Response chain. The 'no-cache' directive indicates that the caching mechanism must not resend
 the cached response for a previous request without validating from  the origin server (HTTP version 1.1, RFC2616,
 Sec 14.9)
*/

using System;
using System.Net;

public class WebHeaderCollection_Remove {

	public static void Main() {
// <Snippet1>
		try {
			// Create a web request for "www.msn.com".
		 	HttpWebRequest myHttpWebRequest = (HttpWebRequest) WebRequest.Create("http://www.msn.com");

			// Get the headers associated with the request.
			WebHeaderCollection myWebHeaderCollection = myHttpWebRequest.Headers;

			// Set the Cache-Control header.
			myWebHeaderCollection.Set("Cache-Control", "no-cache");

			// Get the associated response for the above request.
		 	HttpWebResponse myHttpWebResponse = (HttpWebResponse) myHttpWebRequest.GetResponse();

			// Print the headers of the request to console.
			Console.WriteLine("Print request headers after adding Cache-Control for first request:");
			printHeaders(myHttpWebRequest.Headers);

			// Remove the Cache-Control header for the new request.
			myWebHeaderCollection.Remove("Cache-Control");

			// Get the response for the new request.
			myHttpWebResponse = (HttpWebResponse) myHttpWebRequest.GetResponse();

			// Print the headers of the new request without the Cache-Control header.
			Console.WriteLine("Print request headers after removing Cache-Control for the new request:");
			printHeaders(myHttpWebRequest.Headers);
			myHttpWebResponse.Close();
		}
		// Catch exception if trying to remove a restricted header.
		catch(ArgumentException e) {
			Console.WriteLine("Error : Trying to remove a restricted header");
			Console.WriteLine("ArgumentException is thrown. Message is :" + e.Message);
		}
		catch(WebException e) {
			Console.WriteLine("WebException is thrown. Message is :" + e.Message);
			if(e.Status == WebExceptionStatus.ProtocolError) {
				Console.WriteLine("Status Code : {0}", ((HttpWebResponse)e.Response).StatusCode);
				Console.WriteLine("Status Description : {0}", ((HttpWebResponse)e.Response).StatusDescription);
				Console.WriteLine("Server : {0}", ((HttpWebResponse)e.Response).Server);
			}
		}
		catch(Exception e) {
			Console.WriteLine("Exception is thrown. Message is :" + e.Message);
		}
// </Snippet1>
	}

	public static void printHeaders(WebHeaderCollection headers) {
		if(headers.Count == 0)
			Console.WriteLine("\tNo Headers to Display");
		for(int i = 0; i < headers.Count; i++) 
			Console.WriteLine("\t" + headers.AllKeys[i] + " : " + headers[i]);
	}

};
