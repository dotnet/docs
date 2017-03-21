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

