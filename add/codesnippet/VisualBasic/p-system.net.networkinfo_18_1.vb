    Public Shared Sub DisplayIPv4NetworkInterfaces() 
        Dim nics As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Console.WriteLine("IPv4 interface information for {0}.{1}", properties.HostName, properties.DomainName)
        
        Dim adapter As NetworkInterface
        For Each adapter In  nics
            ' Only display informatin for interfaces that support IPv4.
            If adapter.Supports(NetworkInterfaceComponent.IPv4) = False Then
                GoTo ContinueForEach1
            End If
            Console.WriteLine()
            Console.WriteLine(adapter.Description)
            ' Underline the description.
            Console.WriteLine(String.Empty.PadLeft(adapter.Description.Length, "="c))
            Dim adapterProperties As IPInterfaceProperties = adapter.GetIPProperties()
            ' Try to get the IPv4 interface properties.
            Dim p As IPv4InterfaceProperties = adapterProperties.GetIPv4Properties()
            
            If p Is Nothing Then
                Console.WriteLine("No IPv4 information is available for this interface.")
                GoTo ContinueForEach1
            End If
            ' Display the IPv4 specific data.
            Console.WriteLine("  Index ............................. : {0}", p.Index)
            Console.WriteLine("  MTU ............................... : {0}", p.Mtu)
            Console.WriteLine("  APIPA active....................... : {0}", p.IsAutomaticPrivateAddressingActive)
            Console.WriteLine("  APIPA enabled...................... : {0}", p.IsAutomaticPrivateAddressingEnabled)
            Console.WriteLine("  Forwarding enabled................. : {0}", p.IsForwardingEnabled)
            Console.WriteLine("  Uses WINS ......................... : {0}", p.UsesWins)
        ContinueForEach1:
        Next adapter
    
    End Sub 'DisplayIPv4NetworkInterfaces
    