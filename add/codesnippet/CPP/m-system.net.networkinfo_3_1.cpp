void ShowActiveUdpListeners()
{
   Console::WriteLine( "Active UDP Listeners" );
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   array<IPEndPoint^>^endPoints = properties->GetActiveUdpListeners();
   System::Collections::IEnumerator^ myEnum8 = endPoints->GetEnumerator();
   while ( myEnum8->MoveNext() )
   {
      IPEndPoint^ e = safe_cast<IPEndPoint^>(myEnum8->Current);
      Console::WriteLine( e );
   }
}