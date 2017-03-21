            // This server waits for a connection and then uses asynchronous operations to
            // accept the connection with initial data sent from the client.
                       
            // Establish the local endpoint for the socket.
        
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

            // Create a TCP/IP socket.
            Socket listener = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp );

            // Bind the socket to the local endpoint, and listen for incoming connections.
            listener.Bind(localEndPoint);
            listener.Listen(100);

            while (true) 
            {
                // Set the event to nonsignaled state.
                allDone.Reset();

                // Start an asynchronous socket to listen for connections and receive data from the client.
                Console.WriteLine("Waiting for a connection...");

                // Accept the connection and receive the first 10 bytes of data. 
                // BeginAccept() creates the accepted socket.
                int receivedDataSize = 10;
                listener.BeginAccept(null, receivedDataSize, new AsyncCallback(AcceptReceiveDataCallback), listener);

                // Wait until a connection is made and processed before continuing.
                allDone.WaitOne();
            }
        }



        public static void AcceptReceiveDataCallback(IAsyncResult ar) 
        {
            // Get the socket that handles the client request.
            Socket listener = (Socket) ar.AsyncState;
            
            // End the operation and display the received data on the console.
            byte[] Buffer;
            int bytesTransferred;
            Socket handler = listener.EndAccept(out Buffer, out bytesTransferred, ar);
            string stringTransferred = Encoding.ASCII.GetString(Buffer, 0, bytesTransferred);
    
            Console.WriteLine(stringTransferred);
            Console.WriteLine("Size of data transferred is {0}", bytesTransferred);

            // Create the state object for the asynchronous receive.
            StateObject state = new StateObject();
            state.workSocket = handler;
            handler.BeginReceive( state.buffer, 0, StateObject.BufferSize, 0,
            new AsyncCallback(ReadCallback), state);
        }
