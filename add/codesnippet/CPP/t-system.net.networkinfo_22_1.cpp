void GetTcpConnections()
{
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   array<TcpConnectionInformation^>^connections = properties->GetActiveTcpConnections();
   System::Collections::IEnumerator^ myEnum = connections->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      TcpConnectionInformation ^ t = safe_cast<TcpConnectionInformation ^>(myEnum->Current);
      Console::Write( "Local endpoint: {0} ", t->LocalEndPoint->Address );
      Console::Write( "Remote endpoint: {0} ", t->RemoteEndPoint->Address );
      Console::WriteLine( "{0}", t->State );
   }
}