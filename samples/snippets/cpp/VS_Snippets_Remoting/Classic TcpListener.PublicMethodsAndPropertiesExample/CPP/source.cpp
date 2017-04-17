#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Net::Sockets;
using namespace System::Text;
using namespace System::Threading;

int main()
{
   array<String^>^args = Environment::GetCommandLineArgs();
   if ( args->Length == 1 )
   {
      Console::WriteLine( "Enter a selection" );
      return 0;
   }

   if ( args[ 1 ] == "endpointExample" )
   {
      //<Snippet1>
      //Creates an instance of the TcpListener class by providing a local endpoint.

      IPAddress^ ipAddress = Dns::Resolve( Dns::GetHostName() )->AddressList[ 0 ];
      IPEndPoint^ ipLocalEndPoint = gcnew IPEndPoint( ipAddress,11000 );

      try
      {
         TcpListener^ tcpListener = gcnew TcpListener( ipLocalEndPoint );
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( e->ToString() );
      }
      //</Snippet1>
   }
   else
   if ( args[ 1 ] == "ipAddressExample" )
   {
      //<Snippet2>
      //Creates an instance of the TcpListener class by providing a local IP address and port number.

      IPAddress^ ipAddress = Dns::Resolve( "localhost" )->AddressList[ 0 ];

      try
      {
         TcpListener^ tcpListener = gcnew TcpListener( ipAddress,13 );
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( e->ToString() );
      }
      //</Snippet2>
   }
   else
   if ( args[ 1 ] == "portNumberExample" )
   {
      //<Snippet3>
      //Creates an instance of the TcpListener class by providing a local port number.  

      IPAddress^ ipAddress = Dns::Resolve( "localhost" )->AddressList[ 0 ];

      try
      {
         TcpListener^ tcpListener = gcnew TcpListener( ipAddress,13 );
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( e->ToString() );
      }
      //</Snippet3>
   }
   else
   {
      IPAddress^ ipAddress = Dns::Resolve( "localhost" )->AddressList[ 0 ];
      TcpListener^ tcpListener = gcnew TcpListener( ipAddress,13 );
      tcpListener->Start();
      Console::WriteLine( "Waiting for a connection...." );

      try
      {
         //<Snippet4>
         // Accepts the pending client connection and returns a socket for communciation.
         Socket^ socket = tcpListener->AcceptSocket();
         Console::WriteLine( "Connection accepted." );

         String^ responseString = "You have successfully connected to me";
         
         //Forms and sends a response string to the connected client.
         array<Byte>^sendBytes = Encoding::ASCII->GetBytes( responseString );
         int i = socket->Send( sendBytes );
         Console::WriteLine( "Message Sent /> : {0}", responseString );
         //</Snippet4>    

         //Any communication with the remote client using the socket can go here.

         //Closes the tcpListener and the socket.
         socket->Shutdown( SocketShutdown::Both );
         socket->Close();
         tcpListener->Stop();
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( e->ToString() );
      }
   }
}
