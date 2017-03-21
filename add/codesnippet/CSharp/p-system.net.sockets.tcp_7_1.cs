        // Sets the receive buffer size using the ReceiveBufferSize public property.
        tcpClient.ReceiveBufferSize = 1024;

        // Gets the receive buffer size using the ReceiveBufferSize public property.
        if (tcpClient.ReceiveBufferSize == 1024)
            Console.WriteLine ("The receive buffer was successfully set to " + tcpClient.ReceiveBufferSize.ToString ());
