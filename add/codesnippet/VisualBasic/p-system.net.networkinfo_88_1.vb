    Public Shared Sub ShowIcmpV4EchoData() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim statistics As IcmpV4Statistics = properties.GetIcmpV4Statistics()
        Console.WriteLine("  Echo Requests ....................... Sent: {0,-10}   Received: {1,-10}", statistics.EchoRequestsSent, statistics.EchoRequestsReceived)
        Console.WriteLine("  Echo Replies ........................ Sent: {0,-10}   Received: {1,-10}", statistics.EchoRepliesSent, statistics.EchoRepliesReceived)
    
    End Sub 'ShowIcmpV4EchoData
    