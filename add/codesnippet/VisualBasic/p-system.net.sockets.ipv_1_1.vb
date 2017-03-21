         ' Exercise the use of the IPv6MulticastOption.
         Console.WriteLine("Instantiate IPv6MulticastOption(IPAddress)")
         
         ' Instantiate IPv6MulticastOption using one of the 
         ' overloaded constructors.
         Dim ipv6MulticastOption As New IPv6MulticastOption(m_GrpAddr)
         
         ' Store the IPAdress multicast options.
         Dim group As IPAddress = ipv6MulticastOption.Group
         Dim interfaceIndex As Long = ipv6MulticastOption.InterfaceIndex
         
         ' Display IPv6MulticastOption properties.
         Console.WriteLine(("IPv6MulticastOption.Group: [" + group.ToString() + "]"))
         Console.WriteLine(("IPv6MulticastOption.InterfaceIndex: [" + interfaceIndex.ToString() + "]"))
         