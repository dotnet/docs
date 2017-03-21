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