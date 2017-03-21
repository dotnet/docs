void DisplayTypeAndAddress()
{
   IPGlobalProperties ^ computerProperties = IPGlobalProperties::GetIPGlobalProperties();
   array<NetworkInterface^>^nics = NetworkInterface::GetAllNetworkInterfaces();
   Console::WriteLine( "Interface information for {0}.{1}     ", computerProperties->HostName, computerProperties->DomainName );
   System::Collections::IEnumerator^ myEnum27 = nics->GetEnumerator();
   while ( myEnum27->MoveNext() )
   {
      NetworkInterface ^ adapter = safe_cast<NetworkInterface ^>(myEnum27->Current);
      IPInterfaceProperties ^ properties = adapter->GetIPProperties();
      Console::WriteLine( adapter->Description );
      Console::WriteLine( String::Empty->PadLeft( adapter->Description->Length, '=' ) );
      Console::WriteLine( "  Interface type .......................... : {0}", 
         adapter->NetworkInterfaceType );
      Console::WriteLine( "  Physical Address ........................ : {0}", 
         adapter->GetPhysicalAddress() );
      Console::WriteLine( "  Is receive only.......................... : {0}", 
         adapter->IsReceiveOnly );
      Console::WriteLine( "  Multicast................................ : {0}", 
         adapter->SupportsMulticast );
   }
}