   static void GetConnected( TcpClient^ t )
   {
      // Find out whether the socket is connected to the remote 
      // host.
      Console::WriteLine( "Connected value is {0}", t->Connected.ToString() );
      ;
   }