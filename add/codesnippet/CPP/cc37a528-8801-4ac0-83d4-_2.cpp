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

