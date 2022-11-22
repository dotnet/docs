public static partial class Program
{
    static void ShowIPGlobalProperties()
    {
        // <ipglobalprops>
        ShowStatistics(NetworkInterfaceComponent.IPv4);
        ShowStatistics(NetworkInterfaceComponent.IPv6);

        static void ShowStatistics(NetworkInterfaceComponent version)
        {
            var properties = IPGlobalProperties.GetIPGlobalProperties();
            var stats = version switch
            {
                NetworkInterfaceComponent.IPv4 => properties.GetTcpIPv4Statistics(),
                _ => properties.GetTcpIPv6Statistics()
            };

            Console.WriteLine($"TCP/{version} Statistics");
            Console.WriteLine($"  Minimum Transmission Timeout : {stats.MinimumTransmissionTimeout:#,#}");
            Console.WriteLine($"  Maximum Transmission Timeout : {stats.MaximumTransmissionTimeout:#,#}");
            Console.WriteLine("  Connection Data");
            Console.WriteLine($"      Current :                  {stats.CurrentConnections:#,#}");
            Console.WriteLine($"      Cumulative :               {stats.CumulativeConnections:#,#}");
            Console.WriteLine($"      Initiated  :               {stats.ConnectionsInitiated:#,#}");
            Console.WriteLine($"      Accepted :                 {stats.ConnectionsAccepted:#,#}");
            Console.WriteLine($"      Failed Attempts :          {stats.FailedConnectionAttempts:#,#}");
            Console.WriteLine($"      Reset :                    {stats.ResetConnections:#,#}");
            Console.WriteLine("  Segment Data");
            Console.WriteLine($"      Received :                 {stats.SegmentsReceived:#,#}");
            Console.WriteLine($"      Sent :                     {stats.SegmentsSent:#,#}");
            Console.WriteLine($"      Retransmitted :            {stats.SegmentsResent:#,#}");
            Console.WriteLine();
        }
        // </ipglobalprops>
    }
}
