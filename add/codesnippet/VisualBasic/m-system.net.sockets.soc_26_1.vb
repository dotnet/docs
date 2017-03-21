    Public Shared Sub SendTo1() 
        Dim hostEntry As IPHostEntry = Dns.GetHostEntry(Dns.GetHostName())
        Dim endPoint As New IPEndPoint(hostEntry.AddressList(0), 11000)
        
        Dim s As New Socket(endPoint.Address.AddressFamily, SocketType.Dgram, ProtocolType.Udp)
        
        Dim msg As Byte() = Encoding.ASCII.GetBytes("This is a test")
        Console.WriteLine("Sending data.")
        ' This call blocks. 
        s.SendTo(msg, endPoint)
        s.Close()
    
    End Sub 'SendTo1
    