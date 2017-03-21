        // Obtain the IP address from the list of IP addresses associated with the server.
        foreach(IPAddress address in host.AddressList)
        {
          IPEndPoint endpoint = new IPEndPoint(address, port);

            
          tempSocket = 
            new Socket(endpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

          tempSocket.Connect(endpoint);

          if(tempSocket.Connected)
          {
            // Display the endpoint information.
            displayEndpointInfo(endpoint);
            // Serialize the endpoint to obtain a SocketAddress object.
            serializedSocketAddress = serializeEndpoint(endpoint);
            break;
          }
          else
            continue;
        }