#using <System.dll>

using namespace System;
using namespace System::Text;
using namespace System::IO;
using namespace System::Net;
using namespace System::Net::Sockets;

int main()
{
   
   //Set up variables and String to write to the server.
   Encoding^ ASCII = Encoding::ASCII;
   String^ Get = "GET / HTTP/1.1\r\nHost: www.contoso.com" +
      "\r\nConnection: Close\r\n\r\n";
   array<Byte>^ ByteGet = ASCII->GetBytes( Get );
   array<Byte>^ RecvBytes = gcnew array<Byte>(256);
   String^ strRetPage = nullptr;
   
   // IPAddress and IPEndPoint represent the endpoint that will
   //   receive the request.
   // Get first IPAddress in list return by DNS.
   IPAddress^ hostadd = Dns::GetHostEntry( "www.contoso.com" )->AddressList[ 0 ];
   IPEndPoint^ EPhost = gcnew IPEndPoint( hostadd,80 );
   
   //<Snippet1>
   //Creates the Socket for sending data over TCP.
   Socket^ s = gcnew Socket( AddressFamily::InterNetwork, SocketType::Stream,
      ProtocolType::Tcp );
   
   // Connects to host using IPEndPoint.
   s->Connect( EPhost );
   if ( !s->Connected )
   {
      strRetPage = "Unable to connect to host";
   }
   // Use the SelectWrite enumeration to obtain Socket status.
   if ( s->Poll( -1, SelectMode::SelectWrite ) )
   {
      Console::WriteLine( "This Socket is writable." );
   }
   else if ( s->Poll(  -1, SelectMode::SelectRead ) )
   {
      Console::WriteLine( "This Socket is readable." );
   }
   else if ( s->Poll(  -1, SelectMode::SelectError ) )
   {
      Console::WriteLine( "This Socket has an error." );
   }
   //</Snippet1>

   // Sent the GET text to the host.
   s->Send( ByteGet, ByteGet->Length, SocketFlags::None );
   
   // Receives the page, loops until all bytes are received.
   Int32 bytes = s->Receive( RecvBytes, RecvBytes->Length, SocketFlags::None );
   strRetPage = "Default HTML page on www.contoso.com:\r\n";
   strRetPage = String::Concat( strRetPage, ASCII->GetString( RecvBytes, 0, bytes ) );

   while ( bytes > 0 )
   {
      bytes = s->Receive( RecvBytes, RecvBytes->Length, SocketFlags::None );
      strRetPage = String::Concat( strRetPage, ASCII->GetString( RecvBytes, 0, bytes ) );
   }
}
