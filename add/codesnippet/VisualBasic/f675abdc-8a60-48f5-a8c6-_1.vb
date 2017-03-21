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
         