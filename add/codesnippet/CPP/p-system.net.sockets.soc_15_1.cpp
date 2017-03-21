      Socket^ s = gcnew Socket( lep->Address->AddressFamily,SocketType::Stream,ProtocolType::Tcp );
      
      //Uses the AddressFamily, SocketType, and ProtocolType properties.
      Console::Write(  "I just set the following properties of socket: \n" );
      Console::Write(  "Address Family = {0}", s->AddressFamily.ToString() );
      Console::Write(  "\nSocketType = {0}", s->SocketType.ToString() );
      Console::WriteLine(  "\nProtocolType = {0}", s->ProtocolType.ToString() );