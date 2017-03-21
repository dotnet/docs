         'Creates an instance of the UdpClient class to listen on 
         'the default interface using a particular port.
         Try
            Dim udpClient As New UdpClient(11000)
         Catch e As Exception
            Console.WriteLine(e.ToString())
         End Try