         // Instantiate IPv6MulticastOption using another
         // overloaded constructor.
         IPv6MulticastOption^ ipv6MulticastOption2 = gcnew IPv6MulticastOption( group,interfaceIndex );
         
         // Store the IPAdress multicast options.
         group = ipv6MulticastOption2->Group;
         interfaceIndex = ipv6MulticastOption2->InterfaceIndex;
         
         // Display the IPv6MulticastOption2 properties.
         Console::WriteLine( "IPv6MulticastOption::Group: [ {0} ]", group );
         Console::WriteLine( "IPv6MulticastOption::InterfaceIndex: [ {0} ]", interfaceIndex );
         
         // Join the specified multicast group using one of the
         // JoinMulticastGroup overloaded methods.
         clientOriginator->JoinMulticastGroup( (int)interfaceIndex, group );
         