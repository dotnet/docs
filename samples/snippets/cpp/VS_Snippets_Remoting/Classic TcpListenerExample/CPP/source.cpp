//<Snippet1>
/**
* This program shows how to use the TcpListener class. 
* It creates a TcpListener that listens on the specified port (13000). 
* To run this program at the command line you enter:
* cs_tcpserver
* Any TcpClient that wants to use this server
* has to explicitly connect to an address obtained by the combination of
* the server on which this TcpServer is running and the port 13000. 
* This TcpServer simply echoes back the message sent by the TcpClient, after
* translating it into uppercase. 
**/

#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Net;
using namespace System::Net::Sockets;
using namespace System::Text;

int main()
{
   try
   {
      
      // Set the TcpListener on port 13000.
      Int32 port = 13000;
      TcpListener^ server = gcnew TcpListener(IPAddress::Any, port);
      
      // Start listening for client requests.
      server->Start();
      
      // Buffer for reading data
      array<Byte>^bytes = gcnew array<Byte>(256);
      String^ data = nullptr;
      
      // Enter the listening loop.
      while ( true )
      {
         Console::Write( "Waiting for a connection... " );
         
         // Perform a blocking call to accept requests.
         // You could also use server.AcceptSocket() here.
         TcpClient^ client = server->AcceptTcpClient();
         Console::WriteLine( "Connected!" );
         data = nullptr;
         
         // Get a stream object for reading and writing
         NetworkStream^ stream = client->GetStream();
         Int32 i;
         
         // Loop to receive all the data sent by the client.
         while ( (i = stream->Read( bytes, 0, bytes->Length )) != 0 )
         {
            
            // Translate data bytes to a ASCII string.
            data = System::Text::Encoding::ASCII->GetString( bytes, 0, i );
            Console::WriteLine( String::Format( "Received: {0}", data ) );
            
            // Process the data sent by the client.
            data = data->ToUpper();
            array<Byte>^msg = System::Text::Encoding::ASCII->GetBytes( data );
            
            // Send back a response.
            stream->Write( msg, 0, msg->Length );
            Console::WriteLine( String::Format( "Sent: {0}", data ) );
         }
         
         // Shutdown and end connection
         client->Close();
      }
   }
   catch ( SocketException^ e ) 
   {
      Console::WriteLine( "SocketException: {0}", e );
   }

   Console::WriteLine( "\nHit enter to continue..." );
   Console::Read();
}

//</Snippet1>
