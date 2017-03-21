      // Sets the receive time out using the ReceiveTimeout public property.
      tcpClient->ReceiveTimeout = 5;
      
      // Gets the receive time out using the ReceiveTimeout public property.
      if ( tcpClient->ReceiveTimeout == 5 )
            Console::WriteLine( "The receive time out limit was successfully set {0}", tcpClient->ReceiveTimeout );

      