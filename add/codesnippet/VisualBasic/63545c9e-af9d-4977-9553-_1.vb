    Public Shared Sub ShowIcmpV6UnreachableData() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim statistics As IcmpV6Statistics = properties.GetIcmpV6Statistics()
        Console.WriteLine("  Destination Unreachables ............ Sent: {0,-10}   Received: {1,-10}", statistics.DestinationUnreachableMessagesSent, statistics.DestinationUnreachableMessagesReceived)
    
    End Sub 'ShowIcmpV6UnreachableData
    
    