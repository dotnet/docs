#using <System.dll>

using namespace System;
using namespace System::Text;
using namespace System::IO;
using namespace System::Net;
using namespace System::Net::Sockets;
using namespace System::Threading;

//<Snippet1>
// Displays sending with a connected socket
// using the overload that takes a buffer.
int SendReceiveTest1( Socket^ server )
{
   array<Byte>^ msg = Encoding::UTF8->GetBytes( "This is a test" );
   array<Byte>^ bytes = gcnew array<Byte>(256);
   try
   {
      // Blocks until send returns.
      int byteCount = server->Send( msg );
      Console::WriteLine( "Sent {0} bytes.", byteCount.ToString() );
      
      // Get reply from the server.
      byteCount = server->Receive( bytes );
      if ( byteCount > 0 )
      {
         Console::WriteLine( Encoding::UTF8->GetString( bytes ) );
      }
   }
   catch ( SocketException^ e ) 
   {
      Console::WriteLine( "{0} Error code: {1}.", e->Message, e->ErrorCode.ToString() );
      return ( e->ErrorCode );
   }
   return 0;
}
//</Snippet1>

// Displays receiving from a connected tcp socket
// using the overload that takes a buffer.
int ReceiveTest1( Socket^ client )
{
   array<Byte>^ bytes = gcnew array<Byte>(256);
   try
   {
      // It is usually preferable to use the overload
      // that allows you to specify the maximum bytes returned.
      if ( client->Available > 256 )
      {
         throw gcnew ApplicationException( "This test socket only takes messages < 256 bytes." );
      }
      // Blocks until read returns.
      int byteCount = client->Receive( bytes );
      if ( byteCount > 0 )
      {
         Console::WriteLine( Encoding::UTF8->GetString( bytes ) );
      }
      // Send reply to the client.
      client->Send( Encoding::UTF8->GetBytes( "Bye." ) );
   }
   catch ( SocketException^ e ) 
   {
      Console::WriteLine( "{0} Error code: {1}.", e->Message, e->ErrorCode.ToString() );
      return ( e->ErrorCode );
   }
   return 0;
}

//<Snippet2>
// Displays sending with a connected socket
// using the overload that takes a buffer and socket flags.
int SendReceiveTest2( Socket^ server )
{
   array<Byte>^ msg = Encoding::UTF8->GetBytes( "This is a test" );
   array<Byte>^ bytes = gcnew array<Byte>(256);
   try
   {
      // Blocks until send returns.
      int byteCount = server->Send( msg, SocketFlags::None );
      Console::WriteLine( "Sent {0} bytes.", byteCount.ToString() );
      
      // Get reply from the server.
      byteCount = server->Receive( bytes, SocketFlags::None );
      if ( byteCount > 0 )
      {
         Console::WriteLine( Encoding::UTF8->GetString( bytes ) );
      }
   }
   catch ( SocketException^ e ) 
   {
      Console::WriteLine( "{0} Error code: {1}.", e->Message, e->ErrorCode.ToString() );
      return (e->ErrorCode);
   }
   return 0;
}
//</Snippet2>

//<Snippet3>
// Displays sending with a connected socket
// using the overload that takes a buffer, message size, and socket flags.
int SendReceiveTest3( Socket^ server )
{
   array<Byte>^ msg = Encoding::UTF8->GetBytes( "This is a test" );
   array<Byte>^ bytes = gcnew array<Byte>(256);
   try
   {
      // Blocks until send returns.
      int i = server->Send( msg, msg->Length, SocketFlags::None );
      Console::WriteLine( "Sent {0} bytes.", i.ToString() );
      
      // Get reply from the server.
      int byteCount = server->Receive( bytes, server->Available,
         SocketFlags::None );
      if ( byteCount > 0 )
      {
         Console::WriteLine( Encoding::UTF8->GetString( bytes ) );
      }
   }
   catch ( SocketException^ e ) 
   {
      Console::WriteLine( "{0} Error code: {1}.", e->Message, e->ErrorCode.ToString() );
      return (e->ErrorCode);
   }
   return 0;
}
//</Snippet3>

