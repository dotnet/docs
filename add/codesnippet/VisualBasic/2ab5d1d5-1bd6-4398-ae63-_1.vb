            Dim udpClient As New UdpClient()
            ' Creates an IP address to use to join and drop the multicast group.
            Dim multicastIpAddress As IPAddress = IPAddress.Parse("239.255.255.255")
            
            Try
               ' The packet dies after 50 router hops.
               udpClient.JoinMulticastGroup(multicastIpAddress, 50)
            Catch e As Exception
               Console.WriteLine(e.ToString())
            End Try