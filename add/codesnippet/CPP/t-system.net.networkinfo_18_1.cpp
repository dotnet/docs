void DisplayIPv4NetworkInterfaces()
{
   array<NetworkInterface^>^nics = NetworkInterface::GetAllNetworkInterfaces();
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   Console::WriteLine( "IPv4 interface information for {0}.{1}", properties->HostName, properties->DomainName );
   System::Collections::IEnumerator^ myEnum23 = nics->GetEnumerator();
   while ( myEnum23->MoveNext() )
   {
      NetworkInterface ^ adapter = safe_cast<NetworkInterface ^>(myEnum23->Current);

      // Only display informatin for interfaces that support IPv4.
      if ( adapter->Supports( NetworkInterfaceComponent::IPv4 ) == false )
      {
         continue;
      }
      Console::WriteLine();
      Console::WriteLine( adapter->Description );

      // Underline the description.
      Console::WriteLine( String::Empty->PadLeft( adapter->Description->Length, '=' ) );
      IPInterfaceProperties ^ adapterProperties = adapter->GetIPProperties();

      // Try to get the IPv4 interface properties.
      IPv4InterfaceProperties ^ p = adapterProperties->GetIPv4Properties();
      if ( !p )
      {
         Console::WriteLine( "No IPv4 information is available for this interface." );
         continue;
      }

      // Display the IPv4 specific data.
      Console::WriteLine( "  Index ............................. : {0}", 
         p->Index );
      Console::WriteLine( "  MTU ............................... : {0}", 
         p->Mtu );
      Console::WriteLine( "  APIPA active....................... : {0}", 
         p->IsAutomaticPrivateAddressingActive );
      Console::WriteLine( "  APIPA enabled...................... : {0}", 
         p->IsAutomaticPrivateAddressingEnabled );
      Console::WriteLine( "  Forwarding enabled................. : {0}", 
         p->IsForwardingEnabled );
      Console::WriteLine( "  Uses WINS ......................... : {0}", 
         p->UsesWins );
   }
}