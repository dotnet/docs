#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Net;
using namespace System::Net::Sockets;
using namespace System::Text;
using namespace System::Threading;
void main()
{
   try
   {
      
      // Set the TcpListener on port 13000.
      Int32 port = 13000;
      IPAddress^ localAddr = IPAddress::Parse( "127.0.0.1" );
      
      // TcpListener* server = new TcpListener(port);
      TcpListener^ server = gcnew TcpListener( localAddr,port );
      
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
         // You could also user server.AcceptSocket() here.
         TcpClient^ client = server->AcceptTcpClient();
         Console::WriteLine( "Connected!" );
         data = nullptr;
         
         // Get a stream Object* for reading and writing
         NetworkStream^ stream = client->GetStream();
         Int32 i;
         
         // Loop to receive all the data sent by the client.
         while ( i = stream->Read( bytes, 0, bytes->Length ) )
         {
            
            // Translate data bytes to a ASCII String*.
            data = Text::Encoding::ASCII->GetString( bytes, 0, i );
            Console::WriteLine( "Received: {0}", data );
            
            // Process the data sent by the client.
            data = data->ToUpper();
            array<Byte>^msg = Text::Encoding::ASCII->GetBytes( data );
            
            // Send back a response.
            stream->Write( msg, 0, msg->Length );
            Console::WriteLine( "Sent: {0}", data );
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

