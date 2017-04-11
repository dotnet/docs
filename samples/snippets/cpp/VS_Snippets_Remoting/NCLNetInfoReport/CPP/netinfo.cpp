

// Sample NCLNetInfoReport
#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Net::Sockets;
using namespace System::Net::NetworkInformation;
using namespace System::Text;

//<Snippet1>
void ShowIPStatistics( NetworkInterfaceComponent version )
{
   //<Snippet20>
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   IPGlobalStatistics ^ ipstat = nullptr;
   switch ( version )
   {
      case NetworkInterfaceComponent::IPv4:
         ipstat = properties->GetIPv4GlobalStatistics();
         Console::WriteLine( "{0}IPv4 Statistics ", Environment::NewLine );
         break;

      case NetworkInterfaceComponent::IPv6:
         ipstat = properties->GetIPv4GlobalStatistics();
         Console::WriteLine( "{0}IPv6 Statistics ", Environment::NewLine );
         break;

      default:
         throw gcnew ArgumentException( "version" );
         break;
   }
   //</Snippet20>

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
   Console::WriteLine( "" );
   Console::WriteLine( "  Inbound Packet Data:" );
   Console::WriteLine( "      Received ............................ : {0}",
      ipstat->ReceivedPackets );
   Console::WriteLine( "      Forwarded ........................... : {0}",
      ipstat->ReceivedPacketsForwarded );
   Console::WriteLine( "      Delivered ........................... : {0}",
      ipstat->ReceivedPacketsDelivered );
   Console::WriteLine( "      Discarded ........................... : {0}",
      ipstat->ReceivedPacketsDiscarded );
   Console::WriteLine( "      Header Errors ....................... : {0}",
      ipstat->ReceivedPacketsWithHeadersErrors );
   Console::WriteLine( "      Address Errors ...................... : {0}",
      ipstat->ReceivedPacketsWithAddressErrors );
   Console::WriteLine( "      Unknown Protocol Errors ............. : {0}",
      ipstat->ReceivedPacketsWithUnknownProtocol );
   Console::WriteLine( "" );
   Console::WriteLine( "  Outbound Packet Data:" );
   Console::WriteLine( "      Requested ........................... : {0}",
      ipstat->OutputPacketRequests );
   Console::WriteLine( "      Discarded ........................... : {0}",
      ipstat->OutputPacketsDiscarded );
   Console::WriteLine( "      No Routing Discards ................. : {0}",
      ipstat->OutputPacketsWithNoRoute );
   Console::WriteLine( "      Routing Entry Discards .............. : {0}",
      ipstat->OutputPacketRoutingDiscards );
   Console::WriteLine( "" );
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
   Console::WriteLine( "" );
}
//</Snippet1>

//<Snippet2>
void ShowTcpStatistics( NetworkInterfaceComponent version )
{
   //<Snippet21>
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   TcpStatistics ^ tcpstat = nullptr;
   Console::WriteLine( "" );
   switch ( version )
   {
      case NetworkInterfaceComponent::IPv4:
         tcpstat = properties->GetTcpIPv4Statistics();
         Console::WriteLine( "TCP/IPv4 Statistics:" );
         break;

      case NetworkInterfaceComponent::IPv6:
         tcpstat = properties->GetTcpIPv6Statistics();
         Console::WriteLine( "TCP/IPv6 Statistics:" );
         break;

      default:
         throw gcnew ArgumentException( "version" );
         break;
   }
   //</Snippet21>
   Console::WriteLine( "  Minimum Transmission Timeout............. : {0}",
      tcpstat->MinimumTransmissionTimeout );
   Console::WriteLine( "  Maximum Transmission Timeout............. : {0}",
      tcpstat->MaximumTransmissionTimeout );
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
   Console::WriteLine( "" );
   Console::WriteLine( "  Segment Data:" );
   Console::WriteLine( "      Received  ........................... : {0}",
      tcpstat->SegmentsReceived );
   Console::WriteLine( "      Sent ................................ : {0}",
      tcpstat->SegmentsSent );
   Console::WriteLine( "      Retransmitted ....................... : {0}",
      tcpstat->SegmentsResent );
   Console::WriteLine( "" );
}
//</Snippet2>

