

#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Net::NetworkInformation;
using namespace System::Net::Sockets;

//<Snippet1>
void GetTcpConnections()
{
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   array<TcpConnectionInformation^>^connections = properties->GetActiveTcpConnections();
   System::Collections::IEnumerator^ myEnum = connections->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      TcpConnectionInformation ^ t = safe_cast<TcpConnectionInformation ^>(myEnum->Current);
      Console::Write( "Local endpoint: {0} ", t->LocalEndPoint->Address );
      Console::Write( "Remote endpoint: {0} ", t->RemoteEndPoint->Address );
      Console::WriteLine( "{0}", t->State );
   }
}
//</Snippet1>

//<Snippet2>
void CountTcpConnections()
{
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   array<TcpConnectionInformation^>^connections = properties->GetActiveTcpConnections();
   int establishedConnections = 0;
   System::Collections::IEnumerator^ myEnum1 = connections->GetEnumerator();
   while ( myEnum1->MoveNext() )
   {
      TcpConnectionInformation ^ t = safe_cast<TcpConnectionInformation ^>(myEnum1->Current);
      if ( t->State == TcpState::Established )
      {
         establishedConnections++;
      }

      Console::Write( "Local endpoint: {0} ", t->LocalEndPoint->Address );
      Console::WriteLine( "Remote endpoint: {0} ", t->RemoteEndPoint->Address );
   }

   Console::WriteLine( "There are {0} established TCP connections.", establishedConnections );
}
//</Snippet2>

//<Snippet3>
void DisplayActiveUdpListeners()
{
   Console::WriteLine( "Active UDP Listeners" );
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   array<IPEndPoint^>^endPoints = properties->GetActiveUdpListeners();
   System::Collections::IEnumerator^ myEnum2 = endPoints->GetEnumerator();
   while ( myEnum2->MoveNext() )
   {
      IPEndPoint^ e = safe_cast<IPEndPoint^>(myEnum2->Current);
      Console::WriteLine( e );
   }
}
//</Snippet3>

//<Snippet4>
void ShowNetworkInterfaces()
{
   array<NetworkInterface^>^nics = NetworkInterface::GetAllNetworkInterfaces();
   if ( !nics || nics->Length < 1 )
   {
      Console::WriteLine( "  No network interfaces found." );
      return;
   }

   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   Console::WriteLine( "Interface information for {0}.{1}", properties->HostName, properties->DomainName );
   Console::WriteLine( "  Number of interfaces .................... : {0}", nics->Length );
   System::Collections::IEnumerator^ myEnum3 = nics->GetEnumerator();
   while ( myEnum3->MoveNext() )
   {
      NetworkInterface ^ adapter = safe_cast<NetworkInterface ^>(myEnum3->Current);
      Console::WriteLine();
      Console::WriteLine( adapter->Description );
      Console::WriteLine( String::Empty->PadLeft( adapter->Description->Length, '=' ) );
      Console::WriteLine( "  Interface type .......................... : {0}", 
         adapter->NetworkInterfaceType );
   }
}
//</Snippet4>

//<Snippet5>
void ShowTcpTimeouts()
{
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   TcpStatistics ^ tcpstat = properties->GetTcpIPv4Statistics();
   Console::WriteLine( "  Minimum Transmission Timeout............. : {0}", 
      tcpstat->MinimumTransmissionTimeout );
   Console::WriteLine( "  Maximum Transmission Timeout............. : {0}", 
      tcpstat->MaximumTransmissionTimeout );
   Console::WriteLine( "  Maximum connections ............. : {0}", 
      tcpstat->MaximumConnections );
}
//</Snippet5>

//<Snippet6>
void ShowTcpConnectionStatistics()
{
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   TcpStatistics ^ tcpstat = properties->GetTcpIPv4Statistics();
   Console::WriteLine( "  Connection Data:" );
   Console::WriteLine( "      Current  ............................ : {0}", 
       tcpstat->CurrentConnections );
   Console::WriteLine( "      Cumulative .......................... : {0}", 
       tcpstat->CumulativeConnections );
   Console::WriteLine( "      Initiated ........................... : {0}", 
       tcpstat->ConnectionsInitiated );
   Console::WriteLine( "      Accepted ............................ : {0}", 
       tcpstat->ConnectionsAccepted );
   Console::WriteLine( "      Failed Attempts ..................... : {0}", 
       tcpstat->FailedConnectionAttempts );
   Console::WriteLine( "      Reset ............................... : {0}", 
       tcpstat->ResetConnections );
   Console::WriteLine( "      Errors .............................. : {0}", 
       tcpstat->ErrorsReceived );
}
//</Snippet6>

//<Snippet7>
void ShowTcpSegmentData()
{
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   TcpStatistics ^ tcpstat = properties->GetTcpIPv4Statistics();
   Console::WriteLine( "  Segment Data:" );
   Console::WriteLine( "      Received  ........................... : {0}", 
      tcpstat->SegmentsReceived );
   Console::WriteLine( "      Sent ................................ : {0}", 
      tcpstat->SegmentsSent );
   Console::WriteLine( "      Retransmitted ....................... : {0}", 
      tcpstat->SegmentsResent );
   Console::WriteLine( "      Resent with reset ................... : {0}", 
      tcpstat->ResetsSent );
}
//</Snippet7>

