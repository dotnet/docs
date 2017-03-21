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