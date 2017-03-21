    Public Sub DisplayLocalHostName()
        Try
            ' Get the local computer host name.
            Dim hostName As [String] = Dns.GetHostName()
            Console.WriteLine(("Computer name :" + hostName))
        Catch e As SocketException
            Console.WriteLine("SocketException caught!!!")
            Console.WriteLine(("Source : " + e.Source))
            Console.WriteLine(("Message : " + e.Message))
        Catch e As Exception
            Console.WriteLine("Exception caught!!!")
            Console.WriteLine(("Source : " + e.Source))
            Console.WriteLine(("Message : " + e.Message))
        End Try