//<Snippet8>     
void ShowInterfaceByteCounts()
{
   array<NetworkInterface^>^adapters = NetworkInterface::GetAllNetworkInterfaces();
   System::Collections::IEnumerator^ myEnum4 = adapters->GetEnumerator();
   while ( myEnum4->MoveNext() )
   {
      NetworkInterface ^ adapter = safe_cast<NetworkInterface ^>(myEnum4->Current);
      IPInterfaceProperties ^ properties = adapter->GetIPProperties();
      IPv4InterfaceStatistics ^ stats = adapter->GetIPv4Statistics();
      Console::WriteLine( adapter->Description );
      Console::WriteLine( "     Bytes sent ............................: {0}", 
         stats->BytesSent );
      Console::WriteLine( "     Bytes received ........................: {0}", 
         stats->BytesReceived );
   }
}
//</Snippet8>

//<Snippet9>     
void ShowUnicastCounts()
{
   array<NetworkInterface^>^adapters = NetworkInterface::GetAllNetworkInterfaces();
   System::Collections::IEnumerator^ myEnum5 = adapters->GetEnumerator();
   while ( myEnum5->MoveNext() )
   {
      NetworkInterface ^ adapter = safe_cast<NetworkInterface ^>(myEnum5->Current);
      IPInterfaceProperties ^ properties = adapter->GetIPProperties();
      IPv4InterfaceStatistics ^ stats = adapter->GetIPv4Statistics();
      Console::WriteLine( adapter->Description );
      Console::WriteLine( "     Unicast Packets Sent ..................: {0}", 
         stats->UnicastPacketsSent );
      Console::WriteLine( "     Unicast Packets Received ..............: {0}", 
         stats->UnicastPacketsReceived );
   }
}
//</Snippet9>

//<Snippet10>     
void ShowNonUnicastCounts()
{
   array<NetworkInterface^>^adapters = NetworkInterface::GetAllNetworkInterfaces();
   System::Collections::IEnumerator^ myEnum6 = adapters->GetEnumerator();
   while ( myEnum6->MoveNext() )
   {
      NetworkInterface ^ adapter = safe_cast<NetworkInterface ^>(myEnum6->Current);
      IPInterfaceProperties ^ properties = adapter->GetIPProperties();
      IPv4InterfaceStatistics ^ stats = adapter->GetIPv4Statistics();
      Console::WriteLine( adapter->Description );
      Console::WriteLine( "     Non Unicast Packets Sent ..............: {0}", 
         stats->NonUnicastPacketsSent );
      Console::WriteLine( "     Non Unicast Packets Received ..........: {0}", 
         stats->NonUnicastPacketsReceived );
   }
}
//</Snippet10>

//<Snippet11>     
void ShowPacketDiscards()
{
   array<NetworkInterface^>^adapters = NetworkInterface::GetAllNetworkInterfaces();
   System::Collections::IEnumerator^ myEnum7 = adapters->GetEnumerator();
   while ( myEnum7->MoveNext() )
   {
      NetworkInterface ^ adapter = safe_cast<NetworkInterface ^>(myEnum7->Current);
      IPInterfaceProperties ^ properties = adapter->GetIPProperties();
      IPv4InterfaceStatistics ^ stats = adapter->GetIPv4Statistics();
      Console::WriteLine( adapter->Description );
      Console::WriteLine( "     Incoming Packets Discarded ............: {0}", 
         stats->IncomingPacketsDiscarded );
      Console::WriteLine( "     Outgoing Packets Discarded ............: {0}", 
         stats->OutgoingPacketsDiscarded );
   }
}
//</Snippet11>

//<Snippet12>     
void ShowPacketErrors()
{
   array<NetworkInterface^>^adapters = NetworkInterface::GetAllNetworkInterfaces();
   System::Collections::IEnumerator^ myEnum8 = adapters->GetEnumerator();
   while ( myEnum8->MoveNext() )
   {
      NetworkInterface ^ adapter = safe_cast<NetworkInterface ^>(myEnum8->Current);
      IPInterfaceProperties ^ properties = adapter->GetIPProperties();
      IPv4InterfaceStatistics ^ stats = adapter->GetIPv4Statistics();
      Console::WriteLine( adapter->Description );
      Console::WriteLine( "     Incoming Packets Errors ...............: {0}", 
         stats->IncomingPacketsWithErrors );
      Console::WriteLine( "     Outgoing packets Errors ...............: {0}", 
         stats->OutgoingPacketsWithErrors );
      Console::WriteLine( "     Incoming Unknown Protocol Errors ......: {0}", 
         stats->IncomingUnknownProtocolPackets );
   }
}
//</Snippet12>

//<Snippet13>     
void ShowInterfaceSpeedAndQueue()
{
   array<NetworkInterface^>^adapters = NetworkInterface::GetAllNetworkInterfaces();
   System::Collections::IEnumerator^ myEnum9 = adapters->GetEnumerator();
   while ( myEnum9->MoveNext() )
   {
      NetworkInterface ^ adapter = safe_cast<NetworkInterface ^>(myEnum9->Current);
      IPInterfaceProperties ^ properties = adapter->GetIPProperties();
      IPv4InterfaceStatistics ^ stats = adapter->GetIPv4Statistics();
      Console::WriteLine( adapter->Description );
      Console::WriteLine( "     Speed .................................: {0}", 
         adapter->Speed );
      Console::WriteLine( "     Output queue length....................: {0}", 
         stats->OutputQueueLength );
   }
}
//</Snippet13>

