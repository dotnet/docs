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