

// <snippet1>
#using <System.dll>

using namespace System;
using namespace System::Net;
using namespace System::Net::NetworkInformation;
void AddressChangedCallback( Object^ /*sender*/, EventArgs^ /*e*/ )
{
   array<NetworkInterface^>^adapters = NetworkInterface::GetAllNetworkInterfaces();
   System::Collections::IEnumerator^ myEnum = adapters->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      NetworkInterface^ n = safe_cast<NetworkInterface^>(myEnum->Current);
      Console::WriteLine( "   {0} is {1}", n->Name, n->OperationalStatus );
   }
}

int main()
{
   NetworkChange::NetworkAddressChanged += gcnew NetworkAddressChangedEventHandler( AddressChangedCallback );
   Console::WriteLine( "Listening for address changes. Press any key to exit." );
   Console::ReadLine();
}

// </snippet1>
