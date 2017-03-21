void ShowActiveTcpConnections()
{
   Console::WriteLine( "Active TCP Connections" );
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   array<TcpConnectionInformation^>^connections = properties->GetActiveTcpConnections();
   System::Collections::IEnumerator^ myEnum6 = connections->GetEnumerator();
   while ( myEnum6->MoveNext() )
   {
      TcpConnectionInformation ^ c = safe_cast<TcpConnectionInformation ^>(myEnum6->Current);
      Console::WriteLine( "{0} <==> {1}", c->LocalEndPoint, c->RemoteEndPoint );
   }
}