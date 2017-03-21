      ' The serializeEndpoint method serializes the endpoint and returns the 
      ' SocketAddress containing the serialized endpoint data.
      Private Shared Function serializeEndpoint(ByVal endpoint As IPEndPoint) As SocketAddress

        ' Serialize IPEndPoint details to a SocketAddress instance.
        Dim socketAddress As SocketAddress = endpoint.Serialize()

        ' Display the serialized endpoint information.
        Console.WriteLine("Endpoint Serialize() : " + socketAddress.ToString())

        Console.WriteLine("Socket Family : " + socketAddress.Family.ToString())
        Console.WriteLine("Socket Size : " + socketAddress.ToString())

        Console.WriteLine("Press any key to continue.")
        Console.ReadLine()

        Return socketAddress
      End Function 'serializeEndpoint