//<Snippet14>
void ShowIPStatistics()
{
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   IPGlobalStatistics ^ ipstat = properties->GetIPv4GlobalStatistics();
   Console::WriteLine( "  Forwarding enabled ...................... : {0}", 
      ipstat->ForwardingEnabled );
   Console::WriteLine( "  Interfaces .............................. : {0}", 
      ipstat->NumberOfInterfaces );
   Console::WriteLine( "  IP addresses ............................ : {0}", 
      ipstat->NumberOfIPAddresses );
   Console::WriteLine( "  Routes .................................. : {0}", 
      ipstat->NumberOfRoutes );
   Console::WriteLine( "  Default TTL ............................. : {0}", 
      ipstat->DefaultTtl );
}
//</Snippet14>

//<Snippet15>
void ShowInboundIPStatistics()
{
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   IPGlobalStatistics ^ ipstat = properties->GetIPv4GlobalStatistics();
   Console::WriteLine( "  Inbound Packet Data:" );
   Console::WriteLine( "      Received ............................ : {0}", 
      ipstat->ReceivedPackets );
   Console::WriteLine( "      Forwarded ........................... : {0}", 
      ipstat->ReceivedPacketsForwarded );
   Console::WriteLine( "      Delivered ........................... : {0}", 
      ipstat->ReceivedPacketsDelivered );
   Console::WriteLine( "      Discarded ........................... : {0}", 
      ipstat->ReceivedPacketsDiscarded );
}
//</Snippet15>

//<Snippet16>
void ShowInboundIPErrors()
{
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   IPGlobalStatistics ^ ipstat = properties->GetIPv4GlobalStatistics();
   Console::WriteLine( "  Inbound Packet Errors:" );
   Console::WriteLine( "      Header Errors ....................... : {0}", 
      ipstat->ReceivedPacketsWithHeadersErrors );
   Console::WriteLine( "      Address Errors ...................... : {0}", 
      ipstat->ReceivedPacketsWithAddressErrors );
   Console::WriteLine( "      Unknown Protocol Errors ............. : {0}", 
      ipstat->ReceivedPacketsWithUnknownProtocol );
}
//</Snippet16>

//<Snippet17>
void ShowOutboundIPStatistics()
{
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   IPGlobalStatistics ^ ipstat = properties->GetIPv4GlobalStatistics();
   Console::WriteLine( "  Outbound Packet Data:" );
   Console::WriteLine( "      Requested ........................... : {0}", 
      ipstat->OutputPacketRequests );
   Console::WriteLine( "      Discarded ........................... : {0}", 
      ipstat->OutputPacketsDiscarded );
   Console::WriteLine( "      No Routing Discards ................. : {0}", 
      ipstat->OutputPacketsWithNoRoute );
   Console::WriteLine( "      Routing Entry Discards .............. : {0}", 
      ipstat->OutputPacketRoutingDiscards );
}
//</Snippet17>

//<Snippet18>
void ShowFragmentationStatistics()
{
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   IPGlobalStatistics ^ ipstat = properties->GetIPv4GlobalStatistics();
   Console::WriteLine( "  Reassembly Data:" );
   Console::WriteLine( "      Reassembly Timeout .................. : {0}", 
      ipstat->PacketReassemblyTimeout );
   Console::WriteLine( "      Reassemblies Required ............... : {0}", 
      ipstat->PacketReassembliesRequired );
   Console::WriteLine( "      Packets Reassembled ................. : {0}", 
      ipstat->PacketsReassembled );
   Console::WriteLine( "      Packets Fragmented .................. : {0}", 
      ipstat->PacketsFragmented );
   Console::WriteLine( "      Fragment Failures ................... : {0}", 
      ipstat->PacketFragmentFailures );
}
//</Snippet18>

//<Snippet20>
void ShowIcmpV4MessageData()
{
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   IcmpV4Statistics ^ statistics = properties->GetIcmpV4Statistics();
   Console::WriteLine( "  Messages ............................ Sent: {0,-10}   Received: {1,-10}", 
      statistics->MessagesSent, statistics->MessagesReceived );
}
//</Snippet20>

//<Snippet21>
void ShowIcmpV4EchoData()
{
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   IcmpV4Statistics ^ statistics = properties->GetIcmpV4Statistics();
   Console::WriteLine( "  Echo Requests ....................... Sent: {0,-10}   Received: {1,-10}", 
      statistics->EchoRequestsSent, 
      statistics->EchoRequestsReceived );
   Console::WriteLine( "  Echo Replies ........................ Sent: {0,-10}   Received: {1,-10}", 
      statistics->EchoRepliesSent, 
      statistics->EchoRepliesReceived );
}
//</Snippet21>      

//<Snippet22>
void ShowIcmpV4ErrorData()
{
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   IcmpV4Statistics ^ statistics = properties->GetIcmpV4Statistics();
   Console::WriteLine( "  Errors .............................. Sent: {0,-10}   Received: {1,-10}", 
      statistics->ErrorsSent, 
      statistics->ErrorsReceived );
}
//</Snippet22>     

