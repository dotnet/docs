        // Send operations will time-out if confirmation 
        // is not received within 1000 milliseconds.
        s.SetSocketOption (SocketOptionLevel.Socket, SocketOptionName.SendTimeout, 1000);

        // The socket will linger for 10 seconds after Socket.Close is called.
        LingerOption lingerOption = new LingerOption (true, 10);

        s.SetSocketOption (SocketOptionLevel.Socket, SocketOptionName.Linger, lingerOption);