//<Snippet3>
void ShowUdpStatistics( NetworkInterfaceComponent version )
{
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   UdpStatistics ^ udpStat = nullptr;
   switch ( version )
   {
      case NetworkInterfaceComponent::IPv4:
         udpStat = properties->GetUdpIPv4Statistics();
         Console::WriteLine( "UDP IPv4 Statistics" );
         break;

      case NetworkInterfaceComponent::IPv6:
         udpStat = properties->GetUdpIPv6Statistics();
         Console::WriteLine( "UDP IPv6 Statistics" );
         break;

      default:
         throw gcnew ArgumentException( "version" );
         break;
   }
   Console::WriteLine( "  Datagrams Received ...................... : {0}", udpStat->DatagramsReceived );
   Console::WriteLine( "  Datagrams Sent .......................... : {0}", udpStat->DatagramsSent );
   Console::WriteLine( "  Incoming Datagrams Discarded ............ : {0}", udpStat->IncomingDatagramsDiscarded );
   Console::WriteLine( "  Incoming Datagrams With Errors .......... : {0}", udpStat->IncomingDatagramsWithErrors );
   Console::WriteLine( "  UDP Listeners ........................... : {0}", udpStat->UdpListeners );
   Console::WriteLine( "" );
}
//</Snippet3>

//<Snippet4>
void ShowEchoIcmpv4( IcmpV4Statistics ^ stat4 )
{
   if ( stat4 != nullptr )
   {
      Console::WriteLine( "ICMP v4 Echo Requests ................. Sent: {0,-10}   Received: {1,-10}", stat4->EchoRequestsSent, stat4->EchoRequestsReceived );
      Console::WriteLine( "ICMP v4 Echo Replies .................. Sent: {0,-10}   Received: {1,-10}", stat4->EchoRepliesSent, stat4->EchoRepliesReceived );
   }
}

void ShowEchoIcmpv6( IcmpV6Statistics ^ stat6 )
{
   if ( stat6 != nullptr )
   {
      Console::WriteLine( "ICMP v6 Echo Requests.................. Sent: {0,-10}   Received: {1,-10}", stat6->EchoRequestsSent, stat6->EchoRequestsReceived );
      Console::WriteLine( "ICMP v6 Echo Replies .................. Sent: {0,-10}   Received: {1,-10}", stat6->EchoRepliesSent, stat6->EchoRepliesReceived );
   }
}

//</Snippet4>

//<Snippet5>
void ShowIcmpv4MessagesAndErrors( IcmpV4Statistics ^ stat4 )
{
   if ( stat4 != nullptr )
   {
      Console::WriteLine( "ICMP v4 Messages ...................... Sent: {0,-10}   Received: {1,-10}", stat4->MessagesSent, stat4->MessagesReceived );
      Console::WriteLine( "ICMP v6 Errors ........................ Sent: {0,-10}   Received: {1,-10}", stat4->ErrorsSent, stat4->ErrorsReceived );
   }

}

void ShowIcmpv6MessagesAndErrors( IcmpV6Statistics ^ stat6 )
{
   if ( stat6 != nullptr )
   {
      Console::WriteLine( "ICMP v6 Messages ...................... Sent: {0,-10}   Received: {1,-10}", stat6->MessagesSent, stat6->MessagesReceived );
      Console::WriteLine( "ICMP v6 Errors ........................ Sent: {0,-10}   Received: {1,-10}", stat6->ErrorsSent, stat6->ErrorsReceived );
   }
}
//</Snippet5>

