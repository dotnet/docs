    Public Shared Sub ShowIcmpV6NeighborData() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim statistics As IcmpV6Statistics = properties.GetIcmpV6Statistics()
        Console.WriteLine("  Advertisements ...................... Sent: {0,-10}   Received: {1,-10}", statistics.NeighborAdvertisementsSent, statistics.NeighborAdvertisementsReceived)
        Console.WriteLine("  Solicits ............................ Sent: {0,-10}   Received: {1,-10}", statistics.NeighborSolicitsSent, statistics.NeighborSolicitsReceived)
    
    End Sub 'ShowIcmpV6NeighborData
    