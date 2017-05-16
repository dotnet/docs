//<Snippet1>
using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace Examples.System.Net
{
    public class ServicePointExample
    {
        // Pass in the name of the Web page to retrieve.
        public static void Main (string[] args)
        {
            string page;
            if (args == null || args.Length == 0 || args[0].Length == 0)
            {
                page = "http://www.contoso.com/default.html";
            }
            else
            {
                page = args[0];
            }
            // Create the request.
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create (page);
            // Get the service point that handles the request's socket connection.
            ServicePoint point = request.ServicePoint;
            // Set the receive buffer size on the underlying socket.
            point.ReceiveBufferSize = 2048;
            // Set the connection lease timeout to infinite.
            point.ConnectionLeaseTimeout = Timeout.Infinite;
            // Send the request.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse ();
            Stream responseStream = response.GetResponseStream ();
            StreamReader s = new StreamReader (responseStream);
            // Display the response.
            Console.WriteLine (s.ReadToEnd ());
            s.Close();
            responseStream.Close();
            response.Close();
        }
    }
}
//</Snippet1>