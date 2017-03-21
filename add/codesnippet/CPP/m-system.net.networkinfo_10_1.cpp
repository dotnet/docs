void ShowTcpStatistics( NetworkInterfaceComponent version )
{
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