   static void GetSetMulticastLoopback( UdpClient^ u )
   {
      // Deliver multicast packets back to the sending client.
      u->MulticastLoopback = true;
      Console::WriteLine(  "MulticastLoopback value is {0}", u->MulticastLoopback );
   }