//<Snippet4>
// Displays sending with a connected socket
// using the overload that takes a buffer, offset, message size, and socket flags.
int SendReceiveTest4( Socket^ server )
{
   array<Byte>^ msg = Encoding::UTF8->GetBytes( "This is a test" );
   array<Byte>^ bytes = gcnew array<Byte>(256);
   try
   {
      
      // Blocks until send returns.
      int byteCount = server->Send( msg, 0, msg->Length, SocketFlags::None );
      Console::WriteLine( "Sent {0} bytes.", byteCount.ToString() );
      
      // Get reply from the server.
      byteCount = server->Receive( bytes, 0, server->Available,
         SocketFlags::None );
      if ( byteCount > 0 )
      {
         Console::WriteLine( Encoding::UTF8->GetString( bytes ) );
      }
   }
   catch ( SocketException^ e ) 
   {
      Console::WriteLine(  "{0} Error code: {1}.", e->Message, e->ErrorCode.ToString() );
      return (e->ErrorCode);
   }
   return 0;
}
//</Snippet4>

public ref class NeedForDelegates
{
public:

   //<Snippet5>
   static void SendTo1()
   {
      IPHostEntry^ hostEntry = Dns::Resolve( Dns::GetHostName() );
      IPEndPoint^ endPoint = gcnew IPEndPoint( hostEntry->AddressList[ 0 ],11000 );

      Socket^ s = gcnew Socket( endPoint->Address->AddressFamily,
         SocketType::Dgram,
         ProtocolType::Udp );

      array<Byte>^ msg = Encoding::ASCII->GetBytes( "This is a test" );
      Console::WriteLine( "Sending data." );
      // This call blocks. 
      s->SendTo( msg, endPoint );
      s->Close();
   }
   //</Snippet5>

   //<Snippet6>  
   static void SendTo2()
   {
      IPHostEntry^ hostEntry = Dns::Resolve( Dns::GetHostName() );
      IPEndPoint^ endPoint = gcnew IPEndPoint( hostEntry->AddressList[ 0 ],11000 );

      Socket^ s = gcnew Socket( endPoint->Address->AddressFamily,
         SocketType::Dgram,
         ProtocolType::Udp );

      array<Byte>^ msg = Encoding::ASCII->GetBytes( "This is a test" );
      Console::WriteLine( "Sending data." );
      // This call blocks. 
      s->SendTo( msg, SocketFlags::None, endPoint );
      s->Close();
   }
   //</Snippet6>

   //<Snippet7> 
   static void SendTo3()
   {
      IPHostEntry^ hostEntry = Dns::Resolve( Dns::GetHostName() );
      IPEndPoint^ endPoint = gcnew IPEndPoint( hostEntry->AddressList[ 0 ],11000 );

      Socket^ s = gcnew Socket( endPoint->Address->AddressFamily,
         SocketType::Dgram,
         ProtocolType::Udp );

      array<Byte>^ msg = Encoding::ASCII->GetBytes( "This is a test" );
      Console::WriteLine( "Sending data." );
      // This call blocks. 
      s->SendTo( msg, msg->Length, SocketFlags::None, endPoint );
      s->Close();
   }
   //</Snippet7>

   //<Snippet8>
   static void SendTo4()
   {
      IPHostEntry^ hostEntry = Dns::Resolve( Dns::GetHostName() );
      IPEndPoint^ endPoint = gcnew IPEndPoint( hostEntry->AddressList[ 0 ],11000 );

      Socket^ s = gcnew Socket( endPoint->Address->AddressFamily,
         SocketType::Dgram,
         ProtocolType::Udp );

      array<Byte>^ msg = Encoding::ASCII->GetBytes( "This is a test" );
      Console::WriteLine( "Sending data." );
      // This call blocks. 
      s->SendTo( msg, 0, msg->Length, SocketFlags::None, endPoint );
      s->Close();
   }
   //</Snippet8>

   // The ReceiveFroms
   //<Snippet9>
   static void ReceiveFrom1()
   {
      IPHostEntry^ hostEntry = Dns::Resolve( Dns::GetHostName() );
      IPEndPoint^ endPoint = gcnew IPEndPoint( hostEntry->AddressList[ 0 ],11000 );

      Socket^ s = gcnew Socket( endPoint->Address->AddressFamily,
         SocketType::Dgram,
         ProtocolType::Udp );
      
      // Creates an IPEndPoint to capture the identity of the sending host.
      IPEndPoint^ sender = gcnew IPEndPoint( IPAddress::Any,0 );
      EndPoint^ senderRemote = safe_cast<EndPoint^>(sender);
      
      // Binding is required with ReceiveFrom calls.
      s->Bind( endPoint );

      array<Byte>^ msg = gcnew array<Byte>(256);
      Console::WriteLine( "Waiting to receive datagrams from client..." );
      
      // This call blocks. 
      s->ReceiveFrom( msg, senderRemote );
      s->Close();
   }
   //</Snippet9>

   //<Snippet10>  
   static void ReceiveFrom2()
   {
      IPHostEntry^ hostEntry = Dns::Resolve( Dns::GetHostName() );
      IPEndPoint^ endPoint = gcnew IPEndPoint( hostEntry->AddressList[ 0 ],11000 );

      Socket^ s = gcnew Socket( endPoint->Address->AddressFamily,
         SocketType::Dgram,
         ProtocolType::Udp );
      
      // Creates an IpEndPoint to capture the identity of the sending host.
      IPEndPoint^ sender = gcnew IPEndPoint( IPAddress::Any,0 );
      EndPoint^ senderRemote = safe_cast<EndPoint^>(sender);
      
      // Binding is required with ReceiveFrom calls.
      s->Bind( endPoint );

      array<Byte>^ msg = gcnew array<Byte>(256);
      Console::WriteLine( "Waiting to receive datagrams from client..." );
      // This call blocks. 
      s->ReceiveFrom( msg, SocketFlags::None, senderRemote );
      s->Close();
   }
   //</Snippet10>

   //<Snippet11> 
   static void ReceiveFrom3()
   {
      IPHostEntry^ hostEntry = Dns::Resolve( Dns::GetHostName() );
      IPEndPoint^ endPoint = gcnew IPEndPoint( hostEntry->AddressList[ 0 ],11000 );

      Socket^ s = gcnew Socket( endPoint->Address->AddressFamily,
         SocketType::Dgram,
         ProtocolType::Udp );
      
      // Creates an IPEndPoint to capture the identity of the sending host.
      IPEndPoint^ sender = gcnew IPEndPoint( IPAddress::Any,0 );
      EndPoint^ senderRemote = safe_cast<EndPoint^>(sender);
      
      // Binding is required with ReceiveFrom calls.
      s->Bind( endPoint );

      array<Byte>^ msg = gcnew array<Byte>(256);
      Console::WriteLine(  "SWaiting to receive datagrams from client..." );
      // This call blocks. 
      s->ReceiveFrom( msg, msg->Length, SocketFlags::None, senderRemote );
      s->Close();
   }
   //</Snippet11>

   //<Snippet12>
   static void ReceiveFrom4()
   {
      IPHostEntry^ hostEntry = Dns::Resolve( Dns::GetHostName() );
      IPEndPoint^ endPoint = gcnew IPEndPoint( hostEntry->AddressList[ 0 ],11000 );

      Socket^ s = gcnew Socket( endPoint->Address->AddressFamily,
         SocketType::Dgram,
         ProtocolType::Udp );
      
      // Creates an IpEndPoint to capture the identity of the sending host.
      IPEndPoint^ sender = gcnew IPEndPoint( IPAddress::Any,0 );
      EndPoint^ senderRemote = safe_cast<EndPoint^>(sender);
      
      // Binding is required with ReceiveFrom calls.
      s->Bind( endPoint );

      array<Byte>^ msg = gcnew array<Byte>(256);
      Console::WriteLine(  "SWaiting to receive datagrams from client..." );
      // This call blocks.  
      s->ReceiveFrom( msg, 0, msg->Length, SocketFlags::None, senderRemote );
      s->Close();
   }
   //</Snippet12>
   // end NeedForDelegates
};

