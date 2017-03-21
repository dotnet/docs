      // Obtain the IP address from the list of IP addresses associated with the server.
      System::Collections::IEnumerator^ myEnum = host->AddressList->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         IPAddress^ address = safe_cast<IPAddress^>(myEnum->Current);
         IPEndPoint^ endpoint = gcnew IPEndPoint( address,port );
         tempSocket = gcnew Socket( endpoint->AddressFamily,SocketType::Stream,ProtocolType::Tcp );
         tempSocket->Connect( endpoint );
         if ( tempSocket->Connected )
         {
            // Display the endpoint information.
            displayEndpointInfo( endpoint );

            // Serialize the endpoint to obtain a SocketAddress object.
            serializedSocketAddress = serializeEndpoint( endpoint );
            break;
         }
         else
                  continue;
      }