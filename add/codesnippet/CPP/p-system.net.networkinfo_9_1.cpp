void DisplayDhcpServerAddresses()
{
   Console::WriteLine( "DHCP Servers" );
   array<NetworkInterface^>^adapters = NetworkInterface::GetAllNetworkInterfaces();
   System::Collections::IEnumerator^ myEnum19 = adapters->GetEnumerator();
   while ( myEnum19->MoveNext() )
   {
      NetworkInterface ^ adapter = safe_cast<NetworkInterface ^>(myEnum19->Current);
      IPInterfaceProperties ^ adapterProperties = adapter->GetIPProperties();
      IPAddressCollection ^ addresses = adapterProperties->DhcpServerAddresses;
      if ( addresses->Count > 0 )
      {
         Console::WriteLine( adapter->Description );
         System::Collections::IEnumerator^ myEnum20 = addresses->GetEnumerator();
         while ( myEnum20->MoveNext() )
         {
            IPAddress^ address = safe_cast<IPAddress^>(myEnum20->Current);
            Console::WriteLine( "  Dhcp Address ............................ : {0}", 
               address );
         }
         Console::WriteLine();
      }
   }
}