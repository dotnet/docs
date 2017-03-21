    Public Shared Sub CountTcpConnections() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim connections As TcpConnectionInformation() = properties.GetActiveTcpConnections()
        Dim establishedConnections As Integer = 0
        
        Dim t As TcpConnectionInformation
        For Each t In  connections
            If t.State = TcpState.Established Then
                establishedConnections += 1
            End If
            Console.Write("Local endpoint: {0} ", t.LocalEndPoint.Address)
            Console.WriteLine("Remote endpoint: {0} ", t.RemoteEndPoint.Address)
        Next t 
        Console.WriteLine("There are {0} established TCP connections.", establishedConnections)
    
    End Sub 'CountTcpConnections
    