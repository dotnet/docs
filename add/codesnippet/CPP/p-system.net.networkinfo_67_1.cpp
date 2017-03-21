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