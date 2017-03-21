    Public Shared Sub ShowIcmpV6ParameterData() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim statistics As IcmpV6Statistics = properties.GetIcmpV6Statistics()
        Console.WriteLine("  Parameter Problems .................. Sent: {0,-10}   Received: {1,-10}", statistics.ParameterProblemsSent, statistics.ParameterProblemsReceived)
    
    End Sub 'ShowIcmpV6ParameterData
    
    