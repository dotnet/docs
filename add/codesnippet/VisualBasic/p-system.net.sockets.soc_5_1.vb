        Dim s As New Socket(lep.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp)

        'Using the AddressFamily, SocketType, and ProtocolType properties.
        Console.WriteLine(("I just set the following properties of socket: " + "Address Family = " + s.AddressFamily.ToString() + ControlChars.Cr + "SocketType = " + s.SocketType.ToString() + ControlChars.Cr + "ProtocolType = " + s.ProtocolType.ToString()))
