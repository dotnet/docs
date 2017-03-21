void ShowIcmpV6RedirectsData()
{
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   IcmpV6Statistics ^ statistics = properties->GetIcmpV6Statistics();
   Console::WriteLine( "  Redirects ........................... Sent: {0,-10}   Received: {1,-10}", 
      statistics->RedirectsSent, 
      statistics->RedirectsReceived );
}