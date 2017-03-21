void ShowIPAddresses( IPInterfaceProperties ^ adapterProperties )
{
   IPAddressCollection ^ dnsServers = adapterProperties->DnsAddresses;
   if ( dnsServers != nullptr )
   {
      System::Collections::IEnumerator^ myEnum = dnsServers->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         IPAddressInformation ^ dns = safe_cast<IPAddressInformation ^>(myEnum->Current);
         Console::WriteLine( "  DNS Servers ............................. : {0} ({1} {2})",
            dns->Address, dns->IsTransient ? (String^)"Transient" : "", dns->IsDnsEligible ? (String^)"DNS Eligible" : "" );
      }
   }

   IPAddressInformationCollection ^ anyCast = adapterProperties->AnycastAddresses;
   if ( anyCast != nullptr )
   {
      System::Collections::IEnumerator^ myEnum1 = anyCast->GetEnumerator();
      while ( myEnum1->MoveNext() )
      {
         IPAddressInformation ^ any = safe_cast<IPAddressInformation ^>(myEnum1->Current);
         Console::WriteLine( "  Anycast Address .......................... : {0} {1} {2}", any->Address, any->IsTransient ? (String^)"Transient" : "", any->IsDnsEligible ? (String^)"DNS Eligible" : "" );
      }

      Console::WriteLine();
   }

   MulticastIPAddressInformationCollection ^ multiCast = adapterProperties->MulticastAddresses;
   if ( multiCast != nullptr )
   {
      System::Collections::IEnumerator^ myEnum2 = multiCast->GetEnumerator();
      while ( myEnum2->MoveNext() )
      {
         IPAddressInformation ^ multi = safe_cast<IPAddressInformation ^>(myEnum2->Current);
         Console::WriteLine( "  Multicast Address ....................... : {0} {1} {2}", multi->Address, multi->IsTransient ? (String^)"Transient" : "", multi->IsDnsEligible ? (String^)"DNS Eligible" : "" );
      }

      Console::WriteLine();
   }

   UnicastIPAddressInformationCollection ^ uniCast = adapterProperties->UnicastAddresses;
   if ( uniCast != nullptr )
   {
      String^ lifeTimeFormat = "dddd, MMMM dd, yyyy  hh:mm:ss tt";
      System::Collections::IEnumerator^ myEnum3 = uniCast->GetEnumerator();
      while ( myEnum3->MoveNext() )
      {
         UnicastIPAddressInformation ^ uni = safe_cast<UnicastIPAddressInformation ^>(myEnum3->Current);
         DateTime when;
         Console::WriteLine( "  Unicast Address ......................... : {0}", uni->Address );
         Console::WriteLine( "     Prefix Origin ........................ : {0}", uni->PrefixOrigin );
         Console::WriteLine( "     Suffix Origin ........................ : {0}", uni->SuffixOrigin );
         Console::WriteLine( "     Duplicate Address Detection .......... : {0}", uni->DuplicateAddressDetectionState );

         // Format the lifetimes as Sunday, February 16, 2003 11:33:44 PM
         // if en-us is the current culture.
         // Calculate the date and time at the end of the lifetimes.
         when = DateTime::UtcNow + TimeSpan::FromSeconds( (double)uni->AddressValidLifetime );
         when = when.ToLocalTime();
         Console::WriteLine( "     Valid Life Time ...................... : {0}", when.ToString( lifeTimeFormat, System::Globalization::CultureInfo::CurrentCulture ) );
         when = DateTime::UtcNow + TimeSpan::FromSeconds( (double)uni->AddressPreferredLifetime );
         when = when.ToLocalTime();
         Console::WriteLine( "     Preferred life time .................. : {0}", when.ToString( lifeTimeFormat, System::Globalization::CultureInfo::CurrentCulture ) );
         when = DateTime::UtcNow + TimeSpan::FromSeconds( (double)uni->DhcpLeaseLifetime );
         when = when.ToLocalTime();
         Console::WriteLine( "     DHCP Leased Life Time ................ : {0}", when.ToString( lifeTimeFormat, System::Globalization::CultureInfo::CurrentCulture ) );
      }

      Console::WriteLine();
   }
}