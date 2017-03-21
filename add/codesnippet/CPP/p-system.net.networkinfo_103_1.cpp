void ShowIcmpV4MessageData()
{
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   IcmpV4Statistics ^ statistics = properties->GetIcmpV4Statistics();
   Console::WriteLine( "  Messages ............................ Sent: {0,-10}   Received: {1,-10}", 
      statistics->MessagesSent, statistics->MessagesReceived );
}