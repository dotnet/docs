    Public Sub PrintLoopbackAddress()
        ' Gets the IP loopback address and converts it to a string.
        Dim IpAddressString As [String] = IPAddress.Loopback.ToString()
        Console.WriteLine(("Loopback IP address : " + IpAddressString))
    End Sub 'PrintLoopbackAddress