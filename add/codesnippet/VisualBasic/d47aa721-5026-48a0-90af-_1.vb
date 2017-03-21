        Console.WriteLine(("This application will timeout if Send does not return within " + Encoding.ASCII.GetString(s.GetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, 4))))
        ' blocks until send returns
        Dim i As Integer = s.Send(msg)

        ' blocks until read returns
        Dim bytes(1024) As Byte
        s.Receive(bytes)

        'Display to the screen
        Console.WriteLine(Encoding.ASCII.GetString(bytes))
        s.Shutdown(SocketShutdown.Both)

        Console.WriteLine(("If data remains to be sent, this application will stay open for " + CType(s.GetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Linger), LingerOption).LingerTime.ToString()))
        s.Close()
    End Sub 'SetSocketOptions