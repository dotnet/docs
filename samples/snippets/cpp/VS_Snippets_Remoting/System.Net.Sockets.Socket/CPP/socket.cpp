

/**
* File name:socket.cs.
* This example creates a Socket connection to the server specified by the user,
* using port 80. Once the connection has been established it asks the server for
* the content of its home page. If no server name is passed as argument to this
* program, it uses the current host name as default server.
* */
//<Snippet1>
#using <System.dll>

using namespace System;
using namespace System::Text;
using namespace System::IO;
using namespace System::Net;
using namespace System::Net::Sockets;
using namespace System::Collections;
Socket^ ConnectSocket( String^ server, int port )
{
   Socket^ s = nullptr;
   IPHostEntry^ hostEntry = nullptr;
   
   // Get host related information.
   hostEntry = Dns::Resolve( server );
   
   // Loop through the AddressList to obtain the supported AddressFamily. This is to avoid
   // an exception that occurs when the host IP Address is not compatible with the address family
   // (typical in the IPv6 case).
   IEnumerator^ myEnum = hostEntry->AddressList->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      IPAddress^ address = safe_cast<IPAddress^>(myEnum->Current);
      IPEndPoint^ endPoint = gcnew IPEndPoint( address,port );
      Socket^ tmpS = gcnew Socket( endPoint->AddressFamily,SocketType::Stream,ProtocolType::Tcp );
      tmpS->Connect( endPoint );
      if ( tmpS->Connected )
      {
         s = tmpS;
         break;
      }
      else
      {
         continue;
      }
   }

   return s;
}


// This method requests the home page content for the specified server.
String^ SocketSendReceive( String^ server, int port )
{
   String^ request = String::Concat( "GET / HTTP/1.1\r\nHost: ", server, "\r\nConnection: Close\r\n\r\n" );
   array<Byte>^bytesSent = Encoding::ASCII->GetBytes( request );
   array<Byte>^bytesReceived = gcnew array<Byte>(256);
   
   // Create a socket connection with the specified server and port.
   Socket^ s = ConnectSocket( server, port );
   if ( s == nullptr )
      return ("Connection failed");

   
   // Send request to the server.
   s->Send( bytesSent, bytesSent->Length, static_cast<SocketFlags>(0) );
   
   // Receive the server home page content.
   int bytes = 0;
   String^ strRetPage = String::Concat( "Default HTML page on ", server, ":\r\n" );
   do
   {
      bytes = s->Receive( bytesReceived, bytesReceived->Length, static_cast<SocketFlags>(0) );
      strRetPage = String::Concat( strRetPage, Encoding::ASCII->GetString( bytesReceived, 0, bytes ) );
   }
   while ( bytes > 0 );

   return strRetPage;
}

int main()
{
   array<String^>^args = Environment::GetCommandLineArgs();
   String^ host;
   int port = 80;
   if ( args->Length == 1 )
      
   // If no server name is passed as argument to this program, 
   // use the current host name as default.
   host = Dns::GetHostName();
   else
      host = args[ 1 ];

   String^ result = SocketSendReceive( host, port );
   Console::WriteLine( result );
}

//</Snippet1>
