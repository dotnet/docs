

//NCLPingAsync
//<snippet1>
#using <System.dll>

using namespace System;
using namespace System::Text;
using namespace System::Net;
using namespace System::Net::NetworkInformation;
using namespace System::ComponentModel;
using namespace System::Threading;
void PingCompletedCallback( Object^ sender, PingCompletedEventArgs^ e );
void DisplayReply( PingReply^ reply );
int main()
{
   array<String^>^args = Environment::GetCommandLineArgs();
   if ( args->Length == 1 )
      throw gcnew ArgumentException( "Ping needs a host or IP Address." );

   String^ who = args[ 1 ];
   AutoResetEvent^ waiter = gcnew AutoResetEvent( false );
   
   //<snippet2>
   Ping ^ pingSender = gcnew Ping;
   
   // When the PingCompleted event is raised,
   // the PingCompletedCallback method is called.
   pingSender->PingCompleted += gcnew PingCompletedEventHandler( PingCompletedCallback );
   
   //</snippet2>
   // Create a buffer of 32 bytes of data to be transmitted.
   String^ data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
   array<Byte>^buffer = Encoding::ASCII->GetBytes( data );
   
   // Wait 12 seconds for a reply.
   int timeout = 12000;
   
   //<snippet3>
   // Set options for transmission:
   // The data can go through 64 gateways or routers
   // before it is destroyed, and the data packet
   // cannot be fragmented.
   PingOptions ^ options = gcnew PingOptions( 64,true );
   Console::WriteLine( "Time to live: {0}", options->Ttl );
   Console::WriteLine( "Don't fragment: {0}", options->DontFragment );
   
   //</snippet3>
   // Send the ping asynchronously.
   // Use the waiter as the user token.
   // When the callback completes, it can wake up this thread.
   pingSender->SendAsync( who, timeout, buffer, options, waiter );
   
   // Prevent this example application from ending.
   // A real application should do something useful
   // when possible.
   waiter->WaitOne();
   Console::WriteLine( "Ping example completed." );
}


//<snippet4>
void PingCompletedCallback( Object^ /*sender*/, PingCompletedEventArgs^ e )
{
   
   // If the operation was canceled, display a message to the user.
   if ( e->Cancelled )
   {
      Console::WriteLine( "Ping canceled." );
      
      // Let the main thread resume. 
      // UserToken is the AutoResetEvent object that the main thread 
      // is waiting for.
      (dynamic_cast<AutoResetEvent^>(e->UserState))->Set();
   }

   
   // If an error occurred, display the exception to the user.
   if ( e->Error != nullptr )
   {
      Console::WriteLine( "Ping failed:" );
      Console::WriteLine( e->Error->ToString() );
      
      // Let the main thread resume. 
      (dynamic_cast<AutoResetEvent^>(e->UserState))->Set();
   }

   PingReply ^ reply = e->Reply;
   DisplayReply( reply );
   
   // Let the main thread resume.
   (dynamic_cast<AutoResetEvent^>(e->UserState))->Set();
}


//</snippet4>
//<snippet5>
void DisplayReply( PingReply ^ reply )
{
   if ( reply == nullptr )
      return;

   Console::WriteLine( "ping status: {0}", reply->Status );
   if ( reply->Status == IPStatus::Success )
   {
      Console::WriteLine( "Address: {0}", reply->Address->ToString() );
      Console::WriteLine( "RoundTrip time: {0}", reply->RoundtripTime );
      Console::WriteLine( "Time to live: {0}", reply->Options->Ttl );
      Console::WriteLine( "Don't fragment: {0}", reply->Options->DontFragment );
      Console::WriteLine( "Buffer size: {0}", reply->Buffer->Length );
   }
}

//</snippet5>
// </snippet1>
