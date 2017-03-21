         'Creates a TCPClient using a local endpoint.
         Dim ipAddress As IPAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList(0)
            Dim ipLocalEndPoint As New IPEndPoint(ipAddress, 0)

            Dim tcpClientA As New TcpClient(ipLocalEndPoint)
         