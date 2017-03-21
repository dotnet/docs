            // Create a TCP/IP client socket.
            // machineName is the host running the server application.
            TcpClient^ client = gcnew TcpClient(machineName, 8080);
            Console::WriteLine("Client connected.");
              
            // Create an SSL stream that will close 
            // the client's stream.
            SslStream^ sslStream = gcnew SslStream(
                client->GetStream(), false,
                gcnew RemoteCertificateValidationCallback(ValidateServerCertificate),
                nullptr);
              
            // The server name must match the name
            // on the server certificate.
            try
            {
                sslStream->AuthenticateAsClient(serverName);
            }
            catch (AuthenticationException^ ex) 
            {
                Console::WriteLine("Exception: {0}", ex->Message);
                if (ex->InnerException != nullptr)
                {
                    Console::WriteLine("Inner exception: {0}", 
                        ex->InnerException->Message);
                }

                Console::WriteLine("Authentication failed - "
                    "closing the connection.");
                sslStream->Close();
                client->Close();
                return;
            }