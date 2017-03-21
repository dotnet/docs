        s.Connect (lep);

        // Using the RemoteEndPoint property.
        Console.WriteLine ("I am connected to " + IPAddress.Parse (((IPEndPoint)s.RemoteEndPoint).Address.ToString ()) + "on port number " + ((IPEndPoint)s.RemoteEndPoint).Port.ToString ());

        // Using the LocalEndPoint property.
        Console.WriteLine ("My local IpAddress is :" + IPAddress.Parse (((IPEndPoint)s.LocalEndPoint).Address.ToString ()) + "I am connected on port number " + ((IPEndPoint)s.LocalEndPoint).Port.ToString ());
