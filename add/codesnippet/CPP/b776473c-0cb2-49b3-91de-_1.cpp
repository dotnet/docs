      // Specifies that send operations will time-out 
      // if confirmation is not received within 1000 milliseconds.
      s->SetSocketOption( SocketOptionLevel::Socket, SocketOptionName::SendTimeout, 1000 );
      
      // Specifies that the Socket will linger for 10 seconds after Close is called.
      LingerOption^ lingerOption = gcnew LingerOption( true,10 );

      s->SetSocketOption( SocketOptionLevel::Socket, SocketOptionName::Linger, lingerOption );