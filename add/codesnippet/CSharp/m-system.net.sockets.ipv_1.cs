        // Exercise the use of the IPv6MulticastOption.
        Console.WriteLine("Instantiate IPv6MulticastOption(IPAddress)");
    
        // Instantiate IPv6MulticastOption using one of the 
        // overloaded constructors.
        IPv6MulticastOption ipv6MulticastOption = new IPv6MulticastOption(m_GrpAddr);

        // Store the IPAdress multicast options.
        IPAddress group =  ipv6MulticastOption.Group;
        long interfaceIndex = ipv6MulticastOption.InterfaceIndex;

        // Display IPv6MulticastOption properties.
        Console.WriteLine("IPv6MulticastOption.Group: [" + group  + "]");
        Console.WriteLine("IPv6MulticastOption.InterfaceIndex: [" + interfaceIndex + "]");
