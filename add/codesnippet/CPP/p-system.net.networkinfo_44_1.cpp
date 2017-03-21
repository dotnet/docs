void DisplayDnsAddresses()
{
   array<NetworkInterface^>^adapters = NetworkInterface::GetAllNetworkInterfaces();
   System::Collections::IEnumerator^ myEnum11 = adapters->GetEnumerator();
   while ( myEnum11->MoveNext() )
   {
      NetworkInterface ^ adapter = safe_cast<NetworkInterface ^>(myEnum11->Current);
      IPInterfaceProperties ^ adapterProperties = adapter->GetIPProperties();
      IPAddressCollection ^ dnsServers = adapterProperties->DnsAddresses;
      if ( dnsServers->Count > 0 )
      {
         Console::WriteLine( adapter->Description );
         System::Collections::IEnumerator^ myEnum12 = dnsServers->GetEnumerator();
         while ( myEnum12->MoveNext() )
         {
            IPAddress ^ dns = safe_cast<IPAddress ^>(myEnum12->Current);
            Console::WriteLine( "  DNS Servers ............................. : {0}", 
               dns->ToString());
         }
      }
   }
}