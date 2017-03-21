void DisplayGatewayAddresses()
{
   Console::WriteLine( "Gateways" );
   array<NetworkInterface^>^adapters = NetworkInterface::GetAllNetworkInterfaces();
   System::Collections::IEnumerator^ myEnum21 = adapters->GetEnumerator();
   while ( myEnum21->MoveNext() )
   {
      NetworkInterface ^ adapter = safe_cast<NetworkInterface ^>(myEnum21->Current);
      IPInterfaceProperties ^ adapterProperties = adapter->GetIPProperties();
      GatewayIPAddressInformationCollection ^ addresses = adapterProperties->GatewayAddresses;
      if ( addresses->Count > 0 )
      {
         Console::WriteLine( adapter->Description );
         System::Collections::IEnumerator^ myEnum22 = addresses->GetEnumerator();
         while ( myEnum22->MoveNext() )
         {
            GatewayIPAddressInformation^ address = safe_cast<GatewayIPAddressInformation^>(myEnum22->Current);
            Console::WriteLine( "  Gateway Address ......................... : {0}", 
               address->Address->ToString() );
         }
         Console::WriteLine();
      }
   }
}