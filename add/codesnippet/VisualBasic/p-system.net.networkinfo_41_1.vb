    Public Shared Sub ShowIcmpV6MessageData() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim statistics As IcmpV6Statistics = properties.GetIcmpV6Statistics()
        Console.WriteLine("  Messages ............................ Sent: {0,-10}   Received: {1,-10}", statistics.MessagesSent, statistics.MessagesReceived)
    
    End Sub 'ShowIcmpV6MessageData
    
    