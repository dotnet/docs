

// System.Net.Sockets.TcpListener
/**
* This program shows how to use the TcpListener class. 
* It creates a TcpListener that listen on the specified port (13000). 
* To run this program at the command line you enter:
* cs_tcpserver
* Any TcpClient that wants to use this server
* has to explicitly connect to an address obtained by the combination of
* the sever on which this TcpServer is runnig and the port 13000. 
* This TcpServer simply echoes back the message sent by the TcpClient, after
* translating it into uppercase. 
* To avoid permission settings you can run this console application and the related 
* TcpClient from your hard disk and not from a shared location on the network.
**/
// <Snippet1>
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


// </Snippet1>
ref class tcplistener
{
public:

   // <Snippet2>
   static void GetSetExclusiveAddressUse( TcpListener^ t )
   {
      
      // Set Exclusive Address Use for the underlying socket.
      t->ExclusiveAddressUse = true;
      Console::WriteLine( "ExclusiveAddressUse value is {0}", t->ExclusiveAddressUse );
   }


   // </Snippet2>
   // <Snippet3>
   static void DoStart( TcpListener^ t, int backlog )
   {
      
      // Start listening for client connections with the specified 
      // backlog.
      t->Start( backlog );
      Console::WriteLine( "started listening" );
   }


   // </Snippet3>
   // <Snippet4>
   // Thread signal.
   static ManualResetEvent^ clientConnected = gcnew ManualResetEvent( false );

   // Accept one client connection asynchronously.
   static void DoBeginAcceptSocket( TcpListener^ listener )
   {
      
      // Set the event to nonsignaled state.
      clientConnected->Reset();
      
      // Start to listen for connections from a client.
      Console::WriteLine(  "Waiting for a connection..." );
      
      // Accept the connection. 
      // BeginAcceptSocket() creates the accepted socket.
      listener->BeginAcceptSocket( gcnew AsyncCallback( &tcplistener::DoAcceptSocketCallback ), listener );
      
      // Wait until a connection is made and processed before 
      // continuing.
      clientConnected->WaitOne();
   }


   // Process the client connection.
   static void DoAcceptSocketCallback( IAsyncResult^ ar )
   {
      
      // Get the listener that handles the client request.
      TcpListener^ listener = dynamic_cast<TcpListener^>(ar->AsyncState);
      
      // Get the client socket.
      Socket^ clientSocket = listener->EndAcceptSocket( ar );
      
      // Process the connection here. (Add the client to a server 
      // table, read data, etc.)
      Console::WriteLine(  "Client connected completed" );
      
      // Signal the calling thread to continue.
      clientConnected->Set();
   }


   // </Snippet4>
   // <Snippet5>
   // Thread signal.
   static ManualResetEvent^ tcpClientConnected = gcnew ManualResetEvent( false );

   // Accept one client connection asynchronously.
   static void DoBeginAcceptTcpClient( TcpListener^ listener )
   {
      
      // Set the event to nonsignaled state.
      tcpClientConnected->Reset();
      
      // Start to listen for connections from a client.
      Console::WriteLine(  "Waiting for a connection..." );
      
      // Accept the connection. 
      // BeginAcceptSocket() creates the accepted socket.
      listener->BeginAcceptTcpClient( gcnew AsyncCallback( &tcplistener::DoAcceptTcpClientCallback ), listener );
      
      // Wait until a connection is made and processed before
      // continuing.
      tcpClientConnected->WaitOne();
   }


   // Process the client connection.
   static void DoAcceptTcpClientCallback( IAsyncResult^ ar )
   {
      
      // Get the listener that handles the client request.
      TcpListener^ listener = dynamic_cast<TcpListener^>(ar->AsyncState);
      
      // Get the new TcpClient.
      TcpClient^ client = listener->EndAcceptTcpClient( ar );
      
      // Process the connection here. (Add the client to a server 
      // table, read data, etc.)
      Console::WriteLine(  "Client connected completed" );
      
      // Signal the calling thread to continue.
      tcpClientConnected->Set();
   }

   // </Snippet5>
};

/*int main()
{
    TcpListener* listener = new TcpListener(
                                Dns::GetLocalHostAddresses()[0], 
                                4242);

    tcplistener::GetSetExclusiveAddressUse(listener);

    // Start listening for client connections.
    tcplistener::DoStart(listener, 20);

    // Accept client connections asynchronously
    tcplistener::DoBeginAcceptSocket(listener);
    tcplistener::DoBeginAcceptTcpClient(listener);

    Console::WriteLine("hit any key");
    Console::Read();
 return 0;
}*/
