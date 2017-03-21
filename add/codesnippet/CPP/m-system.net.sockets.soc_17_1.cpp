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

