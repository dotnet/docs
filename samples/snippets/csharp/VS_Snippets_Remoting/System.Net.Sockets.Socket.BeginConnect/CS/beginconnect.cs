using System;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace BeginConnectTester
{
	class ConnectTester
	{
//<Snippet1>
        public static ManualResetEvent allDone = 
            new ManualResetEvent(false);

        // handles the completion of the prior asynchronous 
        // connect call. the socket is passed via the objectState 
        // paramater of BeginConnect().
        public static void ConnectCallback1(IAsyncResult ar)
        {
            allDone.Set();
            Socket s = (Socket) ar.AsyncState;
            s.EndConnect(ar);
        }
//</Snippet1>
//<Snippet7>
        // Asynchronous connect using the host name, resolved via 
        // IPAddress
        public static void BeginConnect1(string host, int port)
        {

            IPAddress[] IPs = Dns.GetHostAddresses(host);

            Socket s = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp);

            allDone.Reset();

            Console.WriteLine("Establishing Connection to {0}", 
                host);
            s.BeginConnect(IPs[0], port, 
                new AsyncCallback(ConnectCallback1), s);

            // wait here until the connect finishes.  
            // The callback sets allDone.
            allDone.WaitOne();

            Console.WriteLine("Connection established");

        }		
//</Snippet7>
//<Snippet2>

        // Asynchronous connect, using DNS.GetHostAddresses
        public static void BeginConnect2(string host, int port)
        {
            IPAddress[] IPs = Dns.GetHostAddresses(host);

            Socket s = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp);

            allDone.Reset();

            Console.WriteLine("Establishing Connection to {0}", 
                host);
            s.BeginConnect(IPs, port, 
                new AsyncCallback(ConnectCallback1), s);

            // wait here until the connect finishes.  The callback 
            // sets allDone.
            allDone.WaitOne();

            Console.WriteLine("Connection established");
        }		
//</Snippet2>

//<Snippet3>
        // Asynchronous connect using host name (resolved by the 
        // BeginConnect call.)
        public static void BeginConnect3(string host, int port)
        {
            Socket s = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp);

            allDone.Reset();

            Console.WriteLine("Establishing Connection to {0}", 
                host);
            s.BeginConnect(host, port, 
                new AsyncCallback(ConnectCallback1), s);

            // wait here until the connect finishes.  The callback 
            // sets allDone.
            allDone.WaitOne();

            Console.WriteLine("Connection established");
        }		
//</Snippet3>

//<Snippet4>
        // Synchronous connect using IPAddress to resolve the 
        // host name.
        public static void Connect1(string host, int port)
        {
            IPAddress[] IPs = Dns.GetHostAddresses(host);

            Socket s = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp);
 
            Console.WriteLine("Establishing Connection to {0}", 
                host);
            s.Connect(IPs[0], port);
            Console.WriteLine("Connection established");
        }		
//</Snippet4>

//<Snippet5>
        // Synchronous connect using Dns.GetHostAddresses to 
        // resolve the host name.
        public static void Connect2(string host, int port)
        {
            IPAddress[] IPs = Dns.GetHostAddresses(host);

            Socket s = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp);
            Console.WriteLine("Establishing Connection to {0}", 
                host);
            s.Connect(IPs, port);
            Console.WriteLine("Connection established");
        }		
//</Snippet5>

//<Snippet6>
        // Synchronous connect using host name (resolved by the 
        // Connect call.)
        public static void Connect3(string host, int port)
        {
            Socket s = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp);

            Console.WriteLine("Establishing Connection to {0}", 
                host);
            s.Connect(host, port);
            Console.WriteLine("Connection established");
        }		
//</Snippet6>

        [STAThread]
		static void Main(string[] args)
		{
            BeginConnect1("127.0.0.1", 80);
            BeginConnect2("localhost", 80);
            BeginConnect3("localhost", 80);

            Connect1("127.0.0.1", 80);
            Connect2("127.0.0.1", 80);
            Connect3("localhost", 80);

            Console.WriteLine("hit any key");
            Console.Read();
        }
    }
}
