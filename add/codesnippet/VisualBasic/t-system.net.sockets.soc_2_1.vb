        'Send operations will time-out if confirmation is 
        ' not received within 1000 milliseconds.
        s.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, 1000)

        ' The socket will linger for 10 seconds after Socket.Close is called.
        Dim lingerOption As New LingerOption(True, 10)
        s.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Linger, lingerOption)
