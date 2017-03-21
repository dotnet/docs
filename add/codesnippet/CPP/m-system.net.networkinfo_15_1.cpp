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