   // Synchronous connect using host name (resolved by the 
   // Connect call.)
   static void Connect3( String^ host, int port )
   {
      Socket^ s = gcnew Socket( AddressFamily::InterNetwork,SocketType::Stream,ProtocolType::Tcp );
      Console::WriteLine( "Establishing Connection to {0}", host );
      s->Connect( host, port );
      Console::WriteLine( "Connection established" );
   }
