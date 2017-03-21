    Public Shared Sub ShowIcmpV4ErrorData() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim statistics As IcmpV4Statistics = properties.GetIcmpV4Statistics()
        Console.WriteLine("  Errors .............................. Sent: {0,-10}   Received: {1,-10}", statistics.ErrorsSent, statistics.ErrorsReceived)
    
    End Sub 'ShowIcmpV4ErrorData
    