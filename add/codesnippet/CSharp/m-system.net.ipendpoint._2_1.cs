    // The serializeEndpoint method serializes the endpoint and returns the 
    // SocketAddress containing the serialized endpoint data.
    private static SocketAddress serializeEndpoint(IPEndPoint endpoint)
    {
 
      // Serialize IPEndPoint details to a SocketAddress instance.
      SocketAddress socketAddress = endpoint.Serialize();
  
      // Display the serialized endpoint information.
      Console.WriteLine("Endpoint.Serialize() : " + socketAddress.ToString());
 
      Console.WriteLine("Socket.Family : " + socketAddress.Family);
      Console.WriteLine("Socket.Size : " + socketAddress.Size);

      Console.WriteLine("Press any key to continue.");
      Console.ReadLine();

      return socketAddress;
    }