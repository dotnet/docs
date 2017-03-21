   // Set options for transmission:
   // The data can go through 64 gateways or routers
   // before it is destroyed, and the data packet
   // cannot be fragmented.
   PingOptions ^ options = gcnew PingOptions( 64,true );
   Console::WriteLine( "Time to live: {0}", options->Ttl );
   Console::WriteLine( "Don't fragment: {0}", options->DontFragment );
   