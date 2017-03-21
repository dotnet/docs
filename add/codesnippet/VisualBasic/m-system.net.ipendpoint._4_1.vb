          ' Obtain the IP address from the list of IP addresses associated with the server.
          Dim address As IPAddress
          For Each address In host.AddressList
            Dim endpoint As New IPEndPoint(address, port)


            tempSocket = New Socket(endpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp)

            tempSocket.Connect(endpoint)

            If tempSocket.Connected Then
              ' Display the endpoint information.
              displayEndpointInfo(endpoint)
              ' Serialize the endpoint to obtain a SocketAddress object.
              serializedSocketAddress = serializeEndpoint(endpoint)
              Exit For

            End If

          Next address
