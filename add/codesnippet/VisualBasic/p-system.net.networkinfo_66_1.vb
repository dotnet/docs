    Public Shared Sub DisplayTypeAndAddress() 
        Dim computerProperties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim nics As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
        Console.WriteLine("Interface information for {0}.{1}     ", computerProperties.HostName, computerProperties.DomainName)
        Dim adapter As NetworkInterface
        For Each adapter In  nics
            Dim properties As IPInterfaceProperties = adapter.GetIPProperties()
            Console.WriteLine(adapter.Description)
            Console.WriteLine(String.Empty.PadLeft(adapter.Description.Length, "="c))
            Console.WriteLine("  Interface type .......................... : {0}", adapter.NetworkInterfaceType)
            Console.WriteLine("  Physical Address ........................ : {0}", adapter.GetPhysicalAddress().ToString())
            Console.WriteLine("  Is receive only.......................... : {0}", adapter.IsReceiveOnly)
            Console.WriteLine("  Multicast................................ : {0}", adapter.SupportsMulticast)
        Next adapter
    
    End Sub 'DisplayTypeAndAddress
    