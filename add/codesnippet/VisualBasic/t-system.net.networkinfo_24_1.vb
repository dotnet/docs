    Public Shared Sub DisplayDnsAddresses() 
        Dim adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
        Dim adapter As NetworkInterface
        For Each adapter In  adapters
            
            Dim adapterProperties As IPInterfaceProperties = adapter.GetIPProperties()
            Dim dnsServers As IPAddressCollection = adapterProperties.DnsAddresses
            If dnsServers.Count > 0 Then
                Console.WriteLine(adapter.Description)
                Dim dns As IPAddress
                For Each dns In  dnsServers
                    Console.WriteLine("  DNS Servers ............................. : {0}",dns.ToString() )
                Next dns
            End If
        Next adapter
    
    End Sub 'DisplayDnsAddresses
    