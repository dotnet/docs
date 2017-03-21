
    Public Sub PrintAddress(IpAddressString As [String])
        ' Creates an instance of the IPAddress' for the specified IP string in dotted-quad notation.
        Dim hostIPAddress As IPAddress = IPAddress.Parse(IpAddressString)
        Console.WriteLine(ControlChars.Cr + "The IP address '" + IpAddressString + "' is {0}", hostIPAddress.ToString())
    End Sub 'PrintAddressFamily
