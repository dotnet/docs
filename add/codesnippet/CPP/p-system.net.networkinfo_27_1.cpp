void ShowIcmpV4ErrorData()
{
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   IcmpV4Statistics ^ statistics = properties->GetIcmpV4Statistics();
   Console::WriteLine( "  Errors .............................. Sent: {0,-10}   Received: {1,-10}", 
      statistics->ErrorsSent, 
      statistics->ErrorsReceived );
}