    Public Sub NetworkToHostOrder_Long(networkByte As Long)
        Dim hostByte As Long
        ' Converts a long value from network byte order to host byte order.
        hostByte = IPAddress.NetworkToHostOrder(networkByte)
        Console.WriteLine("Network byte order to Host byte order of {0} is {1}", networkByte, hostByte)
    End Sub 'NetworkToHostOrder_Long