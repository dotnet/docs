using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace newTcpClient
{
    class Tester
    {
        // Define the TCP client.
        static TcpClient t; 

         // <Snippet1>
        static void GetAvailable()
        {
            // Find out how many bytes are ready to be read.
            Console.WriteLine("Availabe value is {0}", t.Available);
        }
        // </Snippet1>

       // <Snippet2>
        static void GetConnected()
        {
            // Find out whether the socket is connected to the remote 
            // host.
            Console.WriteLine("Connected value is {0}", t.Connected);
        }
        // </Snippet2>

        // <Snippet3>
        static void GetSetExclusiveAddressUse()
        {
            // Don't allow another process to bind to this port.
            t.ExclusiveAddressUse = true;
            Console.WriteLine("ExclusiveAddressUse value is {0}",
                t.ExclusiveAddressUse);
        }
        // </Snippet3>

        // <Snippet8>
        static void DoConnect(string host, int port)
        {
            // Connect to the specified host.
            TcpClient t = new TcpClient(AddressFamily.InterNetwork);
              
            IPAddress[] IPAddresses = Dns.GetHostAddresses(host);

            Console.WriteLine("Establishing connection to {0}", host);
            t.Connect(IPAddresses, port);

            Console.WriteLine("Connection established");
        }
        // </Snippet8>

        // <Snippet7>
        public static ManualResetEvent connectDone = 
            new ManualResetEvent(false);

        public static void ConnectCallback(IAsyncResult ar)
        {
            connectDone.Set();
            TcpClient t = (TcpClient)ar.AsyncState;
            t.EndConnect(ar);
        }
        // </Snippet7>

        // <Snippet4>
        public static void DoBeginConnect1(string host, int port)
        {
            // Connect asynchronously to the specifed host.
            TcpClient t = new TcpClient(AddressFamily.InterNetwork);
//            IPAddress remoteHost = new IPAddress(host);
            IPAddress[] remoteHost = Dns.GetHostAddresses(host);

            connectDone.Reset();

            Console.WriteLine("Establishing Connection to {0}", 
                remoteHost[0]);
            t.BeginConnect(remoteHost[0], port, 
                new AsyncCallback(ConnectCallback), t);

            // Wait here until the callback processes the connection.
            connectDone.WaitOne();

            Console.WriteLine("Connection established");
        }
        // </Snippet4>

        // <Snippet5>
        // Connect asynchronously to the specifed host.
        public static void DoBeginConnect2(string host, int port)
        {
            TcpClient t = new TcpClient(AddressFamily.InterNetwork);
            IPAddress[] remoteHost = Dns.GetHostAddresses(host);

            connectDone.Reset();

            Console.WriteLine("Establishing Connection to {0}", host);
            t.BeginConnect(remoteHost, port, 
                new AsyncCallback(ConnectCallback), t);

            // Wait here until the callback processes the connection.
            connectDone.WaitOne();

            Console.WriteLine("Connection established");
        }
        // </Snippet5>

        // <Snippet6>
        // Connect asynchronously to the specifed host.
        public static void DoBeginConnect3(string host, int port)
        {
            TcpClient t = new TcpClient(AddressFamily.InterNetwork);

            connectDone.Reset();

            Console.WriteLine("Establishing Connection to {0}", 
                host);
            t.BeginConnect(host, port, 
                new AsyncCallback(ConnectCallback), t);

            // Wait here until the callback processes the connection.
            connectDone.WaitOne();

            Console.WriteLine("Connection established");
        }
        // </Snippet6>


        [STAThread]
        static void Main(string[] args)
        {
            // The TCP socket.
            t = new TcpClient();

            GetConnected();
            GetAvailable();
            GetSetExclusiveAddressUse();

            DoConnect("127.0.0.1", 80);
            DoBeginConnect1("127.0.0.1", 80);
            DoBeginConnect2("127.0.0.1", 80);
            DoBeginConnect3("127.0.0.1", 80);


            Console.WriteLine("Press ENTER to exit");
            Console.Read();
        }
    }
}