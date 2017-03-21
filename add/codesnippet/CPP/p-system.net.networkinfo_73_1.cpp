   IPGlobalProperties ^ properties = IPGlobalProperties::GetIPGlobalProperties();
   Console::WriteLine( "Computer name: {0}", properties->HostName );
   Console::WriteLine( "Domain name:   {0}", properties->DomainName );
   Console::WriteLine( "Node type:     {0:f}", properties->NodeType );
   Console::WriteLine( "DHCP scope:    {0}", properties->DhcpScopeName );
   Console::WriteLine( "WINS proxy?    {0}", properties->IsWinsProxy );