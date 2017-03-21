   static void DoConnect( String^ host, int port )
   {
      // Connect to the specified host.
      TcpClient^ t = gcnew TcpClient( AddressFamily::InterNetwork );
      array<IPAddress^>^IPAddresses = Dns::GetHostAddresses( host );
      Console::WriteLine( "Establishing Connection to {0}", host );
      t->Connect( IPAddresses, port );
      Console::WriteLine( "Connection established" );
   }