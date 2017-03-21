 Dim myOpts As New LingerOption(True, 1)
        
 mySocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Linger, _
    myOpts)
