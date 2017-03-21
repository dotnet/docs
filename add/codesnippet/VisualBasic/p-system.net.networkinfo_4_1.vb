    Public Shared Sub ShowIcmpV6RouterData() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim statistics As IcmpV6Statistics = properties.GetIcmpV6Statistics()
        
        Console.WriteLine("  Advertisements ....................... Sent: {0,-10}   Received: {1,-10}", statistics.RouterAdvertisementsSent, statistics.RouterAdvertisementsReceived)
        Console.WriteLine("  Solicits ............................. Sent: {0,-10}   Received: {1,-10}", statistics.RouterSolicitsSent, statistics.RouterSolicitsReceived)
    
    End Sub 'ShowIcmpV6RouterData
    
    