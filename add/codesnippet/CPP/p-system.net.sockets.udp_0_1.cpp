// This derived class demonstrate the use of three protected methods belonging to the UdpClient class.
public ref class MyUdpClientDerivedClass: public UdpClient
{
public:
   MyUdpClientDerivedClass()
      : UdpClient()
   {}

   void UsingProtectedMethods()
   {
      //Uses the protected Active property belonging to the UdpClient base class to determine if a connection is established.
      if ( this->Active )
      {
         //Calls the protected Client property belonging to the UdpClient base class.
         Socket^ s = this->Client;

         //Uses the Socket returned by Client to set an option that is not available using UdpClient.
         s->SetSocketOption( SocketOptionLevel::Socket, SocketOptionName::Broadcast, 1 );
      }
   }
};