//<Snippet6>
void ShowIcmpV4Statistics()
{
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   IcmpV4Statistics ^ stat = properties->GetIcmpV4Statistics();
   Console::WriteLine( "ICMP V4 Statistics:" );
   Console::WriteLine( "  Messages ............................ Sent: {0,-10}   Received: {1,-10}", stat->MessagesSent, stat->MessagesReceived );
   Console::WriteLine( "  Errors .............................. Sent: {0,-10}   Received: {1,-10}", stat->ErrorsSent, stat->ErrorsReceived );
   Console::WriteLine( "  Echo Requests ....................... Sent: {0,-10}   Received: {1,-10}", stat->EchoRequestsSent, stat->EchoRequestsReceived );
   Console::WriteLine( "  Echo Replies ........................ Sent: {0,-10}   Received: {1,-10}", stat->EchoRepliesSent, stat->EchoRepliesReceived );
   Console::WriteLine( "  Destination Unreachables ............ Sent: {0,-10}   Received: {1,-10}", stat->DestinationUnreachableMessagesSent, stat->DestinationUnreachableMessagesReceived );
   Console::WriteLine( "  Source Quenches ..................... Sent: {0,-10}   Received: {1,-10}", stat->SourceQuenchesSent, stat->SourceQuenchesReceived );
   Console::WriteLine( "  Redirects ........................... Sent: {0,-10}   Received: {1,-10}", stat->RedirectsSent, stat->RedirectsReceived );
   Console::WriteLine( "  TimeExceeded ........................ Sent: {0,-10}   Received: {1,-10}", stat->TimeExceededMessagesSent, stat->TimeExceededMessagesReceived );
   Console::WriteLine( "  Parameter Problems .................. Sent: {0,-10}   Received: {1,-10}", stat->ParameterProblemsSent, stat->ParameterProblemsReceived );
   Console::WriteLine( "  Timestamp Requests .................. Sent: {0,-10}   Received: {1,-10}", stat->TimestampRequestsSent, stat->TimestampRequestsReceived );
   Console::WriteLine( "  Timestamp Replies ................... Sent: {0,-10}   Received: {1,-10}", stat->TimestampRepliesSent, stat->TimestampRepliesReceived );
   Console::WriteLine( "  Address Mask Requests ............... Sent: {0,-10}   Received: {1,-10}", stat->AddressMaskRequestsSent, stat->AddressMaskRequestsReceived );
   Console::WriteLine( "  Address Mask Replies ................ Sent: {0,-10}   Received: {1,-10}", stat->AddressMaskRepliesSent, stat->AddressMaskRepliesReceived );
   Console::WriteLine( "" );
}
//</Snippet6>

//<Snippet7>
void ShowIcmpV6Statistics()
{
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   IcmpV6Statistics ^ stat = properties->GetIcmpV6Statistics();
   Console::WriteLine( "ICMP V6 Statistics:" );
   Console::WriteLine( "  Messages ............................ Sent: {0,-10}   Received: {1,-10}", stat->MessagesSent, stat->MessagesReceived );
   Console::WriteLine( "  Errors .............................. Sent: {0,-10}   Received: {1,-10}", stat->ErrorsSent, stat->ErrorsReceived );
   Console::WriteLine( "  Echo Requests ....................... Sent: {0,-10}   Received: {1,-10}", stat->EchoRequestsSent, stat->EchoRequestsReceived );
   Console::WriteLine( "  Echo Replies ........................ Sent: {0,-10}   Received: {1,-10}", stat->EchoRepliesSent, stat->EchoRepliesReceived );
   Console::WriteLine( "  Destination Unreachables ............ Sent: {0,-10}   Received: {1,-10}", stat->DestinationUnreachableMessagesSent, stat->DestinationUnreachableMessagesReceived );
   Console::WriteLine( "  Parameter Problems .................. Sent: {0,-10}   Received: {1,-10}", stat->ParameterProblemsSent, stat->ParameterProblemsReceived );
   Console::WriteLine( "  Packets Too Big ..................... Sent: {0,-10}   Received: {1,-10}", stat->PacketTooBigMessagesSent, stat->PacketTooBigMessagesReceived );
   Console::WriteLine( "  Redirects ........................... Sent: {0,-10}   Received: {1,-10}", stat->RedirectsSent, stat->RedirectsReceived );
   Console::WriteLine( "  Router Advertisements ............... Sent: {0,-10}   Received: {1,-10}", stat->RouterAdvertisementsSent, stat->RouterAdvertisementsReceived );
   Console::WriteLine( "  Router Solicitations ................ Sent: {0,-10}   Received: {1,-10}", stat->RouterSolicitsSent, stat->RouterSolicitsReceived );
   Console::WriteLine( "  Time Exceeded ....................... Sent: {0,-10}   Received: {1,-10}", stat->TimeExceededMessagesSent, stat->TimeExceededMessagesReceived );
   Console::WriteLine( "  Neighbor Advertisements ............. Sent: {0,-10}   Received: {1,-10}", stat->NeighborAdvertisementsSent, stat->NeighborAdvertisementsReceived );
   Console::WriteLine( "  Neighbor Solicitations .............. Sent: {0,-10}   Received: {1,-10}", stat->NeighborSolicitsSent, stat->NeighborSolicitsReceived );
   Console::WriteLine( "  Membership Queries .................. Sent: {0,-10}   Received: {1,-10}", stat->MembershipQueriesSent, stat->MembershipQueriesReceived );
   Console::WriteLine( "  Membership Reports .................. Sent: {0,-10}   Received: {1,-10}", stat->MembershipReportsSent, stat->MembershipReportsReceived );
   Console::WriteLine( "  Membership Reductions ............... Sent: {0,-10}   Received: {1,-10}", stat->MembershipReductionsSent, stat->MembershipReductionsReceived );
   Console::WriteLine( "" );
}
//</Snippet7>

