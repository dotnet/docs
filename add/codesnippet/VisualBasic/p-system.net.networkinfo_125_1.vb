    Public Shared Sub ShowParameterData() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim statistics As IcmpV4Statistics = properties.GetIcmpV4Statistics()
        Console.WriteLine("  Parameter Problems .................. Sent: {0,-10}   Received: {1,-10}", statistics.ParameterProblemsSent, statistics.ParameterProblemsReceived)
    
    End Sub 'ShowParameterData
    
    