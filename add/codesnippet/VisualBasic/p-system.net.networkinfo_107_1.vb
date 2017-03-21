    Public Shared Sub ShowTcpTimeouts() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim tcpstat As TcpStatistics = properties.GetTcpIPv4Statistics()
        
        Console.WriteLine("  Minimum Transmission Timeout............. : {0}", tcpstat.MinimumTransmissionTimeout)
        Console.WriteLine("  Maximum Transmission Timeout............. : {0}", tcpstat.MaximumTransmissionTimeout)
        Console.WriteLine("  Maximum connections ............. : {0}", tcpstat.MaximumConnections)
    
    End Sub 'ShowTcpTimeouts
    