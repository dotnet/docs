

// <Snippet1>
#using <system.dll>

using namespace System;
using namespace System::Net;
using namespace System::Net::Sockets;
int main()
{
   
   // This is a Windows Sockets 2 error code.
   const int WSAETIMEDOUT = 10060;
   Socket^ serverSocket;
   int bytesReceived;
   int totalReceived = 0;
   array<Byte>^receivedData = gcnew array<Byte>(2000000);
   
   // Create random data to send to the client.
   array<Byte>^dataToSend = gcnew array<Byte>(2000000);
   (gcnew Random)->NextBytes( dataToSend );
   IPAddress^ ipAddress = Dns::Resolve( Dns::GetHostName() )->AddressList[ 0 ];
   IPEndPoint^ ipEndpoint = gcnew IPEndPoint( ipAddress,1800 );
   
   // Create a socket and listen for incoming connections.
   Socket^ listenSocket = gcnew Socket( AddressFamily::InterNetwork,SocketType::Stream,ProtocolType::Tcp );
   try
   {
      listenSocket->Bind( ipEndpoint );
      listenSocket->Listen( 1 );
      
      // Accept a connection and create a socket to handle it.
      serverSocket = listenSocket->Accept();
      Console::WriteLine( "Server is connected.\n" );
   }
   finally
   {
      listenSocket->Close();
   }

   try
   {
      
      // Send data to the client.
      Console::Write( "Sending data ... " );
      int bytesSent = serverSocket->Send( dataToSend, 0, dataToSend->Length, SocketFlags::None );
      Console::WriteLine( "{0} bytes sent.\n", bytesSent.ToString() );
      
      // Set the timeout for receiving data to 2 seconds.
      serverSocket->SetSocketOption( SocketOptionLevel::Socket, SocketOptionName::ReceiveTimeout, 2000 );
      
      // Receive data from the client.
      Console::Write( "Receiving data ... " );
      try
      {
         do
         {
            bytesReceived = serverSocket->Receive( receivedData, 0, receivedData->Length, SocketFlags::None );
            totalReceived += bytesReceived;
         }
         while ( bytesReceived != 0 );
      }
      catch ( SocketException^ e ) 
      {
         if ( e->ErrorCode == WSAETIMEDOUT )
         {
            
            // Data was not received within the given time.
            // Assume that the transmission has ended.
         }
         else
         {
            Console::WriteLine( "{0}: {1}\n", e->GetType()->Name, e->Message );
         }
      }
      finally
      {
         Console::WriteLine( "{0} bytes received.\n", totalReceived.ToString() );
      }

   }
   finally
   {
      serverSocket->Shutdown( SocketShutdown::Both );
      Console::WriteLine( "Connection shut down." );
      serverSocket->Close();
   }

}

// </Snippet1>
