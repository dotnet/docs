   // Asynchronous connect using host name (resolved by the 
   // BeginConnect call.)
   static void BeginConnect3( String^ host, int port )
   {
      Socket^ s = gcnew Socket( AddressFamily::InterNetwork,SocketType::Stream,ProtocolType::Tcp );
      allDone->Reset();
      Console::WriteLine( "Establishing Connection to {0}", host );
      s->BeginConnect( host, port, gcnew AsyncCallback( ConnectCallback1 ), s );
      
      // wait here until the connect finishes.  The callback 
      // sets allDone.
      allDone->WaitOne();
      Console::WriteLine( "Connection established" );
   }

