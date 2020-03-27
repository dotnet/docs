

// <Internal>
// This program contains snippets for the following members:
// 1) System::Net::Sockets::MulticastOption;
// 2) System::Net::Sockets::MulticastOption.MulticastOption(IPAddress, IPAddress);
// 3) System::Net::Sockets::MulticastOption.Group;
// 4) System::Net::Sockets::MulticastOption.LocalAddress;
// </Internal>
//<Snippet1>
#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Net::Sockets;
using namespace System::Text;

// This program shows how to use the MultiCastOption type. In particular,
// it shows how to use the MultiCastOption(IPAddress, IPAddress) constructor,
// You need to use this constructor, in the case of multihomed host (i.e.,
// a host with more than one network card). With the first parameter you
// specify the multicast group address, with the second you specify the
// local address of one of the network cards you want to use for the data
// exchange.
// You must run this program in conjunction with the sender program as
// follows:
// Open a console window and run the listener from the command line.
// In another console window run the sender. In both cases you must specify
// the local IPAddress to use. To obtain this address run the ipconfig from
// the command line.
//
public ref class TestMulticastOption
{
private:
   static IPAddress^ mcastAddress;
   static int mcastPort;
   static Socket^ mcastSocket;
   static MulticastOption^ mcastOption;

   // <Snippet3>
   static void MulticastOptionProperties()
   {
      Console::WriteLine( "Current multicast group is: {0}", mcastOption->Group );
      Console::WriteLine( "Current multicast local address is: {0}", mcastOption->LocalAddress );
   }


   // </Snippet3>
   static void StartMulticast()
   {
      try
      {
         mcastSocket = gcnew Socket( AddressFamily::InterNetwork,SocketType::Dgram,ProtocolType::Udp );
         Console::Write( "Enter the local IP Address: " );
         IPAddress^ localIPAddr = IPAddress::Parse( Console::ReadLine() );
         
         //IPAddress localIP = IPAddress::Any;
         EndPoint^ localEP = dynamic_cast<EndPoint^>(gcnew IPEndPoint( localIPAddr,mcastPort ));
         mcastSocket->Bind( localEP );
         
         // <Snippet2>
         // Define a MuticastOption object specifying the multicast group
         // address and the local IPAddress.
         // The multicast group address is the same one used by the server.
         mcastOption = gcnew MulticastOption( mcastAddress,localIPAddr );
         mcastSocket->SetSocketOption( SocketOptionLevel::IP, SocketOptionName::AddMembership, mcastOption );
         
         // </Snippet2>
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( e );
      }

   }

   static void ReceiveBrodcastMessages()
   {
      bool done = false;
      array<Byte>^bytes = gcnew array<Byte>(100);
      IPEndPoint^ groupEP = gcnew IPEndPoint( mcastAddress,mcastPort );
      EndPoint^ remoteEP = dynamic_cast<EndPoint^>(gcnew IPEndPoint( IPAddress::Any,0 ));
      try
      {
         while (  !done )
         {
            Console::WriteLine( "Waiting for Multicast packets......." );
            Console::WriteLine( "Enter ^C to terminate." );
            mcastSocket->ReceiveFrom( bytes, remoteEP );
            Console::WriteLine( "Received broadcast from {0} :\n {1}\n", groupEP, Encoding::ASCII->GetString( bytes, 0, bytes->Length ) );
         }
         mcastSocket->Close();
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( e );
      }

   }


public:
   static void Main()
   {
      
      // Initialize multicast address group and multicast port.
      // Both address and port are selected from the allowed sets as
      // defined in the related RFC documents. These are the same values
      // used by the sender.
      mcastAddress = IPAddress::Parse( "224.168.100.2" );
      mcastPort = 11000;
      
      // Start a multicast group.
      StartMulticast();
      
      // Display multicast option properties.
      MulticastOptionProperties();
      
      // Receive brodcast messages.
      ReceiveBrodcastMessages();
   }

};

int main()
{
   TestMulticastOption::Main();
}

// </Snippet1>
