    Public Sub GetIpAddressList(hostString As [String])
        Try
            ' Get 'IPHostEntry' object which contains information like host name, IP addresses, aliases
	    ' for specified url
            Dim hostInfo As IPHostEntry = Dns.GetHostByName(hostString)
            Console.WriteLine(("Host name : " + hostInfo.HostName))
            Console.WriteLine("IP address List : ")
            Dim index As Integer
            For index = 0 To hostInfo.AddressList.Length - 1
                Console.WriteLine(hostInfo.AddressList(index))
            Next index
        Catch e As SocketException
            Console.WriteLine("SocketException caught!!!")
            Console.WriteLine(("Source : " + e.Source))
            Console.WriteLine(("Message : " + e.Message))
        Catch e As ArgumentNullException
            Console.WriteLine("ArgumentNullException caught!!!")
            Console.WriteLine(("Source : " + e.Source))
            Console.WriteLine(("Message : " + e.Message))
        Catch e As Exception
            Console.WriteLine("Exception caught!!!")
            Console.WriteLine(("Source : " + e.Source))
            Console.WriteLine(("Message : " + e.Message))
        End Try
    End Sub 'GetIpAddressList