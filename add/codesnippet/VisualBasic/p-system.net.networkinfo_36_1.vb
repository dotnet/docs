    Public Shared Sub ShowOutboundIPStatistics() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim ipstat As IPGlobalStatistics = properties.GetIPv4GlobalStatistics()
        Console.WriteLine("  Outbound Packet Data:")
        Console.WriteLine("      Requested ........................... : {0}", ipstat.OutputPacketRequests)
        Console.WriteLine("      Discarded ........................... : {0}", ipstat.OutputPacketsDiscarded)
        Console.WriteLine("      No Routing Discards ................. : {0}", ipstat.OutputPacketsWithNoRoute)
        Console.WriteLine("      Routing Entry Discards .............. : {0}", ipstat.OutputPacketRoutingDiscards)
    
    End Sub 'ShowOutboundIPStatistics
    