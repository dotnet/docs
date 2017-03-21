void ShowInterfaceSpeedAndQueue()
{
   array<NetworkInterface^>^adapters = NetworkInterface::GetAllNetworkInterfaces();
   System::Collections::IEnumerator^ myEnum9 = adapters->GetEnumerator();
   while ( myEnum9->MoveNext() )
   {
      NetworkInterface ^ adapter = safe_cast<NetworkInterface ^>(myEnum9->Current);
      IPInterfaceProperties ^ properties = adapter->GetIPProperties();
      IPv4InterfaceStatistics ^ stats = adapter->GetIPv4Statistics();
      Console::WriteLine( adapter->Description );
      Console::WriteLine( "     Speed .................................: {0}", 
         adapter->Speed );
      Console::WriteLine( "     Output queue length....................: {0}", 
         stats->OutputQueueLength );
   }
}