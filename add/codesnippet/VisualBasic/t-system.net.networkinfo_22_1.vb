    Public Shared Sub GetTcpConnections() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim connections As TcpConnectionInformation() = properties.GetActiveTcpConnections()
        
        Dim t As TcpConnectionInformation
        For Each t In  connections
            Console.Write("Local endpoint: {0} ", t.LocalEndPoint.Address)
            Console.Write("Remote endpoint: {0} ", t.RemoteEndPoint.Address)
            Console.WriteLine("{0}", t.State)
        Next t
    
    End Sub 'GetTcpConnections
    