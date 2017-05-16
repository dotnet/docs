
Imports System
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Net.Sockets


Public Class NetworkingExample
    
    '<Snippet1>
    Public Shared Sub GetTcpConnections() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim connections As TcpConnectionInformation() = properties.GetActiveTcpConnections()
        
        Dim t As TcpConnectionInformation
        For Each t In  connections
            Console.Write("Local endpoint: {0} ", t.LocalEndPoint.Address)
            Console.Write("Remote endpoint: {0} ", t.RemoteEndPoint.Address)
            Console.WriteLine("{0}", t.State)
        Next t
    
    End Sub 'GetTcpConnections
    
    '</Snippet1>
    '<Snippet2>
    Public Shared Sub CountTcpConnections() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim connections As TcpConnectionInformation() = properties.GetActiveTcpConnections()
        Dim establishedConnections As Integer = 0
        
        Dim t As TcpConnectionInformation
        For Each t In  connections
            If t.State = TcpState.Established Then
                establishedConnections += 1
            End If
            Console.Write("Local endpoint: {0} ", t.LocalEndPoint.Address)
            Console.WriteLine("Remote endpoint: {0} ", t.RemoteEndPoint.Address)
        Next t 
        Console.WriteLine("There are {0} established TCP connections.", establishedConnections)
    
    End Sub 'CountTcpConnections
    
    '</Snippet2>
    '<Snippet3>
    Public Shared Sub DisplayActiveUdpListeners() 
        Console.WriteLine("Active UDP Listeners")
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim endPoints As IPEndPoint() = properties.GetActiveUdpListeners()
        Dim e As IPEndPoint
        For Each e In  endPoints
            Console.WriteLine(e.ToString())
        Next e
    
    End Sub 'DisplayActiveUdpListeners
    
    '</Snippet3>
    '<Snippet4>
    Public Shared Sub ShowNetworkInterfaces() 
        
        Dim nics As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
        If nics Is Nothing OrElse nics.Length < 1 Then
            Console.WriteLine("  No network interfaces found.")
            Return
        End If
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Console.WriteLine("Interface information for {0}.{1}", properties.HostName, properties.DomainName)
        
        Console.WriteLine("  Number of interfaces .................... : {0}", nics.Length)
        Dim adapter As NetworkInterface
        For Each adapter In  nics
            Console.WriteLine()
            Console.WriteLine(adapter.Description)
            Console.WriteLine(String.Empty.PadLeft(adapter.Description.Length, "="c))
            Console.WriteLine("  Interface type .......................... : {0}", adapter.NetworkInterfaceType)
        Next adapter
    
    End Sub 'ShowNetworkInterfaces
    
    '</Snippet4>
    '<Snippet5>
    Public Shared Sub ShowTcpTimeouts() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim tcpstat As TcpStatistics = properties.GetTcpIPv4Statistics()
        
        Console.WriteLine("  Minimum Transmission Timeout............. : {0}", tcpstat.MinimumTransmissionTimeout)
        Console.WriteLine("  Maximum Transmission Timeout............. : {0}", tcpstat.MaximumTransmissionTimeout)
        Console.WriteLine("  Maximum connections ............. : {0}", tcpstat.MaximumConnections)
    
    End Sub 'ShowTcpTimeouts
    
    '</Snippet5>
    '<Snippet6>
    Public Shared Sub ShowTcpConnectionStatistics() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim tcpstat As TcpStatistics = properties.GetTcpIPv4Statistics()
        
        Console.WriteLine("  Connection Data:")
        Console.WriteLine("      Current  ............................ : {0}", tcpstat.CurrentConnections)
        Console.WriteLine("      Cumulative .......................... : {0}", tcpstat.CumulativeConnections)
        Console.WriteLine("      Initiated ........................... : {0}", tcpstat.ConnectionsInitiated)
        Console.WriteLine("      Accepted ............................ : {0}", tcpstat.ConnectionsAccepted)
        Console.WriteLine("      Failed Attempts ..................... : {0}", tcpstat.FailedConnectionAttempts)
        Console.WriteLine("      Reset ............................... : {0}", tcpstat.ResetConnections)
        Console.WriteLine("      Errors .............................. : {0}", tcpstat.ErrorsReceived)
    
    End Sub 'ShowTcpConnectionStatistics
    
    '</Snippet6>
    '<Snippet7>
    Public Shared Sub ShowTcpSegmentData() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim tcpstat As TcpStatistics = properties.GetTcpIPv4Statistics()
        
        Console.WriteLine("  Segment Data:")
        Console.WriteLine("      Received  ........................... : {0}", tcpstat.SegmentsReceived)
        Console.WriteLine("      Sent ................................ : {0}", tcpstat.SegmentsSent)
        Console.WriteLine("      Retransmitted ....................... : {0}", tcpstat.SegmentsResent)
        Console.WriteLine("      Resent with reset ................... : {0}", tcpstat.ResetsSent)
    
    End Sub 'ShowTcpSegmentData
    
    '</Snippet7>
    '<Snippet8>     
    Public Shared Sub ShowInterfaceByteCounts() 
        Dim adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
        Dim adapter As NetworkInterface
        For Each adapter In  adapters
            Dim properties As IPInterfaceProperties = adapter.GetIPProperties()
            Dim stats As IPv4InterfaceStatistics = adapter.GetIPv4Statistics()
            
            Console.WriteLine(adapter.Description)
            Console.WriteLine("     Bytes sent ............................: {0}", stats.BytesSent)
            Console.WriteLine("     Bytes received ........................: {0}", stats.BytesReceived)
        Next adapter
    
    End Sub 'ShowInterfaceByteCounts
    
    '</Snippet8>
    '<Snippet9>     
    Public Shared Sub ShowUnicastCounts() 
        Dim adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
        Dim adapter As NetworkInterface
        For Each adapter In  adapters
            Dim properties As IPInterfaceProperties = adapter.GetIPProperties()
            Dim stats As IPv4InterfaceStatistics = adapter.GetIPv4Statistics()
            Console.WriteLine(adapter.Description)
            Console.WriteLine("     Unicast Packets Sent ..................: {0}", stats.UnicastPacketsSent)
            Console.WriteLine("     Unicast Packets Received ..............: {0}", stats.UnicastPacketsReceived)
        Next adapter
    
    End Sub 'ShowUnicastCounts
    
    '</Snippet9>
    '<Snippet10>     
    Public Shared Sub ShowNonUnicastCounts() 
        Dim adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
        Dim adapter As NetworkInterface
        For Each adapter In  adapters
            Dim properties As IPInterfaceProperties = adapter.GetIPProperties()
            Dim stats As IPv4InterfaceStatistics = adapter.GetIPv4Statistics()
            Console.WriteLine(adapter.Description)
            
            Console.WriteLine("     Non Unicast Packets Sent ..............: {0}", stats.NonUnicastPacketsSent)
            Console.WriteLine("     Non Unicast Packets Received ..........: {0}", stats.NonUnicastPacketsReceived)
        Next adapter
    
    End Sub 'ShowNonUnicastCounts
    
    '</Snippet10>
    '<Snippet11>     
    Public Shared Sub ShowPacketDiscards() 
        Dim adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
        Dim adapter As NetworkInterface
        For Each adapter In  adapters
            Dim properties As IPInterfaceProperties = adapter.GetIPProperties()
            Dim stats As IPv4InterfaceStatistics = adapter.GetIPv4Statistics()
            Console.WriteLine(adapter.Description)
            Console.WriteLine("     Incoming Packets Discarded ............: {0}", stats.IncomingPacketsDiscarded)
            Console.WriteLine("     Outgoing Packets Discarded ............: {0}", stats.OutgoingPacketsDiscarded)
        Next adapter
    
    End Sub 'ShowPacketDiscards
    
    '</Snippet11>
    '<Snippet12>     
    Public Shared Sub ShowPacketErrors() 
        Dim adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
        Dim adapter As NetworkInterface
        For Each adapter In  adapters
            Dim properties As IPInterfaceProperties = adapter.GetIPProperties()
            Dim stats As IPv4InterfaceStatistics = adapter.GetIPv4Statistics()
            Console.WriteLine(adapter.Description)
            Console.WriteLine("     Incoming Packets Errors ...............: {0}", stats.IncomingPacketsWithErrors)
            Console.WriteLine("     Outgoing packets Errors ...............: {0}", stats.OutgoingPacketsWithErrors)
            Console.WriteLine("     Incoming Unknown Protocol Errors ......: {0}", stats.IncomingUnknownProtocolPackets)
        Next adapter
    
    End Sub 'ShowPacketErrors
    
    '</Snippet12>
    '<Snippet13>     
    Public Shared Sub ShowInterfaceSpeedAndQueue() 
        Dim adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
        Dim adapter As NetworkInterface
        For Each adapter In  adapters
            Dim properties As IPInterfaceProperties = adapter.GetIPProperties()
            Dim stats As IPv4InterfaceStatistics = adapter.GetIPv4Statistics()
            Console.WriteLine(adapter.Description)
            Console.WriteLine("     Speed .................................: {0}", adapter.Speed)
            Console.WriteLine("     Output queue length....................: {0}", stats.OutputQueueLength)
        Next adapter
    
    End Sub 'ShowInterfaceSpeedAndQueue
    
    '</Snippet13>
    '<Snippet14>
    Public Shared Sub ShowIPStatistics() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim ipstat As IPGlobalStatistics = properties.GetIPv4GlobalStatistics()
        Console.WriteLine("  Forwarding enabled ...................... : {0}", ipstat.ForwardingEnabled)
        Console.WriteLine("  Interfaces .............................. : {0}", ipstat.NumberOfInterfaces)
        Console.WriteLine("  IP addresses ............................ : {0}", ipstat.NumberOfIPAddresses)
        Console.WriteLine("  Routes .................................. : {0}", ipstat.NumberOfRoutes)
        Console.WriteLine("  Default TTL ............................. : {0}", ipstat.DefaultTtl)
    
    End Sub 'ShowIPStatistics
    
    '</Snippet14>
    '<Snippet15>
    Public Shared Sub ShowInboundIPStatistics() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim ipstat As IPGlobalStatistics = properties.GetIPv4GlobalStatistics()
        Console.WriteLine("  Inbound Packet Data:")
        Console.WriteLine("      Received ............................ : {0}", ipstat.ReceivedPackets)
        Console.WriteLine("      Forwarded ........................... : {0}", ipstat.ReceivedPacketsForwarded)
        Console.WriteLine("      Delivered ........................... : {0}", ipstat.ReceivedPacketsDelivered)
        Console.WriteLine("      Discarded ........................... : {0}", ipstat.ReceivedPacketsDiscarded)
    
    End Sub 'ShowInboundIPStatistics
    
    '</Snippet15>
    '<Snippet16>
    Public Shared Sub ShowInboundIPErrors() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim ipstat As IPGlobalStatistics = properties.GetIPv4GlobalStatistics()
        Console.WriteLine("  Inbound Packet Errors:")
        Console.WriteLine("      Header Errors ....................... : {0}", ipstat.ReceivedPacketsWithHeadersErrors)
        Console.WriteLine("      Address Errors ...................... : {0}", ipstat.ReceivedPacketsWithAddressErrors)
        Console.WriteLine("      Unknown Protocol Errors ............. : {0}", ipstat.ReceivedPacketsWithUnknownProtocol)
    
    End Sub 'ShowInboundIPErrors
    
    '</Snippet16>
    '<Snippet17>
    Public Shared Sub ShowOutboundIPStatistics() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim ipstat As IPGlobalStatistics = properties.GetIPv4GlobalStatistics()
        Console.WriteLine("  Outbound Packet Data:")
        Console.WriteLine("      Requested ........................... : {0}", ipstat.OutputPacketRequests)
        Console.WriteLine("      Discarded ........................... : {0}", ipstat.OutputPacketsDiscarded)
        Console.WriteLine("      No Routing Discards ................. : {0}", ipstat.OutputPacketsWithNoRoute)
        Console.WriteLine("      Routing Entry Discards .............. : {0}", ipstat.OutputPacketRoutingDiscards)
    
    End Sub 'ShowOutboundIPStatistics
    
    '</Snippet17>
    '<Snippet18>
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
    
    '</Snippet18>
    '<Snippet20>
    Public Shared Sub ShowIcmpV4MessageData() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim statistics As IcmpV4Statistics = properties.GetIcmpV4Statistics()
        Console.WriteLine("  Messages ............................ Sent: {0,-10}   Received: {1,-10}", statistics.MessagesSent, statistics.MessagesReceived)
    
    End Sub 'ShowIcmpV4MessageData
    
    '</Snippet20>
    '<Snippet21>
    Public Shared Sub ShowIcmpV4EchoData() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim statistics As IcmpV4Statistics = properties.GetIcmpV4Statistics()
        Console.WriteLine("  Echo Requests ....................... Sent: {0,-10}   Received: {1,-10}", statistics.EchoRequestsSent, statistics.EchoRequestsReceived)
        Console.WriteLine("  Echo Replies ........................ Sent: {0,-10}   Received: {1,-10}", statistics.EchoRepliesSent, statistics.EchoRepliesReceived)
    
    End Sub 'ShowIcmpV4EchoData
    
    '</Snippet21>      
    '<Snippet22>
    Public Shared Sub ShowIcmpV4ErrorData() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim statistics As IcmpV4Statistics = properties.GetIcmpV4Statistics()
        Console.WriteLine("  Errors .............................. Sent: {0,-10}   Received: {1,-10}", statistics.ErrorsSent, statistics.ErrorsReceived)
    
    End Sub 'ShowIcmpV4ErrorData
    
    '</Snippet22>     
    '<Snippet23>
    Public Shared Sub ShowIcmpV4UnreachableData() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim statistics As IcmpV4Statistics = properties.GetIcmpV4Statistics()
        Console.WriteLine("  Destination Unreachables ............ Sent: {0,-10}   Received: {1,-10}", statistics.DestinationUnreachableMessagesSent, statistics.DestinationUnreachableMessagesReceived)
    
    End Sub 'ShowIcmpV4UnreachableData
    
    '</Snippet23>     
    '<Snippet24>
    Public Shared Sub ShowSourceQuenchData() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim statistics As IcmpV4Statistics = properties.GetIcmpV4Statistics()
        Console.WriteLine("  Source Quenches ..................... Sent: {0,-10}   Received: {1,-10}", statistics.SourceQuenchesSent, statistics.SourceQuenchesReceived)
    
    End Sub 'ShowSourceQuenchData
    
    '</Snippet24>  
    '<Snippet25>
    Public Shared Sub ShowRedirectsData() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim statistics As IcmpV4Statistics = properties.GetIcmpV4Statistics()
        Console.WriteLine("  Redirects ........................... Sent: {0,-10}   Received: {1,-10}", statistics.RedirectsSent, statistics.RedirectsReceived)
    
    End Sub 'ShowRedirectsData
    
    '</Snippet25>  
    '<Snippet26>
    Public Shared Sub ShowTimeExceededData() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim statistics As IcmpV4Statistics = properties.GetIcmpV4Statistics()
        Console.WriteLine("  TimeExceeded ........................ Sent: {0,-10}   Received: {1,-10}", statistics.TimeExceededMessagesSent, statistics.TimeExceededMessagesReceived)
    
    End Sub 'ShowTimeExceededData
    
    '</Snippet26>  
    '<Snippet27>
    Public Shared Sub ShowParameterData() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim statistics As IcmpV4Statistics = properties.GetIcmpV4Statistics()
        Console.WriteLine("  Parameter Problems .................. Sent: {0,-10}   Received: {1,-10}", statistics.ParameterProblemsSent, statistics.ParameterProblemsReceived)
    
    End Sub 'ShowParameterData
    
    
    '</Snippet27>
    '<Snippet28>
    Public Shared Sub ShowTimestampData() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim statistics As IcmpV4Statistics = properties.GetIcmpV4Statistics()
        Console.WriteLine("  Timestamp Requests .................. Sent: {0,-10}   Received: {1,-10}", statistics.TimestampRequestsSent, statistics.TimestampRequestsReceived)
        Console.WriteLine("  Timestamp Replies ................... Sent: {0,-10}   Received: {1,-10}", statistics.TimestampRepliesSent, statistics.TimestampRepliesReceived)
    
    End Sub 'ShowTimestampData
    
    
    '</Snippet28>  
    '<Snippet29>
    Public Shared Sub ShowAddressMaskData() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim statistics As IcmpV4Statistics = properties.GetIcmpV4Statistics()
        Console.WriteLine("  Address Mask Requests ............... Sent: {0,-10}   Received: {1,-10}", statistics.AddressMaskRequestsSent, statistics.AddressMaskRequestsReceived)
        Console.WriteLine("  Address Mask Replies ................ Sent: {0,-10}   Received: {1,-10}", statistics.AddressMaskRepliesSent, statistics.AddressMaskRepliesReceived)
    
    End Sub 'ShowAddressMaskData
    
    
    '</Snippet29>  
    
    '<Snippet30>
    Public Shared Sub ShowIcmpV6EchoData() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim statistics As IcmpV6Statistics = properties.GetIcmpV6Statistics()
        Console.WriteLine("  Echo Requests ....................... Sent: {0,-10}   Received: {1,-10}", statistics.EchoRequestsSent, statistics.EchoRequestsReceived)
        Console.WriteLine("  Echo Replies ........................ Sent: {0,-10}   Received: {1,-10}", statistics.EchoRepliesSent, statistics.EchoRepliesReceived)
    
    End Sub 'ShowIcmpV6EchoData
    
    
    '</Snippet30>      
    '<Snippet31>
    Public Shared Sub ShowIcmpV6ErrorData() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim statistics As IcmpV6Statistics = properties.GetIcmpV6Statistics()
        Console.WriteLine("  Errors .............................. Sent: {0,-10}   Received: {1,-10}", statistics.ErrorsSent, statistics.ErrorsReceived)
    
    End Sub 'ShowIcmpV6ErrorData
    
    
    '</Snippet31>     
    '<Snippet32>
    Public Shared Sub ShowIcmpV6UnreachableData() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim statistics As IcmpV6Statistics = properties.GetIcmpV6Statistics()
        Console.WriteLine("  Destination Unreachables ............ Sent: {0,-10}   Received: {1,-10}", statistics.DestinationUnreachableMessagesSent, statistics.DestinationUnreachableMessagesReceived)
    
    End Sub 'ShowIcmpV6UnreachableData
    
    
    '</Snippet32>     
    '<Snippet33>
    Public Shared Sub ShowIcmpV6MessageData() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim statistics As IcmpV6Statistics = properties.GetIcmpV6Statistics()
        Console.WriteLine("  Messages ............................ Sent: {0,-10}   Received: {1,-10}", statistics.MessagesSent, statistics.MessagesReceived)
    
    End Sub 'ShowIcmpV6MessageData
    
    
    '</Snippet33>
    
    '<Snippet34>
    Public Shared Sub ShowIcmpV6MembershipData() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim statistics As IcmpV6Statistics = properties.GetIcmpV6Statistics()
        Console.WriteLine("  Queries .............................. Sent: {0,-10}   Received: {1,-10}", statistics.MembershipQueriesSent, statistics.MembershipQueriesReceived)
        Console.WriteLine("  Reductions ........................... Sent: {0,-10}   Received: {1,-10}", statistics.MembershipReductionsSent, statistics.MembershipReductionsReceived)
        Console.WriteLine("  Reports .............................. Sent: {0,-10}   Received: {1,-10}", statistics.MembershipReportsSent, statistics.MembershipReportsReceived)
    
    End Sub 'ShowIcmpV6MembershipData
    
    
    '</Snippet34>  
    
    '<Snippet35>
    Public Shared Sub ShowIcmpV6NeighborData() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim statistics As IcmpV6Statistics = properties.GetIcmpV6Statistics()
        Console.WriteLine("  Advertisements ...................... Sent: {0,-10}   Received: {1,-10}", statistics.NeighborAdvertisementsSent, statistics.NeighborAdvertisementsReceived)
        Console.WriteLine("  Solicits ............................ Sent: {0,-10}   Received: {1,-10}", statistics.NeighborSolicitsSent, statistics.NeighborSolicitsReceived)
    
    End Sub 'ShowIcmpV6NeighborData
    
    '</Snippet35>
    '<Snippet36>
    Public Shared Sub ShowIcmpV6BigPacketData() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim statistics As IcmpV6Statistics = properties.GetIcmpV6Statistics()
        Console.WriteLine(" Too Big Packet ........................ Sent: {0,-10}   Received: {1,-10}", statistics.PacketTooBigMessagesSent, statistics.PacketTooBigMessagesReceived)
    
    End Sub 'ShowIcmpV6BigPacketData
    
    
    '</Snippet36>     
    
    '<Snippet37>
    Public Shared Sub ShowIcmpV6RedirectsData() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim statistics As IcmpV6Statistics = properties.GetIcmpV6Statistics()
        Console.WriteLine("  Redirects ........................... Sent: {0,-10}   Received: {1,-10}", statistics.RedirectsSent, statistics.RedirectsReceived)
    
    End Sub 'ShowIcmpV6RedirectsData
    
    
    '</Snippet37>  
    '<Snippet38>
    Public Shared Sub ShowIcmpV6TimeExceededData() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim statistics As IcmpV6Statistics = properties.GetIcmpV6Statistics()
        Console.WriteLine("  TimeExceeded ........................ Sent: {0,-10}   Received: {1,-10}", statistics.TimeExceededMessagesSent, statistics.TimeExceededMessagesReceived)
    
    End Sub 'ShowIcmpV6TimeExceededData
    
    
    '</Snippet38>  
    '<Snippet39>
    Public Shared Sub ShowIcmpV6ParameterData() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim statistics As IcmpV6Statistics = properties.GetIcmpV6Statistics()
        Console.WriteLine("  Parameter Problems .................. Sent: {0,-10}   Received: {1,-10}", statistics.ParameterProblemsSent, statistics.ParameterProblemsReceived)
    
    End Sub 'ShowIcmpV6ParameterData
    
    
    '</Snippet39>
    '<Snippet40>
    Public Shared Sub ShowIcmpV6RouterData() 
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim statistics As IcmpV6Statistics = properties.GetIcmpV6Statistics()
        
        Console.WriteLine("  Advertisements ....................... Sent: {0,-10}   Received: {1,-10}", statistics.RouterAdvertisementsSent, statistics.RouterAdvertisementsReceived)
        Console.WriteLine("  Solicits ............................. Sent: {0,-10}   Received: {1,-10}", statistics.RouterSolicitsSent, statistics.RouterSolicitsReceived)
    
    End Sub 'ShowIcmpV6RouterData
    
    
    '</Snippet40> 
    ' New content 10/29/03
    '<Snippet41>
    Public Shared Sub DisplayDnsConfiguration() 
        Dim adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
        Dim adapter As NetworkInterface
        For Each adapter In  adapters
            Dim properties As IPInterfaceProperties = adapter.GetIPProperties()
            Console.WriteLine(adapter.Description)
            Console.WriteLine("  DNS suffix................................. :{0}", properties.DnsSuffix)
            Console.WriteLine("  DNS enabled ............................. : {0}", properties.IsDnsEnabled)
            Console.WriteLine("  Dynamically configured DNS .............. : {0}", properties.IsDynamicDnsEnabled)
        Next adapter
    
    End Sub 'DisplayDnsConfiguration
    
    '</Snippet41> 
    '<Snippet42>
    Public Shared Sub DisplayDnsAddresses() 
        Dim adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
        Dim adapter As NetworkInterface
        For Each adapter In  adapters
            
            Dim adapterProperties As IPInterfaceProperties = adapter.GetIPProperties()
            Dim dnsServers As IPAddressCollection = adapterProperties.DnsAddresses
            If dnsServers.Count > 0 Then
                Console.WriteLine(adapter.Description)
                Dim dns As IPAddress
                For Each dns In  dnsServers
                    Console.WriteLine("  DNS Servers ............................. : {0}",dns.ToString() )
                Next dns
            End If
        Next adapter
    
    End Sub 'DisplayDnsAddresses
    
    '</Snippet42> 
    '<Snippet43>
    Public Shared Sub DisplayAnycastAddresses() 
        Dim count as Integer = 0
        
        Console.WriteLine("Anycast Addresses")
        Dim adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
        Dim adapter As NetworkInterface
        For Each adapter In  adapters
            Dim adapterProperties As IPInterfaceProperties = adapter.GetIPProperties()
            Dim anyCast As IPAddressInformationCollection = adapterProperties.AnycastAddresses
            If anyCast.Count > 0 Then
                Console.WriteLine(adapter.Description)
                Dim any As IPAddressInformation
                For Each any In  anyCast
                    Console.WriteLine("  Anycast Address .......................... : {0} {1} {2}", any.Address, IIf(any.IsTransient, "Transient", ""), IIf(any.IsDnsEligible, "DNS Eligible", ""))
                'TODO: For performance reasons this should be changed to nested IF statements
                'TODO: For performance reasons this should be changed to nested IF statements
                    count += 1
                Next any
                Console.WriteLine()
            End If
        Next adapter
    
        if count = 0 then
            Console.WriteLine("  No anycast addresses were found.")
            Console.WriteLine()
        End if
    End Sub 'DisplayAnycastAddresses
    
    '</Snippet43> 
    '<Snippet44>
    Public Shared Sub DisplayMulticastAddresses() 
        Dim count as Integer = 0
        
        Console.WriteLine("Multicast Addresses")
        Dim adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
        Dim adapter As NetworkInterface
        For Each adapter In  adapters
            Dim adapterProperties As IPInterfaceProperties = adapter.GetIPProperties()
            Dim multiCast As MulticastIPAddressInformationCollection = adapterProperties.MulticastAddresses
            If multiCast.Count > 0 Then
                Console.WriteLine(adapter.Description)
                Dim multi As IPAddressInformation
                For Each multi In  multiCast
                    Console.WriteLine("  Multicast Address ....................... : {0} {1} {2}", multi.Address, IIf(multi.IsTransient, "Transient", ""), IIf(multi.IsDnsEligible, "DNS Eligible", ""))
                'TODO: For performance reasons this should be changed to nested IF statements
                'TODO: For performance reasons this should be changed to nested IF statements
                    count += 1
                Next multi
                Console.WriteLine()
            End If
        Next adapter
    
        if count = 0 then
            Console.WriteLine("  No multicast addresses were found.")
            Console.WriteLine()
        End if
    
    End Sub 'DisplayMulticastAddresses
    
    '</Snippet44> 
    '<Snippet45>
    Public Shared Sub DisplayUnicastAddresses() 

        Console.WriteLine("Unicast Addresses")
        Dim adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
        Dim adapter As NetworkInterface
        For Each adapter In  adapters
            Dim adapterProperties As IPInterfaceProperties = adapter.GetIPProperties()
            Dim uniCast As UnicastIPAddressInformationCollection = adapterProperties.UnicastAddresses
            If uniCast.Count > 0 Then
                Console.WriteLine(adapter.Description)
                Dim lifeTimeFormat As String = "dddd, MMMM dd, yyyy  hh:mm:ss tt"
                Dim uni As UnicastIPAddressInformation
                For Each uni In  uniCast
                    Dim [when] As DateTime
                    
                    Console.WriteLine("  Unicast Address ......................... : {0}", uni.Address)
                    Console.WriteLine("     Prefix Origin ........................ : {0}", uni.PrefixOrigin)
                    Console.WriteLine("     Suffix Origin ........................ : {0}", uni.SuffixOrigin)
                    Console.WriteLine("     Duplicate Address Detection .......... : {0}", uni.DuplicateAddressDetectionState)
                    
                    ' Format the lifetimes as Sunday, February 16, 2003 11:33:44 PM
                    ' if en-us is the current culture.
                    ' Calculate the date and time at the end of the lifetimes.    
                    [when] = DateTime.UtcNow + TimeSpan.FromSeconds(uni.AddressValidLifetime)
                    [when] = [when].ToLocalTime()
                    Console.WriteLine("     Valid Life Time ...................... : {0}", [when].ToString(lifeTimeFormat, System.Globalization.CultureInfo.CurrentCulture))
                    [when] = DateTime.UtcNow + TimeSpan.FromSeconds(uni.AddressPreferredLifetime)
                    [when] = [when].ToLocalTime()
                    Console.WriteLine("     Preferred life time .................. : {0}", [when].ToString(lifeTimeFormat, System.Globalization.CultureInfo.CurrentCulture))
                    
                    [when] = DateTime.UtcNow + TimeSpan.FromSeconds(uni.DhcpLeaseLifetime)
                    [when] = [when].ToLocalTime()
                    Console.WriteLine("     DHCP Leased Life Time ................ : {0}", [when].ToString(lifeTimeFormat, System.Globalization.CultureInfo.CurrentCulture))
                Next uni
                Console.WriteLine()
            End If
        Next adapter
    
    End Sub 'DisplayUnicastAddresses
    
    '</Snippet45> 
    
    '<Snippet46>
    Public Shared Sub DisplayDhcpServerAddresses() 
        Console.WriteLine("DHCP Servers")
        Dim adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
        Dim adapter As NetworkInterface
        For Each adapter In  adapters
            
            Dim adapterProperties As IPInterfaceProperties = adapter.GetIPProperties()
            Dim addresses As IPAddressCollection = adapterProperties.DhcpServerAddresses
            If addresses.Count > 0 Then
                Console.WriteLine(adapter.Description)
                Dim address As IPAddress
                For Each address In  addresses
                    Console.WriteLine("  Dhcp Address ............................ : {0}", address.ToString())
                Next address
                Console.WriteLine()
            End If
        Next adapter
    
    End Sub 'DisplayDhcpServerAddresses
    
    '</Snippet46> 
    '<Snippet47>
    Public Shared Sub DisplayGatewayAddresses() 
        Console.WriteLine("Gateways")
        Dim adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
        Dim adapter As NetworkInterface
        For Each adapter In  adapters
            Dim adapterProperties As IPInterfaceProperties = adapter.GetIPProperties()
            Dim addresses As GatewayIPAddressInformationCollection = adapterProperties.GatewayAddresses
            If addresses.Count > 0 Then
                Console.WriteLine(adapter.Description)
                Dim address As GatewayIPAddressInformation
                For Each address In  addresses
                    Console.WriteLine("  Gateway Address ......................... : {0}", address.ToString())
                Next address
                Console.WriteLine()
            End If
        Next adapter
    
    End Sub 'DisplayGatewayAddresses
    
    '</Snippet47> 
    
    '<Snippet48>
    Public Shared Sub DisplayIPv4NetworkInterfaces() 
        Dim nics As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Console.WriteLine("IPv4 interface information for {0}.{1}", properties.HostName, properties.DomainName)
        
        Dim adapter As NetworkInterface
        For Each adapter In  nics
            ' Only display informatin for interfaces that support IPv4.
            If adapter.Supports(NetworkInterfaceComponent.IPv4) = False Then
                GoTo ContinueForEach1
            End If
            Console.WriteLine()
            Console.WriteLine(adapter.Description)
            ' Underline the description.
            Console.WriteLine(String.Empty.PadLeft(adapter.Description.Length, "="c))
            Dim adapterProperties As IPInterfaceProperties = adapter.GetIPProperties()
            ' Try to get the IPv4 interface properties.
            Dim p As IPv4InterfaceProperties = adapterProperties.GetIPv4Properties()
            
            If p Is Nothing Then
                Console.WriteLine("No IPv4 information is available for this interface.")
                GoTo ContinueForEach1
            End If
            ' Display the IPv4 specific data.
            Console.WriteLine("  Index ............................. : {0}", p.Index)
            Console.WriteLine("  MTU ............................... : {0}", p.Mtu)
            Console.WriteLine("  APIPA active....................... : {0}", p.IsAutomaticPrivateAddressingActive)
            Console.WriteLine("  APIPA enabled...................... : {0}", p.IsAutomaticPrivateAddressingEnabled)
            Console.WriteLine("  Forwarding enabled................. : {0}", p.IsForwardingEnabled)
            Console.WriteLine("  Uses WINS ......................... : {0}", p.UsesWins)
        ContinueForEach1:
        Next adapter
    
    End Sub 'DisplayIPv4NetworkInterfaces
    
    '</Snippet48>
    '<Snippet49>
    Public Shared Sub DisplayIPv6NetworkInterfaces() 
        Dim nics As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
        Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Console.WriteLine("IPv6 interface information for {0}.{1}", properties.HostName, properties.DomainName)
        
        Dim count as Integer = 0
        
        Dim adapter As NetworkInterface
        For Each adapter In  nics
            ' Only display informatin for interfaces that support IPv6.
            If adapter.Supports(NetworkInterfaceComponent.IPv6) = False Then
                GoTo ContinueForEach1
            End If
            count += 1
            
            Console.WriteLine()
            Console.WriteLine(adapter.Description)
            ' Underline the description.
            Console.WriteLine(String.Empty.PadLeft(adapter.Description.Length, "="c))
            
            Dim adapterProperties As IPInterfaceProperties = adapter.GetIPProperties()
            ' Try to get the IPv6 interface properties.
            Dim p As IPv6InterfaceProperties = adapterProperties.GetIPv6Properties()
            
            
            If p Is Nothing Then
                Console.WriteLine("No IPv6 information is available for this interface.")
                GoTo ContinueForEach1
            End If
            ' Display the IPv6 specific data.
            Console.WriteLine("  Index ............................. : {0}", p.Index)
            Console.WriteLine("  MTU ............................... : {0}", p.Mtu)
        ContinueForEach1:
        Next adapter
    
        if count = 0 then
            Console.WriteLine("  No IPv6 interfaces were found.")
            Console.WriteLine()
        End if
    
    End Sub 'DisplayIPv6NetworkInterfaces
    
    '</Snippet49>
    
    '<Snippet50>
    Public Shared Sub DisplayWinsServerAddresses() 
        Console.WriteLine("WINS Servers")
        Dim adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
        Dim adapter As NetworkInterface
        For Each adapter In  adapters
            
            Dim adapterProperties As IPInterfaceProperties = adapter.GetIPProperties()
            Dim addresses As IPAddressCollection = adapterProperties.WinsServersAddresses
            If addresses.Count > 0 Then
                Console.WriteLine(adapter.Description)
                Dim address As IPAddress
                For Each address In  addresses
                    Console.WriteLine("  WINS Server ............................ : {0}", address.ToString())
                Next address
                Console.WriteLine()
            End If
        Next adapter
    
    End Sub 'DisplayWinsServerAddresses
    
    '</Snippet50> 
    '<Snippet51> 
    Public Shared Sub DisplayTypeAndAddress() 
        Dim computerProperties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
        Dim nics As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
        Console.WriteLine("Interface information for {0}.{1}     ", computerProperties.HostName, computerProperties.DomainName)
        Dim adapter As NetworkInterface
        For Each adapter In  nics
            Dim properties As IPInterfaceProperties = adapter.GetIPProperties()
            Console.WriteLine(adapter.Description)
            Console.WriteLine(String.Empty.PadLeft(adapter.Description.Length, "="c))
            Console.WriteLine("  Interface type .......................... : {0}", adapter.NetworkInterfaceType)
            Console.WriteLine("  Physical Address ........................ : {0}", adapter.GetPhysicalAddress().ToString())
            Console.WriteLine("  Is receive only.......................... : {0}", adapter.IsReceiveOnly)
            Console.WriteLine("  Multicast................................ : {0}", adapter.SupportsMulticast)
        Next adapter
    
    End Sub 'DisplayTypeAndAddress
    
    '</Snippet51> 
    
    Public Shared Sub Main() 
        '
        DisplayIPv4NetworkInterfaces()
        DisplayIPv6NetworkInterfaces()

        DisplayUnicastAddresses()
        DisplayMulticastAddresses()
        DisplayAnycastAddresses()

        DisplayDnsAddresses()
        DisplayDnsConfiguration()

        DisplayDhcpServerAddresses()
        DisplayGatewayAddresses()

        DisplayWinsServerAddresses()
 
        
        DisplayTypeAndAddress()

        GetTcpConnections()
        CountTcpConnections()
        DisplayActiveUdpListeners()
        ShowTcpSegmentData()
        ShowTcpConnectionStatistics()
        ShowTcpTimeouts()
        ShowInterfaceSpeedAndQueue()
        ShowPacketErrors()
        ShowPacketDiscards()
        ShowNonUnicastCounts()
        ShowUnicastCounts()
        ShowInterfaceByteCounts()
        ShowFragmentationStatistics()
        ShowOutboundIPStatistics()
'
        ShowInboundIPErrors()
        ShowInboundIPStatistics()
        ShowIPStatistics()
'         ShowIcmpV6MessageData()
'         ShowIcmpV6EchoData()
'         ShowIcmpV6ErrorData()
'         ShowIcmpV6UnreachableData ()
'         ShowIcmpV6RouterData ()
        ShowRedirectsData()
        ShowTimeExceededData()
'         ShowIcmpV6ParameterData ()
    
    End Sub 'Main 
End Class 'NetworkingExample '           GetTcpConnections();
