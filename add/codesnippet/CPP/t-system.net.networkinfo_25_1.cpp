void CountTcpConnections()
{
   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   array<TcpConnectionInformation^>^connections = properties->GetActiveTcpConnections();
   int establishedConnections = 0;
   System::Collections::IEnumerator^ myEnum1 = connections->GetEnumerator();
   while ( myEnum1->MoveNext() )
   {
      TcpConnectionInformation ^ t = safe_cast<TcpConnectionInformation ^>(myEnum1->Current);
      if ( t->State == TcpState::Established )
      {
         establishedConnections++;
      }

      Console::Write( "Local endpoint: {0} ", t->LocalEndPoint->Address );
      Console::WriteLine( "Remote endpoint: {0} ", t->RemoteEndPoint->Address );
   }

   Console::WriteLine( "There are {0} established TCP connections.", establishedConnections );
}