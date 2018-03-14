using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace newTcpListener
{
    class newListener
    {
        // <Snippet2>
        public static void GetSetExclusiveAddressUse(TcpListener t)
        {
            // Set Exclusive Address Use for the underlying socket.
            t.ExclusiveAddressUse = true;
            Console.WriteLine("ExclusiveAddressUse value is {0}",
                t.ExclusiveAddressUse);
        }
        // </Snippet2>

        // <Snippet3>
        public static void DoStart(TcpListener t, int backlog)
        {
            // Start listening for client connections with the 
            // specified backlog.
            t.Start(backlog);
            Console.WriteLine("started listening");
        }
        // </Snippet3>

        // <Snippet4>
        // Thread signal.
        public static ManualResetEvent clientConnected = 
            new ManualResetEvent(false);

        // Accept one client connection asynchronously.
        public static void DoBeginAcceptSocket(TcpListener listener)
        {
            // Set the event to nonsignaled state.
            clientConnected.Reset();

            // Start to listen for connections from a client.
            Console.WriteLine("Waiting for a connection...");

            // Accept the connection. 
            // BeginAcceptSocket() creates the accepted socket.
            listener.BeginAcceptSocket(
                new AsyncCallback(DoAcceptSocketCallback), listener);
            // Wait until a connection is made and processed before 
            // continuing.
            clientConnected.WaitOne();
        }

        // Process the client connection.
        public static void DoAcceptSocketCallback(IAsyncResult ar) 
        {
            // Get the listener that handles the client request.
            TcpListener listener = (TcpListener) ar.AsyncState;
            
            // End the operation and display the received data on the
            //console.
            Socket clientSocket = listener.EndAcceptSocket(ar);
    
            // Process the connection here. (Add the client to a 
            // server table, read data, etc.)
            Console.WriteLine("Client connected completed");

            // Signal the calling thread to continue.
            clientConnected.Set();
        }
        // </Snippet4>

        // <Snippet5>
        // Thread signal.
        public static ManualResetEvent tcpClientConnected = 
            new ManualResetEvent(false);

        // Accept one client connection asynchronously.
        public static void DoBeginAcceptTcpClient(TcpListener 
            listener)
        {
            // Set the event to nonsignaled state.
            tcpClientConnected.Reset();

            // Start to listen for connections from a client.
            Console.WriteLine("Waiting for a connection...");

            // Accept the connection. 
            // BeginAcceptSocket() creates the accepted socket.
            listener.BeginAcceptTcpClient(
                new AsyncCallback(DoAcceptTcpClientCallback), 
                listener);

            // Wait until a connection is made and processed before 
            // continuing.
            tcpClientConnected.WaitOne();
        }

        // Process the client connection.
        public static void DoAcceptTcpClientCallback(IAsyncResult ar) 
        {
            // Get the listener that handles the client request.
            TcpListener listener = (TcpListener) ar.AsyncState;
            
            // End the operation and display the received data on 
            // the console.
            TcpClient client = listener.EndAcceptTcpClient(ar);
    
            // Process the connection here. (Add the client to a
            // server table, read data, etc.)
            Console.WriteLine("Client connected completed");

            // Signal the calling thread to continue.
            tcpClientConnected.Set();

        }
        // </Snippet5>

        [STAThread]
        static void Main()
        {
           TcpListener listener = new TcpListener(
                Dns.GetHostAddresses("")[0], 4242);

            GetSetExclusiveAddressUse(listener);

            // Start listening for client connections.
            DoStart(listener, 20);

            // Accept one client connection asynchronously
            DoBeginAcceptSocket(listener);
            DoBeginAcceptTcpClient(listener);

            Console.WriteLine("hit any key");
            Console.Read();
        }
    }
}

