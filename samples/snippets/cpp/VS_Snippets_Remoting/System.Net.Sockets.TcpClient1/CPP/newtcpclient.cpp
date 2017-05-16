

// This is the main project file for VC++ application project 
// generated using an Application Wizard.
#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Net::Sockets;
using namespace System::Threading;

ref class TcpClientExamples
{
public:

   // <Snippet1>
   static void GetAvailable( TcpClient^ t )
   {
      // Find out how many bytes are ready to be read.
      Console::WriteLine( "Available value is {0}", t->Available.ToString() );
      ;
   }
   // </Snippet1>

   // <Snippet2>
   static void GetConnected( TcpClient^ t )
   {
      // Find out whether the socket is connected to the remote 
      // host.
      Console::WriteLine( "Connected value is {0}", t->Connected.ToString() );
      ;
   }
   // </Snippet2>

   // <Snippet3>
   static void GetSetExclusiveAddressUse( TcpClient^ t )
   {
      // Don't allow another process to bind to this port.
      t->ExclusiveAddressUse = true;
      Console::WriteLine( "ExclusiveAddressUse value is {0}", t->ExclusiveAddressUse.ToString() );
      ;
   }
   // </Snippet3>

   // <Snippet8>
   static void DoConnect( String^ host, int port )
   {
      // Connect to the specified host.
      TcpClient^ t = gcnew TcpClient( AddressFamily::InterNetwork );
      array<IPAddress^>^IPAddresses = Dns::GetHostAddresses( host );
      Console::WriteLine( "Establishing Connection to {0}", host );
      t->Connect( IPAddresses, port );
      Console::WriteLine( "Connection established" );
   }
   // </Snippet8>    

   // <Snippet7>
   static ManualResetEvent^ connectDone = gcnew ManualResetEvent( false );
   static void ConnectCallback( IAsyncResult^ ar )
   {
      connectDone->Set();
      TcpClient^ t = safe_cast<TcpClient^>(ar->AsyncState);
      t->EndConnect( ar );
   }
   // </Snippet7>

   // <Snippet4>
   static void DoBeginConnect1( String^ host, int port )
   {
      // Connect asynchronously to the specifed host.
      TcpClient^ t = gcnew TcpClient( AddressFamily::InterNetwork );
//      IPAddress^ remoteHost = gcnew IPAddress( host );
      array<IPAddress^>^ remoteHost = Dns::GetHostAddresses( host );
      connectDone->Reset();
      Console::WriteLine( "Establishing Connection to {0}", host );
      t->BeginConnect( remoteHost, port, gcnew AsyncCallback( &ConnectCallback ), t );

      // Wait here until the callback processes the connection.
      connectDone->WaitOne();
      Console::WriteLine( "Connection established" );
   }
   // </Snippet4>

   // <Snippet5>
   // Connect asynchronously to the specifed host.
   static void DoBeginConnect2( String^ host, int port )
   {
      TcpClient^ t = gcnew TcpClient( AddressFamily::InterNetwork );
      array<IPAddress^>^remoteHost = Dns::GetHostAddresses( host );
      connectDone->Reset();
      Console::WriteLine( "Establishing Connection to {0}", host );
      t->BeginConnect( remoteHost, port, gcnew AsyncCallback(  &ConnectCallback ), t );

      // Wait here until the callback processes the connection.
      connectDone->WaitOne();
      Console::WriteLine( "Connection established" );
   }
   // </Snippet5>

   // <Snippet6>
   // Connect asynchronously to the specifed host.
   static void DoBeginConnect3( String^ host, int port )
   {
      TcpClient^ t = gcnew TcpClient( AddressFamily::InterNetwork );
      connectDone->Reset();
      Console::WriteLine( "Establishing Connection to {0}", host );
      t->BeginConnect( host, port, gcnew AsyncCallback(  &ConnectCallback ), t );
      
      // Wait here until the callback processes the connection.
      connectDone->WaitOne();
      Console::WriteLine( "Connection established" );
   }
   // </Snippet6>
};

int main()
{
   TcpClient^ t;

   // The TCP socket.
   t = gcnew TcpClient(  "localhost",80 );
   TcpClientExamples::GetConnected( t );
   TcpClientExamples::GetAvailable( t );
   TcpClientExamples::GetSetExclusiveAddressUse( t );
   TcpClientExamples::DoConnect(  "127.0.0.1", 80 );
   TcpClientExamples::DoBeginConnect1(  "127.0.0.1", 80 );
   TcpClientExamples::DoBeginConnect2(  "127.0.0.1", 80 );
   TcpClientExamples::DoBeginConnect3(  "127.0.0.1", 80 );
   Console::WriteLine( "enter to exit" );
   Console::Read();
}
