void ShowActiveTcpListeners()
{
   Console::WriteLine( "Active TCP Listeners" );
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   array<IPEndPoint^>^endPoints = properties->GetActiveTcpListeners();
   System::Collections::IEnumerator^ myEnum7 = endPoints->GetEnumerator();
   while ( myEnum7->MoveNext() )
   {
      IPEndPoint^ e = safe_cast<IPEndPoint^>(myEnum7->Current);
      Console::WriteLine( e );
   }
}