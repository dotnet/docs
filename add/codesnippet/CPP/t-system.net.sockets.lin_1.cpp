      LingerOption^ myOpts = gcnew LingerOption( true,1 );
      mySocket->SetSocketOption( SocketOptionLevel::Socket, SocketOptionName::Linger, myOpts );