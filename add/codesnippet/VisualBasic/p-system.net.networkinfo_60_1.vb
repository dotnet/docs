    Public Shared Sub ShowTcpSegmentData() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim tcpstat As TcpStatistics = properties.GetTcpIPv4Statistics()
        
        Console.WriteLine("  Segment Data:")
        Console.WriteLine("      Received  ........................... : {0}", tcpstat.SegmentsReceived)
        Console.WriteLine("      Sent ................................ : {0}", tcpstat.SegmentsSent)
        Console.WriteLine("      Retransmitted ....................... : {0}", tcpstat.SegmentsResent)
        Console.WriteLine("      Resent with reset ................... : {0}", tcpstat.ResetsSent)
    
    End Sub 'ShowTcpSegmentData
    