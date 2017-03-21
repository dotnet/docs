void ShowIcmpV6TimeExceededData()
{
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   IcmpV6Statistics ^ statistics = properties->GetIcmpV6Statistics();
   Console::WriteLine( "  TimeExceeded ........................ Sent: {0,-10}   Received: {1,-10}", 
      statistics->TimeExceededMessagesSent, 
      statistics->TimeExceededMessagesReceived );
}