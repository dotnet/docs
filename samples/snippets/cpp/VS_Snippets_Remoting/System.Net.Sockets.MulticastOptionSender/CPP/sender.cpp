

// <Internal>
// This program contains snippets for the following members:
// 1) System::Net::Sockets::MulticastOption;
// </Internal>
// <Snippet1>
#using <System.dll>

using namespace System;
using namespace System::Net::Sockets;
using namespace System::Net;
using namespace System::Text;

// This is an auxiliary program to be used in conjunction with a listener
// program.
// You must run this program as follows:
// Open a console window and run the listener from the command line.
// In another console window run the sender. In both cases you must specify
// the local IPAddress to use. To obtain this address run the ipconfig
// from the command line.
//
ref class TestMulticastOption
{
private:
   static IPAddress^ mcastAddress;
   static int mcastPort;
   static Socket^ mcastSocket;
   static void JoinMulticast()
   {
      try
      {
         
         // Create multicast socket.
         mcastSocket = gcnew Socket( AddressFamily::InterNetwork,SocketType::Dgram,ProtocolType::Udp );
         
         // Get the local IP address used by the listener and the sender to
         // exchange data in a multicast fashion.
         Console::Write( "\nEnter local IPAddress for sending multicast packets: " );
         IPAddress^ localIPAddr = IPAddress::Parse( Console::ReadLine() );
         
         // Create an IPEndPoint Object*.
         IPEndPoint^ IPlocal = gcnew IPEndPoint( localIPAddr,0 );
         
         // Bind this end point to the multicast socket.
         mcastSocket->Bind( IPlocal );
         
         // Define a MuticastOption Object* specifying the multicast group
         // address and the local IPAddress.
         // The multicast group address is the same one used by the listener.
         MulticastOption^ mcastOption;
         mcastOption = gcnew MulticastOption( mcastAddress,localIPAddr );
         mcastSocket->SetSocketOption( SocketOptionLevel::IP, SocketOptionName::AddMembership, mcastOption );
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "\n {0}", e );
      }

   }

   static void BrodcastMessage( String^ message )
   {
      IPEndPoint^ endPoint;
      try
      {
         
         //Send multicast packets to the listener.
         endPoint = gcnew IPEndPoint( mcastAddress,mcastPort );
         mcastSocket->SendTo( ASCIIEncoding::ASCII->GetBytes( message ), endPoint );
         Console::WriteLine( "Multicast data sent....." );
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "\n {0}", e );
      }

      mcastSocket->Close();
   }


public:
   static void main()
   {
      
      // Initialize multicast address group and multicast port.
      // Both address and port are selected from the allowed sets as
      // defined in the related RFC documents. These are the same values
      // used by the sender.
      mcastAddress = IPAddress::Parse( "224.168.100.2" );
      mcastPort = 11000;
      
      // Join the listener multicast group.
      JoinMulticast();
      
      // Broadcast message to the listener.
      BrodcastMessage( "Hello multicast listener." );
   }

};

int main()
{
   TestMulticastOption::main();
}

// </Snippet1>
