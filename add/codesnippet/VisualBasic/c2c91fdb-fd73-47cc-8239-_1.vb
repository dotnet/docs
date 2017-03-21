         ' Bind and listen on port 2000. This constructor creates a socket 
         ' and binds it to the port on which to receive data. The family 
         ' parameter specifies that this connection uses an IPv6 address.
         clientOriginator = New UdpClient(2000, AddressFamily.InterNetworkV6)
         
         ' Join or create a multicast group. The multicast address ranges 
         ' to use are specified in RFC#2375. You are free to use 
         ' different addresses.
         ' Transform the string address into the internal format.
         m_GrpAddr = IPAddress.Parse("FF01::1")
         
         ' Display the multicast address used.
         Console.WriteLine(("Multicast Address: [" + m_GrpAddr.ToString() + "]"))
         
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
         
         ' Instantiate IPv6MulticastOption using another 
         ' overloaded constructor.
         Dim ipv6MulticastOption2 As New IPv6MulticastOption(group, interfaceIndex)
         
         ' Store the IPAdress multicast options.
         group = ipv6MulticastOption2.Group
         interfaceIndex = ipv6MulticastOption2.InterfaceIndex
         
         ' Display the IPv6MulticastOption2 properties.
         Console.WriteLine(("IPv6MulticastOption.Group: [" + group.ToString() + "]"))
         Console.WriteLine(("IPv6MulticastOption.InterfaceIndex: [" + interfaceIndex.ToString() + "]"))
         
         ' Join the specified multicast group using one of the 
         ' JoinMulticastGroup overloaded methods.
         clientOriginator.JoinMulticastGroup(Fix(interfaceIndex), group)
         
         ' Define the endpoint data port. Note that this port number
         ' must match the ClientTarget UDP port number which is the
         ' port on which the ClientTarget is receiving data.
         m_ClientTargetdest = New IPEndPoint(m_GrpAddr, 1000)
         