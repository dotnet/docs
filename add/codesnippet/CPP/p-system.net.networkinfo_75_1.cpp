void ShowSourceQuenchData()
{
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   IcmpV4Statistics ^ statistics = properties->GetIcmpV4Statistics();
   Console::WriteLine( "  Source Quenches ..................... Sent: {0,-10}   Received: {1,-10}", 
      statistics->SourceQuenchesSent, 
      statistics->SourceQuenchesReceived );
}