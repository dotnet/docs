
            // When the client is not authenticated, there is no Identity.
            if (context.User == null)
            {
                message.Append ("<HTML><BODY><p> Hello local user! </p></BODY></HTML>");
            }
            else
            {
                // Get the requester's identity.
                System.Security.Principal.WindowsIdentity identity = WindowsIdentity.GetCurrent();
                // Construct the response body.
                message.AppendFormat ("<HTML><BODY><p> Hello {0}!<br/>", 
                    identity.Name);
                message.AppendFormat ("You were authenticated using {0}.</p>", 
                    identity.AuthenticationType);
                message.Append ("</BODY></HTML>");
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