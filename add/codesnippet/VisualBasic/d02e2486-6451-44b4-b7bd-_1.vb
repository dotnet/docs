    Public Shared Sub ShowInboundIPErrors() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim ipstat As IPGlobalStatistics = properties.GetIPv4GlobalStatistics()
        Console.WriteLine("  Inbound Packet Errors:")
        Console.WriteLine("      Header Errors ....................... : {0}", ipstat.ReceivedPacketsWithHeadersErrors)
        Console.WriteLine("      Address Errors ...................... : {0}", ipstat.ReceivedPacketsWithAddressErrors)
        Console.WriteLine("      Unknown Protocol Errors ............. : {0}", ipstat.ReceivedPacketsWithUnknownProtocol)
    
    End Sub 'ShowInboundIPErrors
    