      // sets the receive buffer size using the ReceiveBufferSize public property.
      tcpClient->ReceiveBufferSize = 1024;
      
      // gets the receive buffer size using the ReceiveBufferSize public property.
      if ( tcpClient->ReceiveBufferSize == 1024 )
            Console::WriteLine( "The receive buffer was successfully set to {0}", tcpClient->ReceiveBufferSize );

      