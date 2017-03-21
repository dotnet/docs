void ShowInterfaceSummary()
{
   array<NetworkInterface^>^interfaces = NetworkInterface::GetAllNetworkInterfaces();
   System::Collections::IEnumerator^ myEnum5 = interfaces->GetEnumerator();
   while ( myEnum5->MoveNext() )
   {
      NetworkInterface ^ adapter = safe_cast<NetworkInterface ^>(myEnum5->Current);
      Console::WriteLine( "Name: {0}", adapter->Name );
      Console::WriteLine( adapter->Description );
      Console::WriteLine( String::Empty->PadLeft( adapter->Description->Length, '=' ) );
      Console::WriteLine( "  Interface type .......................... : {0}",
         adapter->NetworkInterfaceType );
      Console::WriteLine( "  Operational status ...................... : {0}", adapter->OperationalStatus );
      String^ versions = "";

      // Create a display string for the supported IP versions.
      if ( adapter->Supports( NetworkInterfaceComponent::IPv4 ) )
      {
         versions = "IPv4";
      }

      if ( adapter->Supports( NetworkInterfaceComponent::IPv6 ) )
      {
         if ( versions->Length > 0 )
         {
            versions = String::Concat( versions, " " );
         }

         versions = String::Concat( versions, "IPv6" );
      }

      Console::WriteLine( "  IP version .............................. : {0}", versions );
      Console::WriteLine();
   }

   Console::WriteLine();
}