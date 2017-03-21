    Public Shared Sub ReceiveFrom2() 
        Dim hostEntry As IPHostEntry = Dns.GetHostEntry(Dns.GetHostName())
        Dim endPoint As New IPEndPoint(hostEntry.AddressList(0), 11000)
        
        Dim s As New Socket(endPoint.Address.AddressFamily, SocketType.Dgram, ProtocolType.Udp)
        
        ' Creates an IpEndPoint to capture the identity of the sending host.
        Dim sender As New IPEndPoint(IPAddress.Any, 0)
        Dim senderRemote As EndPoint = CType(sender, EndPoint)
        
        ' Binding is required with ReceiveFrom calls.
        s.Bind(endPoint)
        
        Dim msg() As Byte = New [Byte](255) {}
        Console.WriteLine("Waiting to receive datagrams from client...")
        ' This call blocks. 
        s.ReceiveFrom(msg, SocketFlags.None, senderRemote)
        s.Close()
    
    End Sub 'ReceiveFrom2
    