void ShowIcmpV6MessageData()
{
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   IcmpV6Statistics ^ statistics = properties->GetIcmpV6Statistics();
   Console::WriteLine( "  Messages ............................ Sent: {0,-10}   Received: {1,-10}", 
      statistics->MessagesSent, statistics->MessagesReceived );
}