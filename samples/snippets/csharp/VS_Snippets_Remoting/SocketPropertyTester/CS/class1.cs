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

			Console.WriteLine("  ExclusiveAddressUse {0}", 
						tcpSocket.ExclusiveAddressUse);

			Console.WriteLine("  LingerState {0}, {1}", 
					     tcpSocket.LingerState.Enabled, 
				             tcpSocket.LingerState.LingerTime);

			Console.WriteLine("  NoDelay {0}", 
                                                tcpSocket.NoDelay);

			Console.WriteLine("  ReceiveBufferSize {0}", 
						tcpSocket.ReceiveBufferSize);

			Console.WriteLine("  ReceiveTimeout {0}", 
						tcpSocket.ReceiveTimeout);

			Console.WriteLine("  SendBufferSize {0}", 
						tcpSocket.SendBufferSize);

			Console.WriteLine("  SendTimeout {0}", 
                                                tcpSocket.SendTimeout);

			Console.WriteLine("  Ttl {0}", 
                                                tcpSocket.Ttl);

                        Console.WriteLine("  IsBound {0}", 
                                                tcpSocket.IsBound);

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
			Console.WriteLine("  DontFragment {0}", 
                                                udpSocket.DontFragment);
			Console.WriteLine("  EnableBroadcast {0}", 
                                                udpSocket.EnableBroadcast);
			Console.WriteLine("  MulticastLoopback {0}", 
                                                udpSocket.MulticastLoopback);
		}
        //</Snippet2>

		[STAThread]
		static void Main(string[] args)
		{
			Socket t = new Socket(AddressFamily.InterNetwork,
				SocketType.Stream,
				ProtocolType.IP);
			Socket u = new Socket(AddressFamily.InterNetwork,
				SocketType.Dgram,
				ProtocolType.IP);

			ConfigureTcpSocket(t);
			ConfigureUdpSocket(u);

		}
	}
}