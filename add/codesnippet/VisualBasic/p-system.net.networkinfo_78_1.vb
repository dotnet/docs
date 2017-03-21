    Public Shared Sub ShowIcmpV6RedirectsData() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim statistics As IcmpV6Statistics = properties.GetIcmpV6Statistics()
        Console.WriteLine("  Redirects ........................... Sent: {0,-10}   Received: {1,-10}", statistics.RedirectsSent, statistics.RedirectsReceived)
    
    End Sub 'ShowIcmpV6RedirectsData
    
    