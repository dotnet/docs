        // Sends data immediately upon calling NetworkStream.Write.
        tcpClient.NoDelay = true;

        // Determines if the delay is enabled by using the NoDelay property.
        if (tcpClient.NoDelay == true)
            Console.WriteLine ("The delay was set successfully to " + tcpClient.NoDelay.ToString ());
