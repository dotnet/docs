    Public Shared Sub DisplayDhcpServerAddresses() 
        Console.WriteLine("DHCP Servers")
        Dim adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
        Dim adapter As NetworkInterface
        For Each adapter In  adapters
            
            Dim adapterProperties As IPInterfaceProperties = adapter.GetIPProperties()
            Dim addresses As IPAddressCollection = adapterProperties.DhcpServerAddresses
            If addresses.Count > 0 Then
                Console.WriteLine(adapter.Description)
                Dim address As IPAddress
                For Each address In  addresses
                    Console.WriteLine("  Dhcp Address ............................ : {0}", address.ToString())
                Next address
                Console.WriteLine()
            End If
        Next adapter
    
    End Sub 'DisplayDhcpServerAddresses
    