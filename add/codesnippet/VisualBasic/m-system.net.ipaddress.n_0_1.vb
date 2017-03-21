    Public Sub NetworkToHostOrder_Integer(networkByte As Integer)
        Dim hostByte As Integer
        ' Converts an integer value from network byte order to host byte order.
        hostByte = IPAddress.NetworkToHostOrder(networkByte)
        Console.WriteLine("Network byte order to Host byte order of {0} is {1}", networkByte, hostByte)
    End Sub 'NetworkToHostOrder_Integer