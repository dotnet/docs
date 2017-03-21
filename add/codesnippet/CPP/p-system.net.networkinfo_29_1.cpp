void ShowIcmpV6ParameterData()
{
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   IcmpV6Statistics ^ statistics = properties->GetIcmpV6Statistics();
   Console::WriteLine( "  Parameter Problems .................. Sent: {0,-10}   Received: {1,-10}", 
      statistics->ParameterProblemsSent, 
      statistics->ParameterProblemsReceived );
}