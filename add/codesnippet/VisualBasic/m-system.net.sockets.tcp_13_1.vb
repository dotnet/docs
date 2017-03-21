                    'Uses a remote endpoint to establish a socket connection.
                    Dim tcpClient As New TcpClient
                    Dim ipAddress As IPAddress = Dns.GetHostEntry("www.contoso.com").AddressList(0)
                    Dim ipEndPoint As New IPEndPoint(ipAddress, 11004)

                    tcpClient.Connect(ipEndPoint)
                    