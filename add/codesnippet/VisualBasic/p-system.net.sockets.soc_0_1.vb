        ' .Connect throws an exception if unsuccessful
        client.Connect(anEndPoint)
        
        ' This is how you can determine whether a socket is still connected.
        Dim blockingState As Boolean = client.Blocking
        Try
            Dim tmp(0) As Byte
            
            client.Blocking = False
            client.Send(tmp, 0, 0)
            Console.WriteLine("Connected!")
        Catch e As SocketException
            ' 10035 == WSAEWOULDBLOCK
            If e.NativeErrorCode.Equals(10035) Then
                Console.WriteLine("Still Connected, but the Send would block")
            Else
                Console.WriteLine("Disconnected: error code {0}!", e.NativeErrorCode)
            End If
        Finally
            client.Blocking = blockingState
        End Try
        
        Console.WriteLine("Connected: {0}", client.Connected)
    
    End Sub 'ConnectAndCheck