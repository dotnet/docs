void DisplayUnicastAddresses()
{
   Console::WriteLine( "Unicast Addresses" );
   array<NetworkInterface^>^adapters = NetworkInterface::GetAllNetworkInterfaces();
   System::Collections::IEnumerator^ myEnum17 = adapters->GetEnumerator();
   while ( myEnum17->MoveNext() )
   {
      NetworkInterface ^ adapter = safe_cast<NetworkInterface ^>(myEnum17->Current);
      IPInterfaceProperties ^ adapterProperties = adapter->GetIPProperties();
      UnicastIPAddressInformationCollection ^ uniCast = adapterProperties->UnicastAddresses;
      if ( uniCast->Count > 0 )
      {
         Console::WriteLine( adapter->Description );
         String^ lifeTimeFormat = "dddd, MMMM dd, yyyy  hh:mm:ss tt";
         System::Collections::IEnumerator^ myEnum18 = uniCast->GetEnumerator();
         while ( myEnum18->MoveNext() )
         {
            UnicastIPAddressInformation ^ uni = safe_cast<UnicastIPAddressInformation ^>(myEnum18->Current);
            DateTime when;
            Console::WriteLine( "  Unicast Address ......................... : {0}", 
               uni->Address );
            Console::WriteLine( "     Prefix Origin ........................ : {0}", 
               uni->PrefixOrigin );
            Console::WriteLine( "     Suffix Origin ........................ : {0}", 
               uni->SuffixOrigin );
            Console::WriteLine( "     Duplicate Address Detection .......... : {0}", 
               uni->DuplicateAddressDetectionState );
            
            // Format the lifetimes as Sunday, February 16, 2003 11:33:44 PM
            // if en-us is the current culture.
            // Calculate the date and time at the end of the lifetimes.    
            when = DateTime::UtcNow + TimeSpan::FromSeconds( (double)uni->AddressValidLifetime );
            when = when.ToLocalTime();
            Console::WriteLine( "     Valid Life Time ...................... : {0}", 
               when.ToString( lifeTimeFormat, System::Globalization::CultureInfo::CurrentCulture ) );
            when = DateTime::UtcNow + TimeSpan::FromSeconds( (double)uni->AddressPreferredLifetime );
            when = when.ToLocalTime();
            Console::WriteLine( "     Preferred life time .................. : {0}", 
               when.ToString( lifeTimeFormat, System::Globalization::CultureInfo::CurrentCulture ) );
            when = DateTime::UtcNow + TimeSpan::FromSeconds( (double)uni->DhcpLeaseLifetime );
            when = when.ToLocalTime();
            Console::WriteLine( "     DHCP Leased Life Time ................ : {0}", 
               when.ToString( lifeTimeFormat, System::Globalization::CultureInfo::CurrentCulture ) );
         }
         Console::WriteLine();
      }
   }
}