void ShowIcmpV6ErrorData()
{
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   IcmpV6Statistics ^ statistics = properties->GetIcmpV6Statistics();
   Console::WriteLine( "  Errors .............................. Sent: {0,-10}   Received: {1,-10}", 
      statistics->ErrorsSent, statistics->ErrorsReceived );
}