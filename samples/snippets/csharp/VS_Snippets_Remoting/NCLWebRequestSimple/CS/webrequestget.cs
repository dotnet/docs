// <Snippet1>
using System;
using System.IO;
using System.Net;
using System.Text;

namespace Examples.System.Net
{
    public class WebRequestGetExample
    {
        public static void Main ()
        {
            // <Snippet2>
            // Create a request for the URL. 		
            WebRequest request = WebRequest.Create ("http://www.contoso.com/default.html");
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse ();
            // </Snippet2>
            // Display the status.
            Console.WriteLine (response.StatusDescription);
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream ();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader (dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd ();
            // Display the content.
            Console.WriteLine (responseFromServer);
            // Cleanup the streams and the response.
            reader.Close ();
            dataStream.Close ();
            response.Close ();
        }
    }
}
// </Snippet1>
