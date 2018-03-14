

#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Net::Sockets;
ref class UdpClientExamples
{
public:

   // <Snippet1>
   static void GetAvailable( UdpClient^ u )
   {
      // Get the number of bytes available for reading.
      Console::WriteLine(  "Available value is {0}", u->Available );
   }
   // </Snippet1>

   // <Snippet2>
   static void GetSetDontFragment( UdpClient^ u )
   {
      // Set the don't fragment flag for packets emanating from
      // this client.
      u->DontFragment = true;
      Console::WriteLine(  "DontFragment value is {0}", u->DontFragment );
   }
   // </Snippet2>

   // <Snippet3>
   static void GetSetEnableBroadcast( UdpClient^ u )
   {
      // Set the Broadcast flag for this client.
      u->EnableBroadcast = true;
      Console::WriteLine(  "EnableBroadcast value is {0}", u->EnableBroadcast );
   }
   // </Snippet3>

   // <Snippet4>
   static void GetSetExclusiveAddressUse( UdpClient^ u )
   {
      // Don't allow another client to bind to this port.
      u->ExclusiveAddressUse = true;
      Console::WriteLine(  "ExclusiveAddressUse value is {0}", u->ExclusiveAddressUse );
   }
   // </Snippet4>

   // <Snippet5>
   static void GetSetTtl( UdpClient^ u )
   {
      // Set the Time To Live (TTL) for this client.
      u->Ttl = 42;
      Console::WriteLine(  "Ttl value is {0}", u->Ttl );
   }
   // </Snippet5>

   // <Snippet6>
   // Subscribe to a multicast group.
   static void DoJoinMulticastGroup( UdpClient^ u, String^ mcast, String^ local )
   {
      array<IPAddress^>^ multicastAddress = Dns::GetHostAddresses( mcast );

      u->JoinMulticastGroup( multicastAddress[0] );
      Console::WriteLine(  "Joined multicast Address {0}", multicastAddress );
   }
   // </Snippet6>

   // <Snippet7>
   static void GetSetMulticastLoopback( UdpClient^ u )
   {
      // Deliver multicast packets back to the sending client.
      u->MulticastLoopback = true;
      Console::WriteLine(  "MulticastLoopback value is {0}", u->MulticastLoopback );
   }
   // </Snippet7>
};

int main()
{
   UdpClient^ u = gcnew UdpClient( 4242 );
   UdpClientExamples::GetAvailable( u );
   UdpClientExamples::GetSetDontFragment( u );
   UdpClientExamples::GetSetEnableBroadcast( u );
   UdpClientExamples::GetSetExclusiveAddressUse( u );
   UdpClientExamples::GetSetTtl( u );
   UdpClientExamples::DoJoinMulticastGroup( u,  "224.1.1.1",  "172.30.186.134" );
   return 0;
}