void RunUdpTests()
{
   // Test the upd versions.

   //NeedForDelegates^ n = new NeedForDelegates();
   ThreadStart^ myThreadDelegate = gcnew ThreadStart( &NeedForDelegates::ReceiveFrom1 );
   Thread^ myThread1 = gcnew Thread( myThreadDelegate );
   myThread1->Start();

   while ( myThread1->IsAlive == true )
   {
      NeedForDelegates::SendTo1();
   }
   myThread1->Join();

   Console::WriteLine(  "UDP test2" );
   Thread^ myThread2 = gcnew Thread( gcnew ThreadStart( &NeedForDelegates::ReceiveFrom2 ) );
   myThread2->Start();
   while ( myThread2->IsAlive == true )
   {
      NeedForDelegates::SendTo2();
   }
   myThread2->Join();

   Console::WriteLine(  "UDP test3" );
   Thread^ myThread3 = gcnew Thread( gcnew ThreadStart( &NeedForDelegates::ReceiveFrom3 ) );
   myThread3->Start();
   while ( myThread3->IsAlive == true )
   {
      NeedForDelegates::SendTo3();
   }
   myThread3->Join();

   Console::WriteLine(  "UDP test4" );
   Thread^ myThread4 = gcnew Thread( gcnew ThreadStart( &NeedForDelegates::ReceiveFrom4 ) );
   myThread4->Start();
   while ( myThread4->IsAlive == true )
   {
      NeedForDelegates::SendTo4();
   }
   myThread4->Join();
}

