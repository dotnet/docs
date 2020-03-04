// System.Net.Sockets.TcpClient main functionality. 

/**
* This program shows how to use the TcpClient 
* It creates a TcpClient that connects to a TcpServer listening on the specified port 
* (13000). When connecting to the server it forwards a message, as specified in 
* the input parameter.
* To run this program at the command line you enter:
* cs_tcpclient serverName S"My message"
* Where the serverName is the name on which the server is running.
* For this program to work you need to have the TcpServer running in another
* console window.
* To avoid permission settings you can run this console application and the related 
* TcpServer from your hard disk and not from a shared location on the network.
**/

#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Net;
using namespace System::Net::Sockets;
using namespace System::Text;
using namespace System::Security::Permissions;

/**
* The following function creates a TcpClient that connects to a 
* TcpServer listening on the specified port (13000). 
* When connecting to the server it forwards a message, as specified in 
* the input parameter.
**/
// <Snippet1>
void Connect( String^ server, String^ message )
{
   try
   {
      // Create a TcpClient.
      // Note, for this client to work you need to have a TcpServer 
      // connected to the same address as specified by the server, port
      // combination.
      Int32 port = 13000;
      TcpClient^ client = gcnew TcpClient( server,port );
      
      // Translate the passed message into ASCII and store it as a Byte array.
      array<Byte>^data = Text::Encoding::ASCII->GetBytes( message );
      
      // Get a client stream for reading and writing.
      //  Stream stream = client->GetStream();

      NetworkStream^ stream = client->GetStream();
      
      // Send the message to the connected TcpServer. 
      stream->Write( data, 0, data->Length );

      Console::WriteLine( "Sent: {0}", message );
      
      // Receive the TcpServer::response.

      // Buffer to store the response bytes.
      data = gcnew array<Byte>(256);

      // String to store the response ASCII representation.
      String^ responseData = String::Empty;
      
      // Read the first batch of the TcpServer response bytes.
      Int32 bytes = stream->Read( data, 0, data->Length );
      responseData = Text::Encoding::ASCII->GetString( data, 0, bytes );
      Console::WriteLine( "Received: {0}", responseData );
      
      // Close everything.
      client->Close();
   }
   catch ( ArgumentNullException^ e ) 
   {
      Console::WriteLine( "ArgumentNullException: {0}", e );
   }
   catch ( SocketException^ e ) 
   {
      Console::WriteLine( "SocketException: {0}", e );
   }

   Console::WriteLine( "\n Press Enter to continue..." );
   Console::Read();
}
// </Snippet1>

void main( int argc, char *argv[] )
{
   // Parse arguments
   String^ server;
   String^ message;
   if ( argc < 3 )
   {
      message = "This is a test!";
      if ( argc == 1 )
      {
         server = "localhost";
      }
      else
      {
         server = gcnew String(argv[ 1 ]);
      }
   }
   else
   {
      message = gcnew String(argv[ 2 ]);
      server = gcnew String(argv[ 1 ]);
   }
   
   // Connect to server
   Connect( server, message );
}
