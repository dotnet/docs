   // Connect asynchronously to the specifed host.
   static void DoBeginConnect3( String^ host, int port )
   {
      TcpClient^ t = gcnew TcpClient( AddressFamily::InterNetwork );
      connectDone->Reset();
      Console::WriteLine( "Establishing Connection to {0}", host );
      t->BeginConnect( host, port, gcnew AsyncCallback(  &ConnectCallback ), t );
      
      // Wait here until the callback processes the connection.
      connectDone->WaitOne();
      Console::WriteLine( "Connection established" );
   }