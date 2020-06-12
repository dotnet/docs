

#using <system.dll>

using namespace System;
using namespace System::Text;
using namespace System::Net;
using namespace System::Net::Sockets;

int main()
{
   //<Snippet1>
   // With this constructor the local port number is arbitrarily assigned.
   UdpClient^ udpClient = gcnew UdpClient;
   try
   {
      udpClient->Connect( "host.contoso.com", 11000 );

      // Send message to the host to which you have connected.
      array<Byte>^sendBytes = Encoding::ASCII->GetBytes( "Is anybody there?" );
      udpClient->Send( sendBytes, sendBytes->Length );

      // Send message to a different host using optional hostname and port parameters.
      UdpClient^ udpClientB = gcnew UdpClient;
      udpClientB->Send( sendBytes, sendBytes->Length, "AlternateHostMachineName", 11000 );

      //IPEndPoint object will allow us to read datagrams sent from any source.
      IPEndPoint^ RemoteIpEndPoint = gcnew IPEndPoint( IPAddress::Any,0 );

      // Block until a message returns on this socket from a remote host.
      array<Byte>^receiveBytes = udpClient->Receive( RemoteIpEndPoint );
      String^ returnData = Encoding::ASCII->GetString( receiveBytes );

      // Use the IPEndPoint object to determine which of these two hosts responded.
      Console::WriteLine( String::Concat( "This is the message you received ", returnData->ToString() ) );
      Console::WriteLine( String::Concat( "This message was sent from ", RemoteIpEndPoint->Address->ToString(), " on their port number ", RemoteIpEndPoint->Port.ToString() ) );
      udpClient->Close();
      udpClientB->Close();
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( e->ToString() );
   }
   //</Snippet1>
}
