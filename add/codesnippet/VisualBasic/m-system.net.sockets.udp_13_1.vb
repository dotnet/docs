         'Uses a host name and port number to establish a socket connection.
         Dim udpClient As New UdpClient()
         Try
            udpClient.Connect("www.contoso.com", 11002)
         Catch e As Exception
            Console.WriteLine(e.ToString())
         End Try