//<Snippet14>
void ShowIPAddresses( String^ label, IPAddressCollection^ addresses )
{
   if ( addresses->Count == 0 )
      return;

//   Console::WriteLine( "{0} {1} ", label, addresses->Item[ 0 ] );
   if ( addresses->Count > 1 )
   {
      for ( int i = 1; i < addresses->Count; i++ )
      {
          String^ address = addresses->ToString();
          String^ line = address->PadLeft( label->Length + address->Length + 1 );
          Console::WriteLine( "{0}", line );

      }
   }
}
//</Snippet14>

//<snippet8>
void ShowIPAddresses( IPInterfaceProperties ^ adapterProperties )
{
   //<Snippet9>
   IPAddressCollection ^ dnsServers = adapterProperties->DnsAddresses;
   if ( dnsServers != nullptr )
   {
      System::Collections::IEnumerator^ myEnum = dnsServers->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         IPAddressInformation ^ dns = safe_cast<IPAddressInformation ^>(myEnum->Current);
         Console::WriteLine( "  DNS Servers ............................. : {0} ({1} {2})",
            dns->Address, dns->IsTransient ? (String^)"Transient" : "", dns->IsDnsEligible ? (String^)"DNS Eligible" : "" );
      }
   }
   //</Snippet9>

   IPAddressInformationCollection ^ anyCast = adapterProperties->AnycastAddresses;
   if ( anyCast != nullptr )
   {
      System::Collections::IEnumerator^ myEnum1 = anyCast->GetEnumerator();
      while ( myEnum1->MoveNext() )
      {
         IPAddressInformation ^ any = safe_cast<IPAddressInformation ^>(myEnum1->Current);
         Console::WriteLine( "  Anycast Address .......................... : {0} {1} {2}", any->Address, any->IsTransient ? (String^)"Transient" : "", any->IsDnsEligible ? (String^)"DNS Eligible" : "" );
      }

      Console::WriteLine();
   }

   MulticastIPAddressInformationCollection ^ multiCast = adapterProperties->MulticastAddresses;
   if ( multiCast != nullptr )
   {
      System::Collections::IEnumerator^ myEnum2 = multiCast->GetEnumerator();
      while ( myEnum2->MoveNext() )
      {
         IPAddressInformation ^ multi = safe_cast<IPAddressInformation ^>(myEnum2->Current);
         Console::WriteLine( "  Multicast Address ....................... : {0} {1} {2}", multi->Address, multi->IsTransient ? (String^)"Transient" : "", multi->IsDnsEligible ? (String^)"DNS Eligible" : "" );
      }

      Console::WriteLine();
   }

   //<Snippet10>
   UnicastIPAddressInformationCollection ^ uniCast = adapterProperties->UnicastAddresses;
   if ( uniCast != nullptr )
   {
      String^ lifeTimeFormat = "dddd, MMMM dd, yyyy  hh:mm:ss tt";
      System::Collections::IEnumerator^ myEnum3 = uniCast->GetEnumerator();
      while ( myEnum3->MoveNext() )
      {
         UnicastIPAddressInformation ^ uni = safe_cast<UnicastIPAddressInformation ^>(myEnum3->Current);
         DateTime when;
         Console::WriteLine( "  Unicast Address ......................... : {0}", uni->Address );
         Console::WriteLine( "     Prefix Origin ........................ : {0}", uni->PrefixOrigin );
         Console::WriteLine( "     Suffix Origin ........................ : {0}", uni->SuffixOrigin );
         Console::WriteLine( "     Duplicate Address Detection .......... : {0}", uni->DuplicateAddressDetectionState );

         // Format the lifetimes as Sunday, February 16, 2003 11:33:44 PM
         // if en-us is the current culture.
         // Calculate the date and time at the end of the lifetimes.
         when = DateTime::UtcNow + TimeSpan::FromSeconds( (double)uni->AddressValidLifetime );
         when = when.ToLocalTime();
         Console::WriteLine( "     Valid Life Time ...................... : {0}", when.ToString( lifeTimeFormat, System::Globalization::CultureInfo::CurrentCulture ) );
         when = DateTime::UtcNow + TimeSpan::FromSeconds( (double)uni->AddressPreferredLifetime );
         when = when.ToLocalTime();
         Console::WriteLine( "     Preferred life time .................. : {0}", when.ToString( lifeTimeFormat, System::Globalization::CultureInfo::CurrentCulture ) );
         when = DateTime::UtcNow + TimeSpan::FromSeconds( (double)uni->DhcpLeaseLifetime );
         when = when.ToLocalTime();
         Console::WriteLine( "     DHCP Leased Life Time ................ : {0}", when.ToString( lifeTimeFormat, System::Globalization::CultureInfo::CurrentCulture ) );
      }

      Console::WriteLine();
   }
   //</Snippet10>
}
//</snippet8>

