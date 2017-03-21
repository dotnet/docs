    Public Sub DoGetHostAddresses(hostName As [String])

        Dim ips As IPAddress()
 
        ips = Dns.GetHostAddresses(hostname)

        Console.WriteLine("GetHostAddresses(" + hostname + ") returns: ")

        Dim index As Integer
        For index = 0 To ips.Length - 1
             Console.WriteLine(ips(index))
        Next index
    End Sub    