      // Recreate the connection endpoint from the serialized information.
      IPEndPoint endpoint = new IPEndPoint(0,0);
      IPEndPoint clonedIPEndPoint = (IPEndPoint) endpoint.Create(socketAddress);
      Console.WriteLine("clonedIPEndPoint: " + clonedIPEndPoint.ToString());