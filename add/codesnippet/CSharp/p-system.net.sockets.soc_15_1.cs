        Socket s = new Socket (lep.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

        //Using the AddressFamily, SocketType, and ProtocolType properties.
        Console.WriteLine ("I just set the following properties of socket: " + "Address Family = " + s.AddressFamily.ToString () + "\nSocketType = " + s.SocketType.ToString () + "\nProtocolType = " + s.ProtocolType.ToString ());
