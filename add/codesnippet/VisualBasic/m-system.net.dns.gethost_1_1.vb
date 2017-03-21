    Public Sub DoGetHostEntry(hostName As [String])

        DIM host as IPHostEntry = Dns.GetHostEntry(hostname)

        Console.WriteLine("GetHostEntry(" + hostname + ") returns: ")

        Dim ip As IPAddress() = host.AddressList

        Dim index As Integer
        For index = 0 To ip.Length - 1
             Console.WriteLine(ip(index))
        Next index
    End Sub    