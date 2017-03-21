            'Creates an instance of the TcpListener class by providing a local IP address and port number.
            Dim ipAddress As IPAddress = Dns.Resolve("localhost").AddressList(0)
            
            Try
               Dim tcpListener As New TcpListener(ipAddress, 13)
            Catch e As Exception
               Console.WriteLine(e.ToString())
            End Try
         