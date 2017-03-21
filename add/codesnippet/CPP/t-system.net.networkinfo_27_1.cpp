void ShowNetworkInterfaces()
{
   IPGlobalProperties^ computerProperties = IPGlobalProperties::GetIPGlobalProperties();
   array<NetworkInterface^>^nics = NetworkInterface::GetAllNetworkInterfaces();
   Console::WriteLine( L"Interface information for {0}.{1}     ", computerProperties->HostName, computerProperties->DomainName );
   if ( nics == nullptr || nics->Length < 1 )
   {
      Console::WriteLine( L"  No network interfaces found." );
      return;
   }

   Console::WriteLine( L"  Number of interfaces .................... : {0}", (nics->Length).ToString() );
   IEnumerator^ myEnum1 = nics->GetEnumerator();
   while ( myEnum1->MoveNext() )
   {
      NetworkInterface^ adapter = safe_cast<NetworkInterface^>(myEnum1->Current);
      IPInterfaceProperties^ properties = adapter->GetIPProperties();
      Console::WriteLine();
      Console::WriteLine( adapter->Description );
      Console::WriteLine( String::Empty->PadLeft( adapter->Description->Length, '=' ) );
      Console::WriteLine( L"  Interface type .......................... : {0}", adapter->NetworkInterfaceType );
      Console::Write( L"  Physical address ........................ : " );
      PhysicalAddress^ address = adapter->GetPhysicalAddress();
      array<Byte>^bytes = address->GetAddressBytes();
      for ( int i = 0; i < bytes->Length; i++ )
      {
         
         // Display the physical address in hexadecimal.
         Console::Write( L"{0}", bytes[ i ].ToString( L"X2" ) );
         
         // Insert a hyphen after each byte, unless we are at the end of the 
         // address.
         if ( i != bytes->Length - 1 )
         {
            Console::Write( L"-" );
         }

      }
      Console::WriteLine();
   }
}

