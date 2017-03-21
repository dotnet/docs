    Public Shared Sub ShowIPStatistics() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim ipstat As IPGlobalStatistics = properties.GetIPv4GlobalStatistics()
        Console.WriteLine("  Forwarding enabled ...................... : {0}", ipstat.ForwardingEnabled)
        Console.WriteLine("  Interfaces .............................. : {0}", ipstat.NumberOfInterfaces)
        Console.WriteLine("  IP addresses ............................ : {0}", ipstat.NumberOfIPAddresses)
        Console.WriteLine("  Routes .................................. : {0}", ipstat.NumberOfRoutes)
        Console.WriteLine("  Default TTL ............................. : {0}", ipstat.DefaultTtl)
    
    End Sub 'ShowIPStatistics
    