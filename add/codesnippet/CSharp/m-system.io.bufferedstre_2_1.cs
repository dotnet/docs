        // Create a NetworkStream that owns clientSocket and
        // then create a BufferedStream on top of the NetworkStream.
        // Both streams are disposed when execution exits the
        // using statement.
        using(Stream
            netStream = new NetworkStream(clientSocket, true),
            bufStream =
                  new BufferedStream(netStream, streamBufferSize))