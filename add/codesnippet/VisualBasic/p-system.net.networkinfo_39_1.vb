    Public Shared Sub DisplayAnycastAddresses() 
        Dim count as Integer = 0
        
        Console.WriteLine("Anycast Addresses")
        Dim adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
        Dim adapter As NetworkInterface
        For Each adapter In  adapters
            Dim adapterProperties As IPInterfaceProperties = adapter.GetIPProperties()
            Dim anyCast As IPAddressInformationCollection = adapterProperties.AnycastAddresses
            If anyCast.Count > 0 Then
                Console.WriteLine(adapter.Description)
                Dim any As IPAddressInformation
                For Each any In  anyCast
                    Console.WriteLine("  Anycast Address .......................... : {0} {1} {2}", any.Address, IIf(any.IsTransient, "Transient", ""), IIf(any.IsDnsEligible, "DNS Eligible", ""))
                'TODO: For performance reasons this should be changed to nested IF statements
                'TODO: For performance reasons this should be changed to nested IF statements
                    count += 1
                Next any
                Console.WriteLine()
            End If
        Next adapter
    
        if count = 0 then
            Console.WriteLine("  No anycast addresses were found.")
            Console.WriteLine()
        End if
    End Sub 'DisplayAnycastAddresses
    