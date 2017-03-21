    Public Sub PrintBroadcastAddress()
        ' gets the IP Broadcast address and convert it to string.
        Dim IpAddressString As [String] = IPAddress.Broadcast.ToString()
        Console.WriteLine((ControlChars.Cr + "Broadcast IP address : " + IpAddressString))
    End Sub 'PrintBroadcastAddress