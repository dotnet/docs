void DisplayAnycastAddresses()
{
    int count = 0;
            
    Console::WriteLine( "Anycast Addresses" );
    array<NetworkInterface^>^adapters = NetworkInterface::GetAllNetworkInterfaces();
    System::Collections::IEnumerator^ myEnum13 = adapters->GetEnumerator();
    while ( myEnum13->MoveNext() )
    {
        NetworkInterface ^ adapter = safe_cast<NetworkInterface ^>(myEnum13->Current);
        IPInterfaceProperties ^ adapterProperties = adapter->GetIPProperties();
        IPAddressInformationCollection ^ anyCast = adapterProperties->AnycastAddresses;
        if ( anyCast->Count > 0 )
        {
            Console::WriteLine( adapter->Description );
            System::Collections::IEnumerator^ myEnum14 = anyCast->GetEnumerator();
            while ( myEnum14->MoveNext() )
            {
                IPAddressInformation ^ any = safe_cast<IPAddressInformation ^>(myEnum14->Current);
                Console::WriteLine( "  Anycast Address .......................... : {0} {1} {2}", 
                    any->Address, any->IsTransient ? "Transient" : "", 
                    any->IsDnsEligible ? "DNS Eligible" : "" );
                count++;
            } 
            Console::WriteLine();
        }
    }
    if (count == 0)
    {
        Console::WriteLine("  No anycast addresses were found.");
        Console::WriteLine();
    }
}