//Main tests the snippets.
// To test tcp - run 2 instances source /s runs server, source /c runs client.
// To test Upd run source /u.
int main( int /*argc*/, char *args[] )
{
   String^ host;
   bool isServer;

   if ( args[ 1 ][ 1 ] == 'c' )
   {
      isServer = false;
      host = "127.0.0.1";
   }
   else
   if ( args[ 1 ][ 1 ] == 'u' )
   {
      Console::WriteLine(  "running udptests" );
      RunUdpTests();
      return 0;
   }
   else
   {
      host = "localhost";
      isServer = true;
   }

   // Set up the endpoint and create the socket.
   IPHostEntry^ hostEntry = Dns::Resolve( host );
   IPEndPoint^ endPoint = gcnew IPEndPoint( hostEntry->AddressList[ 0 ],11000 );
   
   // Test the TCPIP snippets (Socket.Send and Socket.Receive)

   Socket^ s = gcnew Socket( endPoint->Address->AddressFamily,
      SocketType::Stream,
      ProtocolType::Tcp );
   
   // Send or receive the test messages.
   if ( isServer )
   {
      Socket^ sender = nullptr;
      s->Bind( endPoint );
      s->Listen( 1 );
      for ( ; ;  )
      {
         sender = s->Accept();
         // exchange messages with all clients tests 
         for ( int i = 0; i < 4; i++ )
         {
            ReceiveTest1( sender );
         }
         sender->Close();
         s->Close();
         Environment::Exit( 0 );
      }
   }
   // Its the client tcp tests.
   else
   {
      s->Connect( endPoint );
      SendReceiveTest1( s );
      SendReceiveTest2( s );
      SendReceiveTest3( s );
      SendReceiveTest4( s );
      s->Close();
   }

   return 0;
}
