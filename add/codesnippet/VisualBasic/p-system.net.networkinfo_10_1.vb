    Public Shared Sub DisplayMulticastAddresses() 
        Dim count as Integer = 0
        
        Console.WriteLine("Multicast Addresses")
        Dim adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
        Dim adapter As NetworkInterface
        For Each adapter In  adapters
            Dim adapterProperties As IPInterfaceProperties = adapter.GetIPProperties()
            Dim multiCast As MulticastIPAddressInformationCollection = adapterProperties.MulticastAddresses
            If multiCast.Count > 0 Then
                Console.WriteLine(adapter.Description)
                Dim multi As IPAddressInformation
                For Each multi In  multiCast
                    Console.WriteLine("  Multicast Address ....................... : {0} {1} {2}", multi.Address, IIf(multi.IsTransient, "Transient", ""), IIf(multi.IsDnsEligible, "DNS Eligible", ""))
                'TODO: For performance reasons this should be changed to nested IF statements
                'TODO: For performance reasons this should be changed to nested IF statements
                    count += 1
                Next multi
                Console.WriteLine()
            End If
        Next adapter
    
        if count = 0 then
            Console.WriteLine("  No multicast addresses were found.")
            Console.WriteLine()
        End if
    
    End Sub 'DisplayMulticastAddresses
    