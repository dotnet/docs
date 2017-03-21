    Public Shared Sub ShowIcmpV6TimeExceededData() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim statistics As IcmpV6Statistics = properties.GetIcmpV6Statistics()
        Console.WriteLine("  TimeExceeded ........................ Sent: {0,-10}   Received: {1,-10}", statistics.TimeExceededMessagesSent, statistics.TimeExceededMessagesReceived)
    
    End Sub 'ShowIcmpV6TimeExceededData
    
    