//<Snippet11>
void ShowInterfaceStatistics( NetworkInterface ^ adapter )
{
   IPv4InterfaceStatistics ^ stats = adapter->GetIPv4Statistics();
   Console::WriteLine( "{0}  Interface Statistics:", Environment::NewLine );
   Console::WriteLine( "     Bytes sent ........................... : {0}",
      stats->BytesSent );
   Console::WriteLine( "     Bytes received ....................... : {0}",
      stats->BytesReceived );
   Console::WriteLine( "     Unicast Packets Sent ................. : {0}",
      stats->UnicastPacketsSent );
   Console::WriteLine( "     Unicast Packets Received ............. : {0}",
      stats->UnicastPacketsReceived );
   Console::WriteLine( "     Non Unicast Packets Sent ............. : {0}",
      stats->NonUnicastPacketsSent );
   Console::WriteLine( "     Non Unicast Packets Received ......... : {0}",
      stats->NonUnicastPacketsReceived );
   Console::WriteLine( "     Incoming Packets Discarded ........... : {0}",
      stats->IncomingPacketsDiscarded );
   Console::WriteLine( "     Outgoing Packets Discarded ........... : {0}",
      stats->OutgoingPacketsDiscarded );
   Console::WriteLine( "     Incoming Packets Errors .............. : {0}",
      stats->IncomingPacketsWithErrors );
   Console::WriteLine( "     Outgoing packets Errors .............. : {0}",
      stats->OutgoingPacketsWithErrors );
   Console::WriteLine( "     Incoming Unknown Protocol Errors ..... : {0}",
      stats->IncomingUnknownProtocolPackets );
   Console::WriteLine( "     Speed ................................ : {0}",
      adapter->Speed );
   Console::WriteLine( "     Output queue length................... : {0}",
      stats->OutputQueueLength );
   Console::WriteLine();
}
//</Snippet11>

