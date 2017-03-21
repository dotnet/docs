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

