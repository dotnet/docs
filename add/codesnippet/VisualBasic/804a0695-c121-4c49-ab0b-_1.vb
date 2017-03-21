    Public Shared Sub ShowIcmpV4UnreachableData() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim statistics As IcmpV4Statistics = properties.GetIcmpV4Statistics()
        Console.WriteLine("  Destination Unreachables ............ Sent: {0,-10}   Received: {1,-10}", statistics.DestinationUnreachableMessagesSent, statistics.DestinationUnreachableMessagesReceived)
    
    End Sub 'ShowIcmpV4UnreachableData
    