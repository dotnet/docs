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