        public static void AsynchronousFileSend()
        {
            // Send a file to a remote device.
            
            // Establish the remote endpoint for the socket.
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

            // There is a text file test.txt in the root directory.
            string fileName = "C:\\test.txt";
          
            // Send file fileName to the remote device.
            Console.WriteLine(fileName);
            client.BeginSendFile(fileName, new AsyncCallback(FileSendCallback), client);

            // Release the socket.
            client.Shutdown(SocketShutdown.Both);
            client.Close();
        }


        private static void FileSendCallback(IAsyncResult ar)
        {
            // Retrieve the socket from the state object.
            Socket client = (Socket) ar.AsyncState;

            // Complete sending the data to the remote device.
            client.EndSendFile(ar);
            sendDone.Set();
        }