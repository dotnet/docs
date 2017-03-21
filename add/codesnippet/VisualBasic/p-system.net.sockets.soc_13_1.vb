        s.Connect(lep)

        ' Using the RemoteEndPoint property.
        Console.WriteLine("I am connected to ")
        Console.WriteLine(IPAddress.Parse(CType(s.RemoteEndPoint, IPEndPoint).Address.ToString()))
        Console.WriteLine("on port number ")
        Console.WriteLine(CType(s.RemoteEndPoint, IPEndPoint).Port.ToString())

        ' Using the LocalEndPoint property.
        Console.WriteLine("My local IpAddress is :")
        Console.WriteLine(IPAddress.Parse(CType(s.LocalEndPoint, IPEndPoint).Address.ToString()))
        Console.WriteLine("I am connected on port number ")
        Console.WriteLine(CType(s.LocalEndPoint, IPEndPoint).Port.ToString())
