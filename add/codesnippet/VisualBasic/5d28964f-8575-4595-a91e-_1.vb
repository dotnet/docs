            Dim udpClient As New UdpClient()
            
            Dim sendBytes As [Byte]() = Encoding.ASCII.GetBytes("Is anybody there")
            Try
               udpClient.Send(sendBytes, sendBytes.Length, "www.contoso.com", 11000)
            Catch e As Exception
               Console.WriteLine(e.ToString())
            End Try