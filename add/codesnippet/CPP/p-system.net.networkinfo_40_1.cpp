void ShowIcmpV6RouterData()
{
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   IcmpV6Statistics ^ statistics = properties->GetIcmpV6Statistics();
   Console::WriteLine( "  Advertisements ....................... Sent: {0,-10}   Received: {1,-10}", 
      statistics->RouterAdvertisementsSent, 
      statistics->RouterAdvertisementsReceived );
   Console::WriteLine( "  Solicits ............................. Sent: {0,-10}   Received: {1,-10}", 
      statistics->RouterSolicitsSent, 
      statistics->RouterSolicitsReceived );
}