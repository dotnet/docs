array<PhysicalAddress^>^ StoreNetworkInterfaceAddresses()
{
   IPGlobalProperties^ computerProperties = IPGlobalProperties::GetIPGlobalProperties();
   array<NetworkInterface^>^nics = NetworkInterface::GetAllNetworkInterfaces();
   if ( nics == nullptr || nics->Length < 1 )
   {
      Console::WriteLine( L"  No network interfaces found." );
      return nullptr;
   }

   array<PhysicalAddress^>^ addresses = gcnew array<PhysicalAddress^>(nics->Length);
   int i = 0;
   IEnumerator^ myEnum2 = nics->GetEnumerator();
   while ( myEnum2->MoveNext() )
   {
      NetworkInterface^ adapter = safe_cast<NetworkInterface^>(myEnum2->Current);
      IPInterfaceProperties^ properties = adapter->GetIPProperties();
      PhysicalAddress^ address = adapter->GetPhysicalAddress();
      array<Byte>^bytes = address->GetAddressBytes();
      PhysicalAddress^ newAddress = gcnew PhysicalAddress( bytes );
      addresses[ i++ ] = newAddress;
   }

   return addresses;
}

