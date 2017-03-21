    Public Shared Sub ShowRedirectsData() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim statistics As IcmpV4Statistics = properties.GetIcmpV4Statistics()
        Console.WriteLine("  Redirects ........................... Sent: {0,-10}   Received: {1,-10}", statistics.RedirectsSent, statistics.RedirectsReceived)
    
    End Sub 'ShowRedirectsData
    