    Public Shared Sub DisplayDnsConfiguration() 
        Dim adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
        Dim adapter As NetworkInterface
        For Each adapter In  adapters
            Dim properties As IPInterfaceProperties = adapter.GetIPProperties()
            Console.WriteLine(adapter.Description)
            Console.WriteLine("  DNS suffix................................. :{0}", properties.DnsSuffix)
            Console.WriteLine("  DNS enabled ............................. : {0}", properties.IsDnsEnabled)
            Console.WriteLine("  Dynamically configured DNS .............. : {0}", properties.IsDynamicDnsEnabled)
        Next adapter
    
    End Sub 'DisplayDnsConfiguration
    