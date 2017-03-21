void ShowIcmpV6NeighborData()
{
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   IcmpV6Statistics ^ statistics = properties->GetIcmpV6Statistics();
   Console::WriteLine( "  Advertisements ...................... Sent: {0,-10}   Received: {1,-10}", 
      statistics->NeighborAdvertisementsSent, statistics->NeighborAdvertisementsReceived );
   Console::WriteLine( "  Solicits ............................ Sent: {0,-10}   Received: {1,-10}", 
      statistics->NeighborSolicitsSent, statistics->NeighborSolicitsReceived );
}