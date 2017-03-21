   // create the socket
   Socket^ listenSocket = gcnew Socket( AddressFamily::InterNetwork,
      SocketType::Stream,
      ProtocolType::Tcp );
   
   // bind the listening socket to the port
   IPAddress^ hostIP = ( Dns::Resolve( IPAddress::Any->ToString() ) )->AddressList[ 0 ];
   IPEndPoint^ ep = gcnew IPEndPoint( hostIP,port );
   listenSocket->Bind( ep );
   
   // start listening
   listenSocket->Listen( backlog );