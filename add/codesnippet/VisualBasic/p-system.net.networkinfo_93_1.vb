    Public Shared Sub ShowIcmpV4MessageData() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim statistics As IcmpV4Statistics = properties.GetIcmpV4Statistics()
        Console.WriteLine("  Messages ............................ Sent: {0,-10}   Received: {1,-10}", statistics.MessagesSent, statistics.MessagesReceived)
    
    End Sub 'ShowIcmpV4MessageData
    