//<Snippet12>
void ShowNetworkInterfaces()
{
   IPGlobalProperties ^ computerProperties = IPGlobalProperties::GetIPGlobalProperties();
   array<NetworkInterface^>^nics = NetworkInterface::GetAllNetworkInterfaces();
   Console::WriteLine( "Interface information for {0}.{1}     ", computerProperties->HostName, computerProperties->DomainName );
   if ( nics == nullptr || nics->Length < 1 )
   {
      Console::WriteLine( "  No network interfaces found." );
      return;
   }

   Console::WriteLine( "  Number of interfaces .................... : {0}", nics->Length );
   System::Collections::IEnumerator^ myEnum4 = nics->GetEnumerator();
   while ( myEnum4->MoveNext() )
   {
      NetworkInterface ^ adapter = safe_cast<NetworkInterface ^>(myEnum4->Current);
      IPInterfaceProperties ^ properties = adapter->GetIPProperties();
      Console::WriteLine();
      Console::WriteLine( adapter->Description );
      Console::WriteLine( String::Empty->PadLeft( adapter->Description->Length, '=' ) );
      Console::WriteLine( "  Interface type .......................... : {0}",
         adapter->NetworkInterfaceType );
      Console::WriteLine( "  Physical Address ........................ : {0}",
         adapter->GetPhysicalAddress() );
      Console::WriteLine( "  Operational status ...................... : {0}",
         adapter->OperationalStatus );
      String^ versions = "";

      // Create a display string for the supported IP versions.
      if ( adapter->Supports( NetworkInterfaceComponent::IPv4 ) )
      {
         versions = "IPv4";
      }
      if ( adapter->Supports( NetworkInterfaceComponent::IPv6 ) )
      {
         if ( versions->Length > 0 )
         {
            versions = String::Concat( versions, " " );
         }
         versions = String::Concat( versions, "IPv6" );
      }
      Console::WriteLine( "  IP version .............................. : {0}",
         versions );
      ShowIPAddresses( properties );

      // The following information is not useful for loopback adapters.
      if ( adapter->NetworkInterfaceType == NetworkInterfaceType::Loopback )
      {
         continue;
      }
      Console::WriteLine( "  DNS suffix .............................. : {0}",
         properties->DnsSuffix );
      String^ label;

      //<Snippet13>
      if ( adapter->Supports( NetworkInterfaceComponent::IPv4 ) )
      {
         IPv4InterfaceProperties ^ ipv4 = properties->GetIPv4Properties();
         Console::WriteLine( "  MTU...................................... : {0}",
            ipv4->Mtu );
         if ( ipv4->UsesWins )
         {
            IPAddressCollection ^ winsServers = properties->WinsServersAddresses;
            if ( winsServers->Count > 0 )
            {
               label = "  WINS Servers ............................ :";
               ShowIPAddresses( label, winsServers );
            }
         }
      }
      //</Snippet13>
      Console::WriteLine( "  DNS enabled ............................. : {0}",
         properties->IsDnsEnabled );
      Console::WriteLine( "  Dynamically configured DNS .............. : {0}",
         properties->IsDynamicDnsEnabled );
      Console::WriteLine( "  Receive Only ............................ : {0}",
         adapter->IsReceiveOnly );
      Console::WriteLine( "  Multicast ............................... : {0}",
         adapter->SupportsMulticast );
      ShowInterfaceStatistics( adapter );
      Console::WriteLine();
   }
}
//</Snippet12>


