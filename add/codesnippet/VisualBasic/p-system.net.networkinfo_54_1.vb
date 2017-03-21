    Public Shared Sub ShowInboundIPStatistics() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim ipstat As IPGlobalStatistics = properties.GetIPv4GlobalStatistics()
        Console.WriteLine("  Inbound Packet Data:")
        Console.WriteLine("      Received ............................ : {0}", ipstat.ReceivedPackets)
        Console.WriteLine("      Forwarded ........................... : {0}", ipstat.ReceivedPacketsForwarded)
        Console.WriteLine("      Delivered ........................... : {0}", ipstat.ReceivedPacketsDelivered)
        Console.WriteLine("      Discarded ........................... : {0}", ipstat.ReceivedPacketsDiscarded)
    
    End Sub 'ShowInboundIPStatistics
    