         'Creates an instance of the TcpListener class by providing a local endpoint.
         Dim ipAddress As IPAddress = Dns.Resolve(Dns.GetHostName()).AddressList(0)
         Dim ipLocalEndPoint As New IPEndPoint(ipAddress, 11000)
         
         Try
            Dim tcpListener As New TcpListener(ipLocalEndPoint)
         Catch e As Exception
            Console.WriteLine(e.ToString())
         End Try