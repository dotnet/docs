            Console.WriteLine("Listening for {0} prefixes...", listener.Prefixes.Count)
            Dim context As HttpListenerContext = listener.GetContext()
            Dim request As HttpListenerRequest = context.Request
            Console.WriteLine("Received a request.")
            ' This server requires a valid client certificate
            ' for requests that are not sent from the local computer.

            ' Did the client omit the certificate or send an invalid certificate?
            If request.IsAuthenticated AndAlso request.GetClientCertificate() Is Nothing OrElse request.ClientCertificateError <> 0 Then
                ' Send a 403 response.
                Dim badCertificateResponse As HttpListenerResponse = context.Response
                SendBadCertificateResponse(badCertificateResponse)
                Console.WriteLine("Client has invalid certificate.")
                Continue Do
            End If