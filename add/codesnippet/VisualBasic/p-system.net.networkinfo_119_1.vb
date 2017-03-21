    Public Shared Sub ShowFragmentationStatistics() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim ipstat As IPGlobalStatistics = properties.GetIPv4GlobalStatistics()
        Console.WriteLine("  Reassembly Data:")
        Console.WriteLine("      Reassembly Timeout .................. : {0}", ipstat.PacketReassemblyTimeout)
        Console.WriteLine("      Reassemblies Required ............... : {0}", ipstat.PacketReassembliesRequired)
        Console.WriteLine("      Packets Reassembled ................. : {0}", ipstat.PacketsReassembled)
        Console.WriteLine("      Packets Fragmented .................. : {0}", ipstat.PacketsFragmented)
        Console.WriteLine("      Fragment Failures ................... : {0}", ipstat.PacketFragmentFailures)
    
    End Sub 'ShowFragmentationStatistics
    