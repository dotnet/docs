void DisplayMulticastAddresses()
{
   int count = 0;
   
   Console::WriteLine( "Multicast Addresses" );
   array<NetworkInterface^>^adapters = NetworkInterface::GetAllNetworkInterfaces();
   System::Collections::IEnumerator^ myEnum15 = adapters->GetEnumerator();
   while ( myEnum15->MoveNext() )
   {
      NetworkInterface ^ adapter = safe_cast<NetworkInterface ^>(myEnum15->Current);
      IPInterfaceProperties ^ adapterProperties = adapter->GetIPProperties();
      MulticastIPAddressInformationCollection ^ multiCast = adapterProperties->MulticastAddresses;
      if ( multiCast->Count > 0 )
      {
         Console::WriteLine( adapter->Description );
         System::Collections::IEnumerator^ myEnum16 = multiCast->GetEnumerator();
         while ( myEnum16->MoveNext() )
         {
            MulticastIPAddressInformation ^ multi = safe_cast<MulticastIPAddressInformation ^>(myEnum16->Current);
            Console::WriteLine( "  Multicast Address ....................... : {0} {1} {2}", 
               multi->Address, multi->IsTransient ? "Transient" : "", 
               multi->IsDnsEligible ? "DNS Eligible" : "" );
            count++;   
         }
         Console::WriteLine();
      }
   }
    if (count == 0)
    {
        Console::WriteLine("  No multicast addresses were found.");
        Console::WriteLine();
    }
}