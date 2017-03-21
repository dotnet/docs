      // Server name must match the host name and the name on the host's certificate. 
      serverName = args[ 1 ];
      
      // Create a TCP/IP client socket.
      TcpClient^ client = gcnew TcpClient( serverName,80 );
      Console::WriteLine( L"Client connected." );
      
      // Create an SSL stream that will close the client's stream.
      SslStream^ sslStream = gcnew SslStream( 
          client->GetStream(),
          false,
          gcnew RemoteCertificateValidationCallback( ValidateServerCertificate ),
          gcnew LocalCertificateSelectionCallback( SelectLocalCertificate ) );
      