//<Snippet23>
void ShowIcmpV4UnreachableData()
{
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   IcmpV4Statistics ^ statistics = properties->GetIcmpV4Statistics();
   Console::WriteLine( "  Destination Unreachables ............ Sent: {0,-10}   Received: {1,-10}", 
      statistics->DestinationUnreachableMessagesSent, 
      statistics->DestinationUnreachableMessagesReceived );
}
//</Snippet23>     

//<Snippet24>
void ShowSourceQuenchData()
{
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   IcmpV4Statistics ^ statistics = properties->GetIcmpV4Statistics();
   Console::WriteLine( "  Source Quenches ..................... Sent: {0,-10}   Received: {1,-10}", 
      statistics->SourceQuenchesSent, 
      statistics->SourceQuenchesReceived );
}
//</Snippet24>  

//<Snippet25>
void ShowRedirectsData()
{
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   IcmpV4Statistics ^ statistics = properties->GetIcmpV4Statistics();
   Console::WriteLine( "  Redirects ........................... Sent: {0,-10}   Received: {1,-10}", 
      statistics->RedirectsSent, 
      statistics->RedirectsReceived );
}
//</Snippet25>  

//<Snippet26>
void ShowTimeExceededData()
{
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   IcmpV4Statistics ^ statistics = properties->GetIcmpV4Statistics();
   Console::WriteLine( "  TimeExceeded ........................ Sent: {0,-10}   Received: {1,-10}", 
      statistics->TimeExceededMessagesSent, 
      statistics->TimeExceededMessagesReceived );
}
//</Snippet26>  

//<Snippet27>
void ShowParameterData()
{
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   IcmpV4Statistics ^ statistics = properties->GetIcmpV4Statistics();
   Console::WriteLine( "  Parameter Problems .................. Sent: {0,-10}   Received: {1,-10}", 
      statistics->ParameterProblemsSent, 
      statistics->ParameterProblemsReceived );
}
//</Snippet27>

//<Snippet28>
void ShowTimestampData()
{
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   IcmpV4Statistics ^ statistics = properties->GetIcmpV4Statistics();
   Console::WriteLine( "  Timestamp Requests .................. Sent: {0,-10}   Received: {1,-10}", 
      statistics->TimestampRequestsSent, 
      statistics->TimestampRequestsReceived );
   Console::WriteLine( "  Timestamp Replies ................... Sent: {0,-10}   Received: {1,-10}", 
      statistics->TimestampRepliesSent, 
      statistics->TimestampRepliesReceived );
}
//</Snippet28>  

//<Snippet29>
void ShowAddressMaskData()
{
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   IcmpV4Statistics ^ statistics = properties->GetIcmpV4Statistics();
   Console::WriteLine( "  Address Mask Requests ............... Sent: {0,-10}   Received: {1,-10}", 
      statistics->AddressMaskRequestsSent, 
      statistics->AddressMaskRequestsReceived );
   Console::WriteLine( "  Address Mask Replies ................ Sent: {0,-10}   Received: {1,-10}", 
      statistics->AddressMaskRepliesSent, 
      statistics->AddressMaskRepliesReceived );
}
//</Snippet29>  

//<Snippet30>
void ShowIcmpV6EchoData()
{
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   IcmpV6Statistics ^ statistics = properties->GetIcmpV6Statistics();
   Console::WriteLine( "  Echo Requests ....................... Sent: {0,-10}   Received: {1,-10}", 
      statistics->EchoRequestsSent, statistics->EchoRequestsReceived );
   Console::WriteLine( "  Echo Replies ........................ Sent: {0,-10}   Received: {1,-10}", 
      statistics->EchoRepliesSent, statistics->EchoRepliesReceived );
}
//</Snippet30>      

//<Snippet31>
void ShowIcmpV6ErrorData()
{
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   IcmpV6Statistics ^ statistics = properties->GetIcmpV6Statistics();
   Console::WriteLine( "  Errors .............................. Sent: {0,-10}   Received: {1,-10}", 
      statistics->ErrorsSent, statistics->ErrorsReceived );
}
//</Snippet31>     

//<Snippet32>
void ShowIcmpV6UnreachableData()
{
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   IcmpV6Statistics ^ statistics = properties->GetIcmpV6Statistics();
   Console::WriteLine( "  Destination Unreachables ............ Sent: {0,-10}   Received: {1,-10}", 
      statistics->DestinationUnreachableMessagesSent, 
      statistics->DestinationUnreachableMessagesReceived );
}
//</Snippet32>     

//<Snippet33>
void ShowIcmpV6MessageData()
{
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   IcmpV6Statistics ^ statistics = properties->GetIcmpV6Statistics();
   Console::WriteLine( "  Messages ............................ Sent: {0,-10}   Received: {1,-10}", 
      statistics->MessagesSent, statistics->MessagesReceived );
}
//</Snippet33>

