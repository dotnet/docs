using System;
using System.Net;
using System.Net.Sockets;

namespace socketoption_examples
{
    class SocketPropertyTester
    {
        //<Snippet1>
        static void ConfigureTcpSocket(Socket tcpSocket)
        {
            // Don't allow another socket to bind to this port.
            tcpSocket.ExclusiveAddressUse = true;

            // The socket will linger for 10 seconds after
            // Socket.Close is called.
            tcpSocket.LingerState = new LingerOption (true, 10);

            // Disable the Nagle Algorithm for this tcp socket.
            tcpSocket.NoDelay = true;

            // Set the receive buffer size to 8k
            tcpSocket.ReceiveBufferSize = 8192;

            // Set the timeout for synchronous receive methods to
            // 1 second (1000 milliseconds.)
            tcpSocket.ReceiveTimeout = 1000;

            // Set the send buffer size to 8k.
            tcpSocket.SendBufferSize = 8192;

            // Set the timeout for synchronous send methods
            // to 1 second (1000 milliseconds.)
            tcpSocket.SendTimeout = 1000;

            // Set the Time To Live (TTL) to 42 router hops.
            tcpSocket.Ttl = 42;

            Console.WriteLine("Tcp Socket configured:");

            Console.WriteLine($"  ExclusiveAddressUse {tcpSocket.ExclusiveAddressUse}");

            Console.WriteLine($"  LingerState {tcpSocket.LingerState.Enabled}, {tcpSocket.LingerState.LingerTime}");

            Console.WriteLine($"  NoDelay {tcpSocket.NoDelay}");

            Console.WriteLine($"  ReceiveBufferSize {tcpSocket.ReceiveBufferSize}");

            Console.WriteLine($"  ReceiveTimeout {tcpSocket.ReceiveTimeout}");

            Console.WriteLine($"  SendBufferSize {tcpSocket.SendBufferSize}");

            Console.WriteLine($"  SendTimeout {tcpSocket.SendTimeout}");

            Console.WriteLine($"  Ttl {tcpSocket.Ttl}");

            Console.WriteLine($"  IsBound {tcpSocket.IsBound}");

            Console.WriteLine("");
        }
        //</Snippet1>

        //<Snippet2>
        static void ConfigureUdpSocket(Socket udpSocket)
        {
            // set the Don't Fragment flag.
            udpSocket.DontFragment = true;
            // Enable broadcast.
            udpSocket.EnableBroadcast = true;

            // Disable multicast loopback.
            udpSocket.MulticastLoopback = false;

            Console.WriteLine("Udp Socket configured:");
            Console.WriteLine($"  DontFragment {udpSocket.DontFragment}");
            Console.WriteLine($"  EnableBroadcast {udpSocket.EnableBroadcast}");
            Console.WriteLine($"  MulticastLoopback {udpSocket.MulticastLoopback}");
        }
        //</Snippet2>

        [STAThread]
        static void Main(string[] args)
        {
            var t = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.IP);
            var u = new Socket(AddressFamily.InterNetwork,
                SocketType.Dgram,
                ProtocolType.IP);

            ConfigureTcpSocket(t);
            ConfigureUdpSocket(u);
        }
    }
}
