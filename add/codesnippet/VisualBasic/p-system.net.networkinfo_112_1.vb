    Public Shared Sub DisplayGatewayAddresses() 
        Console.WriteLine("Gateways")
        Dim adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
        Dim adapter As NetworkInterface
        For Each adapter In  adapters
            Dim adapterProperties As IPInterfaceProperties = adapter.GetIPProperties()
            Dim addresses As GatewayIPAddressInformationCollection = adapterProperties.GatewayAddresses
            If addresses.Count > 0 Then
                Console.WriteLine(adapter.Description)
                Dim address As GatewayIPAddressInformation
                For Each address In  addresses
                    Console.WriteLine("  Gateway Address ......................... : {0}", address.ToString())
                Next address
                Console.WriteLine()
            End If
        Next adapter
    
    End Sub 'DisplayGatewayAddresses
    