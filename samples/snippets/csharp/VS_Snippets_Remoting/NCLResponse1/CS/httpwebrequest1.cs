// SampleID="NCLResponse1"

// <Snippet1>
using System;
using System.Net;
using System.Text;
using System.IO;


    public class Test
    {
        // Specify the URL to receive the request.
        public static void Main (string[] args)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create (args[0]);

            // Set some reasonable limits on resources used by this request
            request.MaximumAutomaticRedirections = 4;
            request.MaximumResponseHeadersLength = 4;
            // Set credentials to use for this request.
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse ();

            Console.WriteLine ("Content length is {0}", response.ContentLength);
            Console.WriteLine ("Content type is {0}", response.ContentType);
             
            // Get the stream associated with the response.
            Stream receiveStream = response.GetResponseStream ();

            // Pipes the stream to a higher level stream reader with the required encoding format. 
            StreamReader readStream = new StreamReader (receiveStream, Encoding.UTF8);

            Console.WriteLine ("Response stream received.");
            Console.WriteLine (readStream.ReadToEnd ());
            response.Close ();
            readStream.Close ();
        }
    }

/*
The output from this example will vary depending on the value passed into Main 
but will be similar to the following:

Content length is 1542
Content type is text/html; charset=utf-8
Response stream received.
<html>
...
</html>

*/
// </Snippet1>