   static void DoBeginConnect1( String^ host, int port )
   {
      // Connect asynchronously to the specifed host.
      TcpClient^ t = gcnew TcpClient( AddressFamily::InterNetwork );
//      IPAddress^ remoteHost = gcnew IPAddress( host );
      array<IPAddress^>^ remoteHost = Dns::GetHostAddresses( host );
      connectDone->Reset();
      Console::WriteLine( "Establishing Connection to {0}", host );
      t->BeginConnect( remoteHost, port, gcnew AsyncCallback( &ConnectCallback ), t );

      // Wait here until the callback processes the connection.
      connectDone->WaitOne();
      Console::WriteLine( "Connection established" );
   }