//<Snippet34>
void ShowIcmpV6MembershipData()
{
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   IcmpV6Statistics ^ statistics = properties->GetIcmpV6Statistics();
   Console::WriteLine( "  Queries .............................. Sent: {0,-10}   Received: {1,-10}", 
      statistics->MembershipQueriesSent, statistics->MembershipQueriesReceived );
   Console::WriteLine( "  Reductions ........................... Sent: {0,-10}   Received: {1,-10}", 
      statistics->MembershipReductionsSent, statistics->MembershipReductionsReceived );
   Console::WriteLine( "  Reports .............................. Sent: {0,-10}   Received: {1,-10}", 
      statistics->MembershipReportsSent, statistics->MembershipReportsReceived );
}
//</Snippet34>  

//<Snippet35>
void ShowIcmpV6NeighborData()
{
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   IcmpV6Statistics ^ statistics = properties->GetIcmpV6Statistics();
   Console::WriteLine( "  Advertisements ...................... Sent: {0,-10}   Received: {1,-10}", 
      statistics->NeighborAdvertisementsSent, statistics->NeighborAdvertisementsReceived );
   Console::WriteLine( "  Solicits ............................ Sent: {0,-10}   Received: {1,-10}", 
      statistics->NeighborSolicitsSent, statistics->NeighborSolicitsReceived );
}
//</Snippet35>

//<Snippet36>
void ShowIcmpV6BigPacketData()
{
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   IcmpV6Statistics ^ statistics = properties->GetIcmpV6Statistics();
   Console::WriteLine( " Too Big Packet ........................ Sent: {0,-10}   Received: {1,-10}", 
      statistics->PacketTooBigMessagesSent, 
      statistics->PacketTooBigMessagesReceived );
}
//</Snippet36>     

//<Snippet37>
void ShowIcmpV6RedirectsData()
{
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   IcmpV6Statistics ^ statistics = properties->GetIcmpV6Statistics();
   Console::WriteLine( "  Redirects ........................... Sent: {0,-10}   Received: {1,-10}", 
      statistics->RedirectsSent, 
      statistics->RedirectsReceived );
}
//</Snippet37>  

//<Snippet38>
void ShowIcmpV6TimeExceededData()
{
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   IcmpV6Statistics ^ statistics = properties->GetIcmpV6Statistics();
   Console::WriteLine( "  TimeExceeded ........................ Sent: {0,-10}   Received: {1,-10}", 
      statistics->TimeExceededMessagesSent, 
      statistics->TimeExceededMessagesReceived );
}
//</Snippet38>  

//<Snippet39>
void ShowIcmpV6ParameterData()
{
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   IcmpV6Statistics ^ statistics = properties->GetIcmpV6Statistics();
   Console::WriteLine( "  Parameter Problems .................. Sent: {0,-10}   Received: {1,-10}", 
      statistics->ParameterProblemsSent, 
      statistics->ParameterProblemsReceived );
}
//</Snippet39>

//<Snippet40>
void ShowIcmpV6RouterData()
{
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   IcmpV6Statistics ^ statistics = properties->GetIcmpV6Statistics();
   Console::WriteLine( "  Advertisements ....................... Sent: {0,-10}   Received: {1,-10}", 
      statistics->RouterAdvertisementsSent, 
      statistics->RouterAdvertisementsReceived );
   Console::WriteLine( "  Solicits ............................. Sent: {0,-10}   Received: {1,-10}", 
      statistics->RouterSolicitsSent, 
      statistics->RouterSolicitsReceived );
}
//</Snippet40> 

// New content 10/29/03
//<Snippet41>
void DisplayDnsConfiguration()
{
   array<NetworkInterface^>^adapters = NetworkInterface::GetAllNetworkInterfaces();
   System::Collections::IEnumerator^ myEnum10 = adapters->GetEnumerator();
   while ( myEnum10->MoveNext() )
   {
      NetworkInterface ^ adapter = safe_cast<NetworkInterface ^>(myEnum10->Current);
      IPInterfaceProperties ^ properties = adapter->GetIPProperties();
      Console::WriteLine( adapter->Description );
      Console::WriteLine( "  DNS suffix................................. :{0}", 
         properties->DnsSuffix );
      Console::WriteLine( "  DNS enabled ............................. : {0}", 
         properties->IsDnsEnabled );
      Console::WriteLine( "  Dynamically configured DNS .............. : {0}", 
         properties->IsDynamicDnsEnabled );
   }
}
//</Snippet41> 

//<Snippet42>
void DisplayDnsAddresses()
{
   array<NetworkInterface^>^adapters = NetworkInterface::GetAllNetworkInterfaces();
   System::Collections::IEnumerator^ myEnum11 = adapters->GetEnumerator();
   while ( myEnum11->MoveNext() )
   {
      NetworkInterface ^ adapter = safe_cast<NetworkInterface ^>(myEnum11->Current);
      IPInterfaceProperties ^ adapterProperties = adapter->GetIPProperties();
      IPAddressCollection ^ dnsServers = adapterProperties->DnsAddresses;
      if ( dnsServers->Count > 0 )
      {
         Console::WriteLine( adapter->Description );
         System::Collections::IEnumerator^ myEnum12 = dnsServers->GetEnumerator();
         while ( myEnum12->MoveNext() )
         {
            IPAddress ^ dns = safe_cast<IPAddress ^>(myEnum12->Current);
            Console::WriteLine( "  DNS Servers ............................. : {0}", 
               dns->ToString());
         }
      }
   }
}
//</Snippet42> 

