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