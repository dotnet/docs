void DisplayDnsConfiguration()
{
   array<NetworkInterface^>^adapters = NetworkInterface::GetAllNetworkInterfaces();
   System::Collections::IEnumerator^ myEnum10 = adapters->GetEnumerator();
   while ( myEnum10->MoveNext() )
   {
      NetworkInterface ^ adapter = safe_cast<NetworkInterface ^>(myEnum10->Current);
      IPInterfaceProperties ^ properties = adapter->GetIPProperties();
      Console::WriteLine( adapter->Description );
      Console::WriteLine( "  DNS suffix................................. :{0}", 
         properties->DnsSuffix );
      Console::WriteLine( "  DNS enabled ............................. : {0}", 
         properties->IsDnsEnabled );
      Console::WriteLine( "  Dynamically configured DNS .............. : {0}", 
         properties->IsDynamicDnsEnabled );
   }
}