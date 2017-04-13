

//NCLPingSampler
//<snippet0>
#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Net::NetworkInformation;
using namespace System::Text;
using namespace System::Threading;

//</snippet0>
void SimplePing();
void ComplexPing();
void LocalPing();
void ComplexLocalPing();
void LocalPingTimeout();
void AsyncComplexLocalPing();
void PingCompletedCallback( Object^ sender, PingCompletedEventArgs^ e );

int main()
{
   
//   SimplePing();
   LocalPing(); Console::WriteLine();
//   ComplexPing();  Console::WriteLine();
   ComplexLocalPing(); Console::WriteLine();
   AsyncComplexLocalPing();
}


//<snippet2>
void SimplePing()
{
   Ping ^ pingSender = gcnew Ping;
   PingReply ^ reply = pingSender->Send( "www.contoso.com" );
   if ( reply->Status == IPStatus::Success )
   {
      Console::WriteLine( "Address: {0}", reply->Address->ToString() );
      Console::WriteLine( "RoundTrip time: {0}", reply->RoundtripTime );
      Console::WriteLine( "Time to live: {0}", reply->Options->Ttl );
      Console::WriteLine( "Don't fragment: {0}", reply->Options->DontFragment );
      Console::WriteLine( "Buffer size: {0}", reply->Buffer->Length );
   }
   else
   {
      Console::WriteLine( reply->Status );
   }
}


//</snippet2>
//<snippet4>
void ComplexPing()
{
   Ping ^ pingSender = gcnew Ping;
   
   // Create a buffer of 32 bytes of data to be transmitted.
   String^ data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
   array<Byte>^buffer = Encoding::ASCII->GetBytes( data );
   
   // Wait 10 seconds for a reply.
   int timeout = 10000;
   
   // Set options for transmission:
   // The data can go through 64 gateways or routers
   // before it is destroyed, and the data packet
   // cannot be fragmented.
   PingOptions ^ options = gcnew PingOptions( 64,true );
   
   // Send the request.
   PingReply ^ reply = pingSender->Send( "www.contoso.com", timeout, buffer, options );
   if ( reply->Status == IPStatus::Success )
   {
      Console::WriteLine( "Address: {0}", reply->Address->ToString() );
      Console::WriteLine( "RoundTrip time: {0}", reply->RoundtripTime );
      Console::WriteLine( "Time to live: {0}", reply->Options->Ttl );
      Console::WriteLine( "Don't fragment: {0}", reply->Options->DontFragment );
      Console::WriteLine( "Buffer size: {0}", reply->Buffer->Length );
   }
   else
   {
      Console::WriteLine( reply->Status );
   }
}


//</snippet4>
//<snippet3>
void LocalPing()
{
   
   // Ping's the local machine.
   Ping ^ pingSender = gcnew Ping;
   IPAddress^ address = IPAddress::Loopback;
   PingReply ^ reply = pingSender->Send( address );
   if ( reply->Status == IPStatus::Success )
   {
      Console::WriteLine( "Address: {0}", reply->Address->ToString() );
      Console::WriteLine( "RoundTrip time: {0}", reply->RoundtripTime );
      Console::WriteLine( "Time to live: {0}", reply->Options->Ttl );
      Console::WriteLine( "Don't fragment: {0}", reply->Options->DontFragment );
      Console::WriteLine( "Buffer size: {0}", reply->Buffer->Length );
   }
   else
   {
      Console::WriteLine( reply->Status );
   }
}


