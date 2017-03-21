        // Sets the send buffer size using the SendBufferSize public property.
        tcpClient.SendBufferSize = 1024;

        // Gets the send buffer size using the SendBufferSize public property.
        if (tcpClient.SendBufferSize == 1024)
            Console.WriteLine ("The send buffer was successfully set to " + tcpClient.SendBufferSize.ToString ());
