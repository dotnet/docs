               'Creates an instance of the UdpClient class with a remote host name and a port number.
               Try
                  Dim udpClient As New UdpClient("www.contoso.com", 11000)
               Catch e As Exception
                  Console.WriteLine(e.ToString())
               End Try