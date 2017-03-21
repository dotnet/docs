    Public Shared Sub ShowSourceQuenchData() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim statistics As IcmpV4Statistics = properties.GetIcmpV4Statistics()
        Console.WriteLine("  Source Quenches ..................... Sent: {0,-10}   Received: {1,-10}", statistics.SourceQuenchesSent, statistics.SourceQuenchesReceived)
    
    End Sub 'ShowSourceQuenchData
    