

#using <System.dll>

using namespace System;
using namespace System::Text;
using namespace System::IO;
using namespace System::Net;
using namespace System::Net::Sockets;
using namespace System::Threading;
ref class ConnectTester
{
public:

   //<Snippet1>
   static ManualResetEvent^ allDone = gcnew ManualResetEvent( false );

   // handles the completion of the prior asynchronous 
   // connect call. the socket is passed via the objectState 
   // paramater of BeginConnect().
   static void ConnectCallback1( IAsyncResult^ ar )
   {
      allDone->Set();
      Socket^ s = dynamic_cast<Socket^>(ar->AsyncState);
      s->EndConnect( ar );
   }


   //</Snippet1>
   //<Snippet7>
   // Asynchronous connect using the host name, resolved via 
   // IPAddress
   static void BeginConnect1( String^ host, int port )
   {
      array<IPAddress^>^IPs = Dns::GetHostAddresses( host );
      Socket^ s = gcnew Socket( AddressFamily::InterNetwork,SocketType::Stream,ProtocolType::Tcp );
      allDone->Reset();
      Console::WriteLine( "Establishing Connection to {0}", host );
      s->BeginConnect( IPs[ 0 ], port, gcnew AsyncCallback( ConnectCallback1 ), s );
      
      // wait here until the connect finishes.  
      // The callback sets allDone.
      allDone->WaitOne();
      Console::WriteLine( "Connection established" );
   }


   //</Snippet7>
   //<Snippet2>
   // Asynchronous connect, using DNS.ResolveToAddresses
   static void BeginConnect2( String^ host, int port )
   {
      array<IPAddress^>^IPs = Dns::GetHostAddresses( host );
      Socket^ s = gcnew Socket( AddressFamily::InterNetwork,SocketType::Stream,ProtocolType::Tcp );
      allDone->Reset();
      Console::WriteLine( "Establishing Connection to {0}", host );
      s->BeginConnect( IPs, port, gcnew AsyncCallback( ConnectCallback1 ), s );
      
      // wait here until the connect finishes.  The callback 
      // sets allDone.
      allDone->WaitOne();
      Console::WriteLine( "Connection established" );
   }


   //</Snippet2>
   //<Snippet3>
   // Asynchronous connect using host name (resolved by the 
   // BeginConnect call.)
   static void BeginConnect3( String^ host, int port )
   {
      Socket^ s = gcnew Socket( AddressFamily::InterNetwork,SocketType::Stream,ProtocolType::Tcp );
      allDone->Reset();
      Console::WriteLine( "Establishing Connection to {0}", host );
      s->BeginConnect( host, port, gcnew AsyncCallback( ConnectCallback1 ), s );
      
      // wait here until the connect finishes.  The callback 
      // sets allDone.
      allDone->WaitOne();
      Console::WriteLine( "Connection established" );
   }


   //</Snippet3>
   //<Snippet4>
   // Synchronous connect using IPAddress to resolve the 
   // host name.
   static void Connect1( String^ host, int port )
   {
      array<IPAddress^>^IPs = Dns::GetHostAddresses( host );
      Socket^ s = gcnew Socket( AddressFamily::InterNetwork,SocketType::Stream,ProtocolType::Tcp );
      Console::WriteLine( "Establishing Connection to {0}", host );
      s->Connect( IPs[ 0 ], port );
      Console::WriteLine( "Connection established" );
   }


   //</Snippet4>
   //<Snippet5>
   // Synchronous connect using Dns.ResolveToAddresses to 
   // resolve the host name.
   static void Connect2( String^ host, int port )
   {
      array<IPAddress^>^IPs = Dns::GetHostAddresses( host );
      Socket^ s = gcnew Socket( AddressFamily::InterNetwork,SocketType::Stream,ProtocolType::Tcp );
      Console::WriteLine( "Establishing Connection to {0}", host );
      s->Connect( IPs, port );
      Console::WriteLine( "Connection established" );
   }


   //</Snippet5>
   //<Snippet6>
   // Synchronous connect using host name (resolved by the 
   // Connect call.)
   static void Connect3( String^ host, int port )
   {
      Socket^ s = gcnew Socket( AddressFamily::InterNetwork,SocketType::Stream,ProtocolType::Tcp );
      Console::WriteLine( "Establishing Connection to {0}", host );
      s->Connect( host, port );
      Console::WriteLine( "Connection established" );
   }

   //</Snippet6>
};


[STAThread]
int main()
{
   ConnectTester::BeginConnect1( "127.0.0.1", 80 );
   ConnectTester::BeginConnect2( "localhost", 80 );
   ConnectTester::BeginConnect3( "localhost", 80 );
   ConnectTester::Connect1( "127.0.0.1", 80 );
   ConnectTester::Connect2( "127.0.0.1", 80 );
   ConnectTester::Connect3( "localhost", 80 );
   Console::WriteLine( "hit any key" );
   Console::Read();
}

