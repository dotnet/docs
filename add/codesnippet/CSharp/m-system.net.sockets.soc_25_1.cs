            // Establish the remote endpoint for the socket.
            // For this example use local computer.
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);

            // Create a TCP/IP socket.
            Socket client = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

            // Connect to the remote endpoint.
            client.BeginConnect(remoteEP, 
                new AsyncCallback(ConnectCallback), client);
                
            // Wait for connect.
            connectDone.WaitOne();

            // Send some data to the remote device.
            string data = "This is a string of data <EOF>";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            client.BeginSend(buffer, 0, buffer.Length, 0, new AsyncCallback(ClientSendCallback), client);
            // Wait for send done.
            sendDone.WaitOne();
        
            // Release the socket.
            client.Shutdown(SocketShutdown.Both);
            client.BeginDisconnect(true, new AsyncCallback(DisconnectCallback), client);

            // Wait for the disconnect to complete.
            disconnectDone.WaitOne();
            if (client.Connected)
                Console.WriteLine("We're still connected");
            else
                Console.WriteLine("We're disconnected");
        }


        private static void DisconnectCallback(IAsyncResult ar)
        { 
            // Complete the disconnect request.
            Socket client = (Socket) ar.AsyncState;
            client.EndDisconnect(ar);

            // Signal that the disconnect is complete.
            disconnectDone.Set();
        }
     