//<Snippet43>
void DisplayAnycastAddresses()
{
    int count = 0;
            
    Console::WriteLine( "Anycast Addresses" );
    array<NetworkInterface^>^adapters = NetworkInterface::GetAllNetworkInterfaces();
    System::Collections::IEnumerator^ myEnum13 = adapters->GetEnumerator();
    while ( myEnum13->MoveNext() )
    {
        NetworkInterface ^ adapter = safe_cast<NetworkInterface ^>(myEnum13->Current);
        IPInterfaceProperties ^ adapterProperties = adapter->GetIPProperties();
        IPAddressInformationCollection ^ anyCast = adapterProperties->AnycastAddresses;
        if ( anyCast->Count > 0 )
        {
            Console::WriteLine( adapter->Description );
            System::Collections::IEnumerator^ myEnum14 = anyCast->GetEnumerator();
            while ( myEnum14->MoveNext() )
            {
                IPAddressInformation ^ any = safe_cast<IPAddressInformation ^>(myEnum14->Current);
                Console::WriteLine( "  Anycast Address .......................... : {0} {1} {2}", 
                    any->Address, any->IsTransient ? "Transient" : "", 
                    any->IsDnsEligible ? "DNS Eligible" : "" );
                count++;
            } 
            Console::WriteLine();
        }
    }
    if (count == 0)
    {
        Console::WriteLine("  No anycast addresses were found.");
        Console::WriteLine();
    }
}
//</Snippet43> 

//<Snippet44>
void DisplayMulticastAddresses()
{
   int count = 0;
   
   Console::WriteLine( "Multicast Addresses" );
   array<NetworkInterface^>^adapters = NetworkInterface::GetAllNetworkInterfaces();
   System::Collections::IEnumerator^ myEnum15 = adapters->GetEnumerator();
   while ( myEnum15->MoveNext() )
   {
      NetworkInterface ^ adapter = safe_cast<NetworkInterface ^>(myEnum15->Current);
      IPInterfaceProperties ^ adapterProperties = adapter->GetIPProperties();
      MulticastIPAddressInformationCollection ^ multiCast = adapterProperties->MulticastAddresses;
      if ( multiCast->Count > 0 )
      {
         Console::WriteLine( adapter->Description );
         System::Collections::IEnumerator^ myEnum16 = multiCast->GetEnumerator();
         while ( myEnum16->MoveNext() )
         {
            MulticastIPAddressInformation ^ multi = safe_cast<MulticastIPAddressInformation ^>(myEnum16->Current);
            Console::WriteLine( "  Multicast Address ....................... : {0} {1} {2}", 
               multi->Address, multi->IsTransient ? "Transient" : "", 
               multi->IsDnsEligible ? "DNS Eligible" : "" );
            count++;   
         }
         Console::WriteLine();
      }
   }
    if (count == 0)
    {
        Console::WriteLine("  No multicast addresses were found.");
        Console::WriteLine();
    }
}
//</Snippet44> 

//<Snippet45>
void DisplayUnicastAddresses()
{
   Console::WriteLine( "Unicast Addresses" );
   array<NetworkInterface^>^adapters = NetworkInterface::GetAllNetworkInterfaces();
   System::Collections::IEnumerator^ myEnum17 = adapters->GetEnumerator();
   while ( myEnum17->MoveNext() )
   {
      NetworkInterface ^ adapter = safe_cast<NetworkInterface ^>(myEnum17->Current);
      IPInterfaceProperties ^ adapterProperties = adapter->GetIPProperties();
      UnicastIPAddressInformationCollection ^ uniCast = adapterProperties->UnicastAddresses;
      if ( uniCast->Count > 0 )
      {
         Console::WriteLine( adapter->Description );
         String^ lifeTimeFormat = "dddd, MMMM dd, yyyy  hh:mm:ss tt";
         System::Collections::IEnumerator^ myEnum18 = uniCast->GetEnumerator();
         while ( myEnum18->MoveNext() )
         {
            UnicastIPAddressInformation ^ uni = safe_cast<UnicastIPAddressInformation ^>(myEnum18->Current);
            DateTime when;
            Console::WriteLine( "  Unicast Address ......................... : {0}", 
               uni->Address );
            Console::WriteLine( "     Prefix Origin ........................ : {0}", 
               uni->PrefixOrigin );
            Console::WriteLine( "     Suffix Origin ........................ : {0}", 
               uni->SuffixOrigin );
            Console::WriteLine( "     Duplicate Address Detection .......... : {0}", 
               uni->DuplicateAddressDetectionState );
            
            // Format the lifetimes as Sunday, February 16, 2003 11:33:44 PM
            // if en-us is the current culture.
            // Calculate the date and time at the end of the lifetimes.    
            when = DateTime::UtcNow + TimeSpan::FromSeconds( (double)uni->AddressValidLifetime );
            when = when.ToLocalTime();
            Console::WriteLine( "     Valid Life Time ...................... : {0}", 
               when.ToString( lifeTimeFormat, System::Globalization::CultureInfo::CurrentCulture ) );
            when = DateTime::UtcNow + TimeSpan::FromSeconds( (double)uni->AddressPreferredLifetime );
            when = when.ToLocalTime();
            Console::WriteLine( "     Preferred life time .................. : {0}", 
               when.ToString( lifeTimeFormat, System::Globalization::CultureInfo::CurrentCulture ) );
            when = DateTime::UtcNow + TimeSpan::FromSeconds( (double)uni->DhcpLeaseLifetime );
            when = when.ToLocalTime();
            Console::WriteLine( "     DHCP Leased Life Time ................ : {0}", 
               when.ToString( lifeTimeFormat, System::Globalization::CultureInfo::CurrentCulture ) );
         }
         Console::WriteLine();
      }
   }
}
//</Snippet45> 