//<Snippet16>
void ShowInterfaceSummary()
{
   array<NetworkInterface^>^interfaces = NetworkInterface::GetAllNetworkInterfaces();
   System::Collections::IEnumerator^ myEnum5 = interfaces->GetEnumerator();
   while ( myEnum5->MoveNext() )
   {
      NetworkInterface ^ adapter = safe_cast<NetworkInterface ^>(myEnum5->Current);
      Console::WriteLine( "Name: {0}", adapter->Name );
      Console::WriteLine( adapter->Description );
      Console::WriteLine( String::Empty->PadLeft( adapter->Description->Length, '=' ) );
      Console::WriteLine( "  Interface type .......................... : {0}",
         adapter->NetworkInterfaceType );
      Console::WriteLine( "  Operational status ...................... : {0}", adapter->OperationalStatus );
      String^ versions = "";

      // Create a display string for the supported IP versions.
      if ( adapter->Supports( NetworkInterfaceComponent::IPv4 ) )
      {
         versions = "IPv4";
      }

      if ( adapter->Supports( NetworkInterfaceComponent::IPv6 ) )
      {
         if ( versions->Length > 0 )
         {
            versions = String::Concat( versions, " " );
         }

         versions = String::Concat( versions, "IPv6" );
      }

      Console::WriteLine( "  IP version .............................. : {0}", versions );
      Console::WriteLine();
   }

   Console::WriteLine();
}
//</Snippet16>

//<Snippet17>
void ShowActiveTcpConnections()
{
   Console::WriteLine( "Active TCP Connections" );
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   array<TcpConnectionInformation^>^connections = properties->GetActiveTcpConnections();
   System::Collections::IEnumerator^ myEnum6 = connections->GetEnumerator();
   while ( myEnum6->MoveNext() )
   {
      TcpConnectionInformation ^ c = safe_cast<TcpConnectionInformation ^>(myEnum6->Current);
      Console::WriteLine( "{0} <==> {1}", c->LocalEndPoint, c->RemoteEndPoint );
   }
}
//</Snippet17>

//<Snippet18>
void ShowActiveTcpListeners()
{
   Console::WriteLine( "Active TCP Listeners" );
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   array<IPEndPoint^>^endPoints = properties->GetActiveTcpListeners();
   System::Collections::IEnumerator^ myEnum7 = endPoints->GetEnumerator();
   while ( myEnum7->MoveNext() )
   {
      IPEndPoint^ e = safe_cast<IPEndPoint^>(myEnum7->Current);
      Console::WriteLine( e );
   }
}
//</Snippet18>

//<Snippet19>
void ShowActiveUdpListeners()
{
   Console::WriteLine( "Active UDP Listeners" );
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   array<IPEndPoint^>^endPoints = properties->GetActiveUdpListeners();
   System::Collections::IEnumerator^ myEnum8 = endPoints->GetEnumerator();
   while ( myEnum8->MoveNext() )
   {
      IPEndPoint^ e = safe_cast<IPEndPoint^>(myEnum8->Current);
      Console::WriteLine( e );
   }
}
//</Snippet19>

int main()
{
   //<Snippet15>
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   Console::WriteLine( "Computer name: {0}", properties->HostName );
   Console::WriteLine( "Domain name:   {0}", properties->DomainName );
   Console::WriteLine( "Node type:     {0:f}", properties->NodeType );
   Console::WriteLine( "DHCP scope:    {0}", properties->DhcpScopeName );
   Console::WriteLine( "WINS proxy?    {0}", properties->IsWinsProxy );
   //</Snippet15>

   ShowActiveTcpConnections();
   ShowActiveTcpListeners();
   ShowActiveUdpListeners();
   if (Socket::SupportsIPv4)
   {
      ShowIcmpV4Statistics();
   }
   if (Socket::OSSupportsIPv6)
   {
      ShowIcmpV6Statistics();
   }
   ShowIPStatistics( NetworkInterfaceComponent::IPv4 );
   ShowTcpStatistics( NetworkInterfaceComponent::IPv4 );
   ShowUdpStatistics( NetworkInterfaceComponent::IPv4 );
   ShowEchoIcmpv4(properties->GetIcmpV4Statistics());
   ShowIcmpv4MessagesAndErrors(properties->GetIcmpV4Statistics());

   if (Socket::OSSupportsIPv6)
   {
      ShowEchoIcmpv6(properties->GetIcmpV6Statistics());
      ShowIcmpv6MessagesAndErrors(properties->GetIcmpV6Statistics());
   }

   ShowNetworkInterfaces();
   ShowInterfaceSummary();
}
