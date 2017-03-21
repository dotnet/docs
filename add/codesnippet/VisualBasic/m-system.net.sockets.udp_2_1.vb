               Dim udpClient As New UdpClient("www.contoso.com", 11000)
               Dim sendBytes As [Byte]() = Encoding.ASCII.GetBytes("Is anybody there")
               Try
                  udpClient.Send(sendBytes, sendBytes.Length)
               Catch e As Exception
                  Console.WriteLine(e.ToString())
               End Try