         Dim udpClient As New UdpClient()
         Dim ipAddress As IPAddress = Dns.Resolve("www.contoso.com").AddressList(0)
         Dim ipEndPoint As New IPEndPoint(ipAddress, 11004)
         
         Dim sendBytes As [Byte]() = Encoding.ASCII.GetBytes("Is anybody there?")
         Try
            udpClient.Send(sendBytes, sendBytes.Length, ipEndPoint)
         Catch e As Exception
            Console.WriteLine(e.ToString())
         End Try