//</snippet3>
//<snippet5>
void ComplexLocalPing()
{
   
   // Ping's the local machine.
   Ping ^ pingSender = gcnew Ping;
   IPAddress^ address = IPAddress::Loopback;
   
   // Create a buffer of 32 bytes of data to be transmitted.
   String^ data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
   array<Byte>^buffer = Encoding::ASCII->GetBytes( data );
   
   // Wait 10 seconds for a reply.
   int timeout = 10000;
   
   // Set options for transmission:
   // The data can go through 64 gateways or routers
   // before it is destroyed, and the data packet
   // cannot be fragmented.
   PingOptions ^ options = gcnew PingOptions( 64,true );
   PingReply ^ reply = pingSender->Send( address, timeout, buffer, options );
   if ( reply->Status == IPStatus::Success )
   {
      Console::WriteLine( "Address: {0}", reply->Address->ToString() );
      Console::WriteLine( "RoundTrip time: {0}", reply->RoundtripTime );
      Console::WriteLine( "Time to live: {0}", reply->Options->Ttl );
      Console::WriteLine( "Don't fragment: {0}", reply->Options->DontFragment );
      Console::WriteLine( "Buffer size: {0}", reply->Buffer->Length );
   }
   else
   {
      Console::WriteLine( reply->Status );
   }
}


//</snippet5>
//<snippet6>
void LocalPingTimeout()
{
   
   // Ping's the local machine.
   Ping ^ pingSender = gcnew Ping;
   IPAddress^ address = IPAddress::Loopback;
   
   // Create a buffer of 32 bytes of data to be transmitted.
   String^ data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
   array<Byte>^buffer = Encoding::ASCII->GetBytes( data );
   
   // Wait 10 seconds for a reply.
   int timeout = 10000;
   PingReply ^ reply = pingSender->Send( address, timeout, buffer);
   if ( reply->Status == IPStatus::Success )
   {
      Console::WriteLine( "Address: {0}", reply->Address->ToString() );
      Console::WriteLine( "RoundTrip time: {0}", reply->RoundtripTime );
      Console::WriteLine( "Time to live: {0}", reply->Options->Ttl );
      Console::WriteLine( "Don't fragment: {0}", reply->Options->DontFragment );
      Console::WriteLine( "Buffer size: {0}", reply->Buffer->Length );
   }
   else
   {
      Console::WriteLine( reply->Status );
   }
}


//</snippet6>
//<snippet7>
void AsyncComplexLocalPing()
{
   
   // Get an object that will block the main thread.
   AutoResetEvent^ waiter = gcnew AutoResetEvent( false );
   
   // Ping's the local machine.
   Ping ^ pingSender = gcnew Ping;
   
   // When the PingCompleted event is raised,
   // the PingCompletedCallback method is called.
   pingSender->PingCompleted += gcnew PingCompletedEventHandler( PingCompletedCallback );
   IPAddress^ address = IPAddress::Loopback;
   
   // Create a buffer of 32 bytes of data to be transmitted.
   String^ data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
   array<Byte>^buffer = Encoding::ASCII->GetBytes( data );
   
   // Wait 10 seconds for a reply.
   int timeout = 10000;
   
   // Set options for transmission:
   // The data can go through 64 gateways or routers
   // before it is destroyed, and the data packet
   // cannot be fragmented.
   PingOptions ^ options = gcnew PingOptions( 64,true );
   
   // Send the ping asynchronously.
   // Use the waiter as the user token.
   // When the callback completes, it can wake up this thread.
   pingSender->SendAsync( address, timeout, buffer, options, waiter );
   
   // Prevent this example application from ending.
   // A real application should do something useful
   // when possible.
   waiter->WaitOne();
   Console::WriteLine( "Ping example completed." );
}


//</snippet7>
//<snippet8>
void PingCompletedCallback( Object^ /*sender*/, PingCompletedEventArgs^ e )
{
   
   // If the operation was canceled, display a message to the user.
   if ( e->Cancelled )
   {
      Console::WriteLine( "Ping canceled." );
   }

   
   // If an error occurred, display the exception to the user.
   if ( e->Error != nullptr )
   {
      Console::WriteLine( "Ping failed:" );
      Console::WriteLine( e->Error->ToString() );
   }

   PingReply ^ reply = e->Reply;
   Console::WriteLine( reply->Status );
   
   // Let the main thread resume.
   (dynamic_cast<AutoResetEvent^>(e->UserState))->Set();
}

//</snippet8>
