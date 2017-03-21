    Public Shared Sub ShowTcpConnectionStatistics() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim tcpstat As TcpStatistics = properties.GetTcpIPv4Statistics()
        
        Console.WriteLine("  Connection Data:")
        Console.WriteLine("      Current  ............................ : {0}", tcpstat.CurrentConnections)
        Console.WriteLine("      Cumulative .......................... : {0}", tcpstat.CumulativeConnections)
        Console.WriteLine("      Initiated ........................... : {0}", tcpstat.ConnectionsInitiated)
        Console.WriteLine("      Accepted ............................ : {0}", tcpstat.ConnectionsAccepted)
        Console.WriteLine("      Failed Attempts ..................... : {0}", tcpstat.FailedConnectionAttempts)
        Console.WriteLine("      Reset ............................... : {0}", tcpstat.ResetConnections)
        Console.WriteLine("      Errors .............................. : {0}", tcpstat.ErrorsReceived)
    
    End Sub 'ShowTcpConnectionStatistics
    