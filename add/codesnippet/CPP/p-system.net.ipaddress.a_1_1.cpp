         // Display the type of address family supported by the server. If the
         // server is IPv6-enabled this value is: InternNetworkV6. If the server
         // is also IPv4-enabled there will be an additional value of InterNetwork.
         Console::WriteLine( "AddressFamily: {0}", curAdd->AddressFamily );
         
         // Display the ScopeId property in case of IPV6 addresses.
         if ( curAdd->AddressFamily.ToString() == ProtocolFamily::InterNetworkV6.ToString() )
                  Console::WriteLine( "Scope Id: {0}", curAdd->ScopeId );