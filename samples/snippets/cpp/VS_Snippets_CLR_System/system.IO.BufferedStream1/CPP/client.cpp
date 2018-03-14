

// <Snippet1>
#using <system.dll>

using namespace System;
using namespace System::IO;
using namespace System::Globalization;
using namespace System::Net;
using namespace System::Net::Sockets;
static const int streamBufferSize = 1000;
public ref class Client
{
private:
   literal int dataArraySize = 100;
   literal int numberOfLoops = 10000;
   Client(){}


public:
   static void ReceiveData( Stream^ netStream, Stream^ bufStream )
   {
      DateTime startTime;
      Double networkTime;
      Double bufferedTime = 0;
      int bytesReceived = 0;
      array<Byte>^receivedData = gcnew array<Byte>(dataArraySize);
      
      // Receive data using the NetworkStream.
      Console::WriteLine( "Receiving data using NetworkStream." );
      startTime = DateTime::Now;
      while ( bytesReceived < numberOfLoops * receivedData->Length )
      {
         bytesReceived += netStream->Read( receivedData, 0, receivedData->Length );
      }

      networkTime = (DateTime::Now - startTime).TotalSeconds;
      Console::WriteLine( "{0} bytes received in {1} seconds.\n", bytesReceived.ToString(), networkTime.ToString(  "F1" ) );
      
      // <Snippet7>
      // Receive data using the BufferedStream.
      Console::WriteLine(  "Receiving data using BufferedStream." );
      bytesReceived = 0;
      startTime = DateTime::Now;
      while ( bytesReceived < numberOfLoops * receivedData->Length )
      {
         bytesReceived += bufStream->Read( receivedData, 0, receivedData->Length );
      }

      bufferedTime = (DateTime::Now - startTime).TotalSeconds;
      Console::WriteLine( "{0} bytes received in {1} seconds.\n", bytesReceived.ToString(), bufferedTime.ToString(  "F1" ) );
      
      // </Snippet7>
      // Print the ratio of read times.
      Console::WriteLine( "Receiving data using the buffered "
      "network stream was {0} {1} than using the network "
      "stream alone.", (networkTime / bufferedTime).ToString(  "P0" ), bufferedTime < networkTime ? (String^)"faster" : "slower" );
   }

   static void SendData( Stream^ netStream, Stream^ bufStream )
   {
      DateTime startTime;
      Double networkTime;
      Double bufferedTime;
      
      // Create random data to send to the server.
      array<Byte>^dataToSend = gcnew array<Byte>(dataArraySize);
      (gcnew Random)->NextBytes( dataToSend );
      
      // Send the data using the NetworkStream.
      Console::WriteLine( "Sending data using NetworkStream." );
      startTime = DateTime::Now;
      for ( int i = 0; i < numberOfLoops; i++ )
      {
         netStream->Write( dataToSend, 0, dataToSend->Length );

      }
      networkTime = (DateTime::Now - startTime).TotalSeconds;
      Console::WriteLine( "{0} bytes sent in {1} seconds.\n", (numberOfLoops * dataToSend->Length).ToString(), networkTime.ToString(  "F1" ) );
      
      // <Snippet6>
      // Send the data using the BufferedStream.
      Console::WriteLine( "Sending data using BufferedStream." );
      startTime = DateTime::Now;
      for ( int i = 0; i < numberOfLoops; i++ )
      {
         bufStream->Write( dataToSend, 0, dataToSend->Length );

      }
      bufStream->Flush();
      bufferedTime = (DateTime::Now - startTime).TotalSeconds;
      Console::WriteLine( "{0} bytes sent in {1} seconds.\n", (numberOfLoops * dataToSend->Length).ToString(), bufferedTime.ToString(  "F1" ) );
      
      // </Snippet6>
      // Print the ratio of write times.
      Console::WriteLine( "Sending data using the buffered "
      "network stream was {0} {1} than using the network "
      "stream alone.\n", (networkTime / bufferedTime).ToString(  "P0" ), bufferedTime < networkTime ? (String^)"faster" : "slower" );
   }

};

int main( int argc, char *argv[] )
{
   
   // Check that an argument was specified when the 
   // program was invoked.
   if ( argc == 1 )
   {
      Console::WriteLine( "Error: The name of the host computer"
      " must be specified when the program is invoked." );
      return  -1;
   }

   String^ remoteName = gcnew String( argv[ 1 ] );
   
   // Create the underlying socket and connect to the server.
   Socket^ clientSocket = gcnew Socket( AddressFamily::InterNetwork,SocketType::Stream,ProtocolType::Tcp );
   clientSocket->Connect( gcnew IPEndPoint( Dns::Resolve( remoteName )->AddressList[ 0 ],1800 ) );
   Console::WriteLine(  "Client is connected.\n" );
   
   // <Snippet2>
   // Create a NetworkStream that owns clientSocket and 
   // then create a BufferedStream on top of the NetworkStream.
   NetworkStream^ netStream = gcnew NetworkStream( clientSocket,true );
   BufferedStream^ bufStream = gcnew BufferedStream( netStream,streamBufferSize );
   
   // </Snippet2>
   try
   {
      
      // <Snippet3>
      // Check whether the underlying stream supports seeking.
      Console::WriteLine( "NetworkStream {0} seeking.\n", bufStream->CanSeek ? (String^)"supports" : "does not support" );
      
      // </Snippet3>
      // Send and receive data.
      // <Snippet4>
      if ( bufStream->CanWrite )
      {
         Client::SendData( netStream, bufStream );
      }
      
      // </Snippet4>
      // <Snippet5>
      if ( bufStream->CanRead )
      {
         Client::ReceiveData( netStream, bufStream );
      }
      
      // </Snippet5>
   }
   finally
   {
      
      // <Snippet8>
      // When bufStream is closed, netStream is in turn closed,
      // which in turn shuts down the connection and closes
      // clientSocket.
      Console::WriteLine( "\nShutting down connection." );
      bufStream->Close();
      
      // </Snippet8>
   }

}

// </Snippet1>
