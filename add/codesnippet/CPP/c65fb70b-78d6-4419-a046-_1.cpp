   // Connect asynchronously to the specifed host.
   static void DoBeginConnect2( String^ host, int port )
   {
      TcpClient^ t = gcnew TcpClient( AddressFamily::InterNetwork );
      array<IPAddress^>^remoteHost = Dns::GetHostAddresses( host );
      connectDone->Reset();
      Console::WriteLine( "Establishing Connection to {0}", host );
      t->BeginConnect( remoteHost, port, gcnew AsyncCallback(  &ConnectCallback ), t );

      // Wait here until the callback processes the connection.
      connectDone->WaitOne();
      Console::WriteLine( "Connection established" );
   }