    Public Shared Sub ShowTimeExceededData() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim statistics As IcmpV4Statistics = properties.GetIcmpV4Statistics()
        Console.WriteLine("  TimeExceeded ........................ Sent: {0,-10}   Received: {1,-10}", statistics.TimeExceededMessagesSent, statistics.TimeExceededMessagesReceived)
    
    End Sub 'ShowTimeExceededData
    