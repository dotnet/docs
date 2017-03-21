            'Uses the IP address and port number to establish a socket connection.
            Dim udpClient As New UdpClient()
            Dim ipAddress As IPAddress = Dns.Resolve("www.contoso.com").AddressList(0)
            Try
               udpClient.Connect(ipAddress, 11003)
            Catch e As Exception
               Console.WriteLine(e.ToString())
            End Try