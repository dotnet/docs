
#using <system.dll>

using namespace System;
using namespace System::Net::NetworkInformation;
using namespace System::Collections;

// <snippet1>
void DisplayAddressNone()
{
   PhysicalAddress^ none = PhysicalAddress::None;
   Console::WriteLine( L"None: {0}", none );
   array<Byte>^bytes = none->GetAddressBytes();
   System::Collections::IEnumerator^ myEnum = bytes->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      Byte b = safe_cast<Byte>(myEnum->Current);
      Console::Write( L"{0} ", b.ToString() );
   }

   Console::WriteLine();
}


// </snippet1>
// <snippet2>
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


// </snippet2>
// <snippet3>
void ParseTest()
{
   PhysicalAddress^ address = PhysicalAddress::Parse( L"AC1EBA22" );
   Console::WriteLine( L"Address parsed as {0}", address->ToString() );
   PhysicalAddress^ address2 = PhysicalAddress::Parse( L"ac1eba22" );
   Console::WriteLine( L"Address2 parsed as {0}", address2->ToString() );
   bool test = address->Equals( address2 );
   Console::WriteLine( L"Equal? {0}", test );
}


// </snippet3>
// <snippet4>
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


// </snippet4>
//<snippet5>
PhysicalAddress^ StrictParseAddress( String^ address )
{
   PhysicalAddress^ newAddress = PhysicalAddress::Parse( address );
   if ( PhysicalAddress::None->Equals( newAddress ) )
      return nullptr;

   return newAddress;
}


//</snippet5>
int main()
{
   
     DisplayAddressNone();
     ShowNetworkInterfaces();
     ParseTest();
   /*  PhysicalAddress[] addresses = StoreNetworkInterfaceAddresses();
       foreach (PhysicalAddress address in addresses)
       {
       Console.WriteLine(address.ToString());
       }
   */
   PhysicalAddress^ a = StrictParseAddress( nullptr );
   Console::WriteLine( a == nullptr ? L"null" : a->ToString() );
}

