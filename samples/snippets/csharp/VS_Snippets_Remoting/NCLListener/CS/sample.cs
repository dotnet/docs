//NCLListener
// <snippet8>
using System;
using System.Net;
using System.Text;
using System.Security.Principal;

public class NetListener
{
// <snippet5>
        static string message403;
        static HttpListenerResponse preMade403Response;
        static void SendBadCertificateResponse(HttpListenerResponse response)
        {
            if (preMade403Response == null)
            {
                // Set up an authentication error response template.
                response.StatusCode = (int)HttpStatusCode.Forbidden;
                response.StatusDescription = "403 Forbidden";
                response.ProtocolVersion = new Version("1.1");
                response.SendChunked = false;

                preMade403Response = response;
            }
            else
            {
                response.CopyFrom(preMade403Response);
            }

            // The response body cannot be saved in the template.

            StringBuilder message = new StringBuilder();
            message.Append("<HTML><BODY>");
            message.Append("<p> Error message 403: Access is denied due to a missing or invalid client certificate.</p>");
            message.Append("</BODY></HTML>");
            message403 = message.ToString();

            // Turn the error message into a byte array using the 
            // encoding from the response when present.
            System.Text.Encoding encoding = response.ContentEncoding;
            if (encoding == null)
            {
                encoding = System.Text.Encoding.UTF8;
                response.ContentEncoding = encoding;
            }

            byte[] buffer = encoding.GetBytes(message403);
            response.ContentLength64 = buffer.Length;
            // Write the error message.
            System.IO.Stream stream = response.OutputStream;
            stream.Write(buffer, 0, buffer.Length);
            // Send the response.
            response.Close();
        }
        // </snippet5>

    // <snippet1>
    static AuthenticationSchemes AuthenticationSchemeForClient(HttpListenerRequest request)
    {
        Console.WriteLine("Client authentication protocol selection in progress...");
        // Do not authenticate local machine requests.
        if (request.RemoteEndPoint.Address.Equals (IPAddress.Loopback))
        {
            return AuthenticationSchemes.None;
        }
        else
        {
            return AuthenticationSchemes.IntegratedWindowsAuthentication;
        }
    }
    // </snippet1>
    public static void Main()
    {
        // <snippet2>
        // Set up a listener.
        HttpListener listener = new HttpListener();
        HttpListenerPrefixCollection prefixes = listener.Prefixes;
        prefixes.Add(@"http://localhost:8080/");
        prefixes.Add(@"http://contoso.com:8080/");

        // Specify the authentication delegate.
        listener.AuthenticationSchemeSelectorDelegate = 
            new AuthenticationSchemeSelector (AuthenticationSchemeForClient);

        // Start listening for requests and process them 
        // synchronously.
        listener.Start();
        // </snippet2>
        while (true)
        {
            // <snippet3>
            Console.WriteLine("Listening for {0} prefixes...", listener.Prefixes.Count);
            HttpListenerContext context = listener.GetContext();
            HttpListenerRequest request = context.Request;
            Console.WriteLine("Received a request.");
            // This server requires a valid client certificate
            // for requests that are not sent from the local computer.

            // Did the client omit the certificate or send an invalid certificate?
            if (request.IsAuthenticated &&
                request.GetClientCertificate() == null || 
                request.ClientCertificateError != 0)
            {
                // Send a 403 response.
                HttpListenerResponse badCertificateResponse = context.Response ;
                SendBadCertificateResponse(badCertificateResponse);
                Console.WriteLine("Client has invalid certificate.");
                continue;
            }
            // </snippet3>
            StringBuilder message = new StringBuilder ();
            // <snippet7>

            // When the client is not authenticated, there is no Identity.
            if (context.User == null)
            {
                message.Append ("<HTML><BODY><p> Hello local user! </p></BODY></HTML>");
            }
            else
            {
                // <snippet6>
                // Get the requester's identity.
                System.Security.Principal.WindowsIdentity identity = WindowsIdentity.GetCurrent();
                // Construct the response body.
                message.AppendFormat ("<HTML><BODY><p> Hello {0}!<br/>", 
                    identity.Name);
                message.AppendFormat ("You were authenticated using {0}.</p>", 
                    identity.AuthenticationType);
                message.Append ("</BODY></HTML>");
                // </snippet6>
            }

            // Configure the response.
            HttpListenerResponse response = context.Response;

            // Use the encoding from the response if one has been set.
            // Otherwise, use UTF8.
            System.Text.Encoding encoding = response.ContentEncoding;
            if (encoding == null)
            {
                encoding = System.Text.Encoding.UTF8;
                response.ContentEncoding = encoding;
            }
            byte[] buffer = encoding.GetBytes (message.ToString ());
            response.ContentLength64 = buffer.Length;
            response.StatusCode = (int) HttpStatusCode.OK;
            response.StatusDescription = "OK";
            response.ProtocolVersion = new Version ("1.1");
            // Don't keep the TCP connection alive; 
            // We don't expect multiple requests from the same client.
            response.KeepAlive = false;
            // Write the response body.
            System.IO.Stream stream = response.OutputStream;
            stream.Write(buffer, 0, buffer.Length);
            // </snippet7>
            // <snippet4>
            Console.WriteLine("Request complete. Press q to quit, enter to continue.");
            string answer = Console.ReadLine();
            if (answer.StartsWith("q"))
            { 
               Console.WriteLine("bye.");
               listener.Close();
               break;
            }
            // </snippet4>
        }
    }
}
// </snippet8>