//<Snippet46>
void DisplayDhcpServerAddresses()
{
   Console::WriteLine( "DHCP Servers" );
   array<NetworkInterface^>^adapters = NetworkInterface::GetAllNetworkInterfaces();
   System::Collections::IEnumerator^ myEnum19 = adapters->GetEnumerator();
   while ( myEnum19->MoveNext() )
   {
      NetworkInterface ^ adapter = safe_cast<NetworkInterface ^>(myEnum19->Current);
      IPInterfaceProperties ^ adapterProperties = adapter->GetIPProperties();
      IPAddressCollection ^ addresses = adapterProperties->DhcpServerAddresses;
      if ( addresses->Count > 0 )
      {
         Console::WriteLine( adapter->Description );
         System::Collections::IEnumerator^ myEnum20 = addresses->GetEnumerator();
         while ( myEnum20->MoveNext() )
         {
            IPAddress^ address = safe_cast<IPAddress^>(myEnum20->Current);
            Console::WriteLine( "  Dhcp Address ............................ : {0}", 
               address );
         }
         Console::WriteLine();
      }
   }
}
//</Snippet46> 

//<Snippet47>
void DisplayGatewayAddresses()
{
   Console::WriteLine( "Gateways" );
   array<NetworkInterface^>^adapters = NetworkInterface::GetAllNetworkInterfaces();
   System::Collections::IEnumerator^ myEnum21 = adapters->GetEnumerator();
   while ( myEnum21->MoveNext() )
   {
      NetworkInterface ^ adapter = safe_cast<NetworkInterface ^>(myEnum21->Current);
      IPInterfaceProperties ^ adapterProperties = adapter->GetIPProperties();
      GatewayIPAddressInformationCollection ^ addresses = adapterProperties->GatewayAddresses;
      if ( addresses->Count > 0 )
      {
         Console::WriteLine( adapter->Description );
         System::Collections::IEnumerator^ myEnum22 = addresses->GetEnumerator();
         while ( myEnum22->MoveNext() )
         {
            GatewayIPAddressInformation^ address = safe_cast<GatewayIPAddressInformation^>(myEnum22->Current);
            Console::WriteLine( "  Gateway Address ......................... : {0}", 
               address->Address->ToString() );
         }
         Console::WriteLine();
      }
   }
}
//</Snippet47> 

//<Snippet48>
void DisplayIPv4NetworkInterfaces()
{
   array<NetworkInterface^>^nics = NetworkInterface::GetAllNetworkInterfaces();
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   Console::WriteLine( "IPv4 interface information for {0}.{1}", properties->HostName, properties->DomainName );
   System::Collections::IEnumerator^ myEnum23 = nics->GetEnumerator();
   while ( myEnum23->MoveNext() )
   {
      NetworkInterface ^ adapter = safe_cast<NetworkInterface ^>(myEnum23->Current);

      // Only display informatin for interfaces that support IPv4.
      if ( adapter->Supports( NetworkInterfaceComponent::IPv4 ) == false )
      {
         continue;
      }
      Console::WriteLine();
      Console::WriteLine( adapter->Description );

      // Underline the description.
      Console::WriteLine( String::Empty->PadLeft( adapter->Description->Length, '=' ) );
      IPInterfaceProperties ^ adapterProperties = adapter->GetIPProperties();

      // Try to get the IPv4 interface properties.
      IPv4InterfaceProperties ^ p = adapterProperties->GetIPv4Properties();
      if ( !p )
      {
         Console::WriteLine( "No IPv4 information is available for this interface." );
         continue;
      }

      // Display the IPv4 specific data.
      Console::WriteLine( "  Index ............................. : {0}", 
         p->Index );
      Console::WriteLine( "  MTU ............................... : {0}", 
         p->Mtu );
      Console::WriteLine( "  APIPA active....................... : {0}", 
         p->IsAutomaticPrivateAddressingActive );
      Console::WriteLine( "  APIPA enabled...................... : {0}", 
         p->IsAutomaticPrivateAddressingEnabled );
      Console::WriteLine( "  Forwarding enabled................. : {0}", 
         p->IsForwardingEnabled );
      Console::WriteLine( "  Uses WINS ......................... : {0}", 
         p->UsesWins );
   }
}
//</Snippet48>

