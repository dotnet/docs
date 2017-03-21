    Public Shared Sub ShowIcmpV6ErrorData() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim statistics As IcmpV6Statistics = properties.GetIcmpV6Statistics()
        Console.WriteLine("  Errors .............................. Sent: {0,-10}   Received: {1,-10}", statistics.ErrorsSent, statistics.ErrorsReceived)
    
    End Sub 'ShowIcmpV6ErrorData
    
    