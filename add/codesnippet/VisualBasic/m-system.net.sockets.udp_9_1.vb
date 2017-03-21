            'Creates an instance of the UdpClient class using a local endpoint.
            Dim ipAddress As IPAddress = Dns.Resolve(Dns.GetHostName()).AddressList(0)
            Dim ipLocalEndPoint As New IPEndPoint(ipAddress, 11000)
            
            Try
               Dim udpClient As New UdpClient(ipLocalEndPoint)
            Catch e As Exception
               Console.WriteLine(e.ToString())
            End Try