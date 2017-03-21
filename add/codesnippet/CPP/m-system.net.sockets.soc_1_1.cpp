   //Creates the Socket for sending data over TCP.
   Socket^ s = gcnew Socket( AddressFamily::InterNetwork, SocketType::Stream,
      ProtocolType::Tcp );
   
   // Connects to host using IPEndPoint.
   s->Connect( EPhost );
   if ( !s->Connected )
   {
      strRetPage = "Unable to connect to host";
   }
   // Use the SelectWrite enumeration to obtain Socket status.
   if ( s->Poll( -1, SelectMode::SelectWrite ) )
   {
      Console::WriteLine( "This Socket is writable." );
   }
   else if ( s->Poll(  -1, SelectMode::SelectRead ) )
   {
      Console::WriteLine( "This Socket is readable." );
   }
   else if ( s->Poll(  -1, SelectMode::SelectError ) )
   {
      Console::WriteLine( "This Socket has an error." );
   }