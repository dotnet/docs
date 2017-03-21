               'Uses a remote endpoint to establish a socket connection.
               Dim udpClient As New UdpClient()
               Dim ipAddress As IPAddress = Dns.Resolve("www.contoso.com").AddressList(0)
               Dim ipEndPoint As New IPEndPoint(ipAddress, 11004)
               Try
                  udpClient.Connect(ipEndPoint)
               Catch e As Exception
                  Console.WriteLine(e.ToString())
               End Try