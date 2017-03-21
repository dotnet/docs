      // Establish the local endpoint for the socket.
      IPHostEntry^ ipHost = Dns::GetHostEntry( Dns::GetHostName() );
      IPAddress^ ipAddr = ipHost->AddressList[ 0 ];
      IPEndPoint^ ipEndPoint = gcnew IPEndPoint( ipAddr,11000 );

      // Create a TCP socket.
      Socket^ client = gcnew Socket( AddressFamily::InterNetwork,SocketType::Stream,ProtocolType::Tcp );

      // Connect the socket to the remote endpoint.
      client->Connect( ipEndPoint );

      // Set option that allows socket to close gracefully without lingering.
      client->SetSocketOption( SocketOptionLevel::Socket, SocketOptionName::DontLinger, true );

      // Set option that allows socket to receive out-of-band information in the data stream.
      client->SetSocketOption( SocketOptionLevel::Socket, SocketOptionName::OutOfBandInline, true );
