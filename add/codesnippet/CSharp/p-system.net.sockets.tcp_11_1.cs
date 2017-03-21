        // Sets the receive time out using the ReceiveTimeout public property.
        tcpClient.ReceiveTimeout = 5000;

        // Gets the receive time out using the ReceiveTimeout public property.
        if (tcpClient.ReceiveTimeout == 5000)
            Console.WriteLine ("The receive time out limit was successfully set " + tcpClient.ReceiveTimeout.ToString ());