//<Snippet49>
void DisplayIPv6NetworkInterfaces()
{
   array<NetworkInterface^>^nics = NetworkInterface::GetAllNetworkInterfaces();
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   Console::WriteLine( "IPv6 interface information for {0}.{1}", 
       properties->HostName, properties->DomainName );

   int count = 0;

   System::Collections::IEnumerator^ myEnum24 = nics->GetEnumerator();
   while ( myEnum24->MoveNext() )
   {
      NetworkInterface ^ adapter = safe_cast<NetworkInterface ^>(myEnum24->Current);

      // Only display informatin for interfaces that support IPv6.
      if ( adapter->Supports( NetworkInterfaceComponent::IPv6 ) == false )
      {
         continue;
      }
      
      count++;
      
      Console::WriteLine();
      Console::WriteLine( adapter->Description );

      // Underline the description.
      Console::WriteLine( String::Empty->PadLeft( adapter->Description->Length, '=' ) );
      IPInterfaceProperties ^ adapterProperties = adapter->GetIPProperties();

      // Try to get the IPv6 interface properties.
      IPv6InterfaceProperties ^ p = adapterProperties->GetIPv6Properties();
      if ( !p )
      {
         Console::WriteLine( "No IPv6 information is available for this interface." );
         continue;
      }

      // Display the IPv6 specific data.
      Console::WriteLine( "  Index ............................. : {0}", 
         p->Index );
      Console::WriteLine( "  MTU ............................... : {0}", 
         p->Mtu );
   }
   if (count == 0)
   {
       Console::WriteLine("  No IPv6 interfaces were found.");
       Console::WriteLine();
   }
}
//</Snippet49>

//<Snippet50>
void DisplayWinsServerAddresses()
{
   Console::WriteLine( "WINS Servers" );
   array<NetworkInterface^>^adapters = NetworkInterface::GetAllNetworkInterfaces();
   System::Collections::IEnumerator^ myEnum25 = adapters->GetEnumerator();
   while ( myEnum25->MoveNext() )
   {
      NetworkInterface ^ adapter = safe_cast<NetworkInterface ^>(myEnum25->Current);
      IPInterfaceProperties ^ adapterProperties = adapter->GetIPProperties();
      IPAddressCollection ^ addresses = adapterProperties->WinsServersAddresses;
      if ( addresses->Count > 0 )
      {
         Console::WriteLine( adapter->Description );
         System::Collections::IEnumerator^ myEnum26 = addresses->GetEnumerator();
         while ( myEnum26->MoveNext() )
         {
            IPAddress^ address = safe_cast<IPAddress^>(myEnum26->Current);
            Console::WriteLine( "  WINS Server ............................ : {0}", 
               address );
         }
         Console::WriteLine();
      }
   }
}
//</Snippet50> 

//<Snippet51> 
void DisplayTypeAndAddress()
{
   IPGlobalProperties ^ computerProperties = IPGlobalProperties::GetIPGlobalProperties();
   array<NetworkInterface^>^nics = NetworkInterface::GetAllNetworkInterfaces();
   Console::WriteLine( "Interface information for {0}.{1}     ", computerProperties->HostName, computerProperties->DomainName );
   System::Collections::IEnumerator^ myEnum27 = nics->GetEnumerator();
   while ( myEnum27->MoveNext() )
   {
      NetworkInterface ^ adapter = safe_cast<NetworkInterface ^>(myEnum27->Current);
      IPInterfaceProperties ^ properties = adapter->GetIPProperties();
      Console::WriteLine( adapter->Description );
      Console::WriteLine( String::Empty->PadLeft( adapter->Description->Length, '=' ) );
      Console::WriteLine( "  Interface type .......................... : {0}", 
         adapter->NetworkInterfaceType );
      Console::WriteLine( "  Physical Address ........................ : {0}", 
         adapter->GetPhysicalAddress() );
      Console::WriteLine( "  Is receive only.......................... : {0}", 
         adapter->IsReceiveOnly );
      Console::WriteLine( "  Multicast................................ : {0}", 
         adapter->SupportsMulticast );
   }
}
//</Snippet51> 

int main()
{
    DisplayDnsAddresses();
    DisplayDnsConfiguration();
    DisplayAnycastAddresses();
    DisplayMulticastAddresses();
    DisplayUnicastAddresses();
   
    DisplayDhcpServerAddresses();
    DisplayGatewayAddresses();
   
    DisplayIPv4NetworkInterfaces();
    DisplayIPv6NetworkInterfaces();
    DisplayWinsServerAddresses();

    DisplayTypeAndAddress();
   
    GetTcpConnections();
    CountTcpConnections();
    DisplayActiveUdpListeners();
    ShowTcpSegmentData();
    ShowTcpConnectionStatistics();
    ShowTcpTimeouts();
    ShowInterfaceSpeedAndQueue();
    ShowPacketErrors();
    ShowPacketDiscards();
    ShowNonUnicastCounts();
    ShowUnicastCounts();
    ShowInterfaceByteCounts();
    ShowFragmentationStatistics();
    ShowOutboundIPStatistics();
   //
    ShowInboundIPErrors();
    ShowInboundIPStatistics();
    ShowIPStatistics();
    if (Socket::OSSupportsIPv6)
    {
        ShowIcmpV6MessageData();
        ShowIcmpV6EchoData();
        ShowIcmpV6ErrorData();
        ShowIcmpV6UnreachableData ();
        ShowIcmpV6RouterData ();
    }    
    ShowRedirectsData();
    ShowTimeExceededData();
    if (Socket::OSSupportsIPv6)
    {
        ShowIcmpV6ParameterData ();
    }    
}
