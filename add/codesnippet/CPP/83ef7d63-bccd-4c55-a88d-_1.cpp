   // Subscribe to a multicast group.
   static void DoJoinMulticastGroup( UdpClient^ u, String^ mcast, String^ local )
   {
      array<IPAddress^>^ multicastAddress = Dns::GetHostAddresses( mcast );

      u->JoinMulticastGroup( multicastAddress[0] );
      Console::WriteLine(  "Joined multicast Address {0}", multicastAddress );
   }