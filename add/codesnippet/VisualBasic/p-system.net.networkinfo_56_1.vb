    Public Shared Sub ShowTimestampData() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim statistics As IcmpV4Statistics = properties.GetIcmpV4Statistics()
        Console.WriteLine("  Timestamp Requests .................. Sent: {0,-10}   Received: {1,-10}", statistics.TimestampRequestsSent, statistics.TimestampRequestsReceived)
        Console.WriteLine("  Timestamp Replies ................... Sent: {0,-10}   Received: {1,-10}", statistics.TimestampRepliesSent, statistics.TimestampRepliesReceived)
    
    End Sub 'ShowTimestampData
    
    