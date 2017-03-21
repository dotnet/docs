            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress  ipAddr = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 11000);

            Socket client = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

            // Connect the socket to the remote end point.
            client.Connect(ipEndPoint);

            // Send some data to the remote device.
            string data = "This is a string of data <EOF>";
            byte[] buffer = Encoding.ASCII.GetBytes(data);

            int bytesTransferred =  client.Send(buffer);

            // Write to the console the number of bytes transferred.
            Console.WriteLine("{0} bytes were sent.\n", bytesTransferred);

            // Release the socket.
            client.Shutdown(SocketShutdown.Both);
          
            client.Disconnect(true);
            if (client.Connected) 
                Console.WriteLine("We're still connnected");
            else 
                Console.WriteLine("We're disconnected");