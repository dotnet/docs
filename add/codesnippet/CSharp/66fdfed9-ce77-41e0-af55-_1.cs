            // Establish the remote endpoint for the socket.
            // For this example, use the local machine.
            IPHostEntry ipHostInfo = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            // Client and server use port 11000. 
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);
            // Create a TCP/IP socket.
            client = new TcpClient();
            // Connect the socket to the remote endpoint.
            client.Connect(remoteEP);
            Console.WriteLine("Client connected to {0}.", remoteEP.ToString());
            // Ensure the client does not close when there is 
            // still data to be sent to the server.
            client.LingerState = (new LingerOption(true, 0));
            // Request authentication.
            NetworkStream clientStream = client.GetStream();
            NegotiateStream authStream = new NegotiateStream(clientStream, false); 
            // Pass the NegotiateStream as the AsyncState object 
            // so that it is available to the callback delegate.
            IAsyncResult ar = authStream.BeginAuthenticateAsClient(
                new AsyncCallback(EndAuthenticateCallback),
                authStream
                );