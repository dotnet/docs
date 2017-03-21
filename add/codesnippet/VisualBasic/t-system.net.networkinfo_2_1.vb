    Public Shared Sub DisplayIPv6NetworkInterfaces() 
        Dim nics As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Console.WriteLine("IPv6 interface information for {0}.{1}", properties.HostName, properties.DomainName)
        
        Dim count as Integer = 0
        
        Dim adapter As NetworkInterface
        For Each adapter In  nics
            ' Only display informatin for interfaces that support IPv6.
            If adapter.Supports(NetworkInterfaceComponent.IPv6) = False Then
                GoTo ContinueForEach1
            End If
            count += 1
            
            Console.WriteLine()
            Console.WriteLine(adapter.Description)
            ' Underline the description.
            Console.WriteLine(String.Empty.PadLeft(adapter.Description.Length, "="c))
            
            Dim adapterProperties As IPInterfaceProperties = adapter.GetIPProperties()
            ' Try to get the IPv6 interface properties.
            Dim p As IPv6InterfaceProperties = adapterProperties.GetIPv6Properties()
            
            
            If p Is Nothing Then
                Console.WriteLine("No IPv6 information is available for this interface.")
                GoTo ContinueForEach1
            End If
            ' Display the IPv6 specific data.
            Console.WriteLine("  Index ............................. : {0}", p.Index)
            Console.WriteLine("  MTU ............................... : {0}", p.Mtu)
        ContinueForEach1:
        Next adapter
    
        if count = 0 then
            Console.WriteLine("  No IPv6 interfaces were found.")
            Console.WriteLine()
        End if
    
    End Sub 'DisplayIPv6NetworkInterfaces
    