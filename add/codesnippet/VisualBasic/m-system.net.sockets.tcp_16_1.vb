                'Uses the IP address and port number to establish a socket connection.
                Dim tcpClient As New TcpClient
                Dim ipAddress As IPAddress = Dns.GetHostEntry("www.contoso.com").AddressList(0)
                tcpClient.Connect(ipAddress, 11003)