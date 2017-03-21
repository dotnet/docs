      SocketPermission^ socketPermission1 = gcnew SocketPermission( PermissionState::Unrestricted );
      
      // Create a 'SocketPermission' Object* for two ip addresses.
      SocketPermission^ socketPermission2 = gcnew SocketPermission( PermissionState::None );
      SecurityElement^ securityElement4 = socketPermission2->ToXml();
      
      // 'SocketPermission' Object* for 'Connect' permission
      SecurityElement^ securityElement1 = gcnew SecurityElement( "ConnectAccess" );
      
      // Format to specify ip address are <ip-address>#<port>#<transport-type>
      // First 'SocketPermission' ip-address is '192.168.144.238' for 'All' transport types and for 'All' ports for the ip-address.
      SecurityElement^ securityElement2 = gcnew SecurityElement( "URI","192.168.144.238#-1#3" );
      
      // Second 'SocketPermission' ip-address is '192.168.144.240' for 'All' transport types and for 'All' ports for the ip-address.
      SecurityElement^ securityElement3 = gcnew SecurityElement( "URI","192.168.144.240#-1#3" );
      securityElement1->AddChild( securityElement2 );
      securityElement1->AddChild( securityElement3 );
      securityElement4->AddChild( securityElement1 );
      
      // Obtain a 'SocketPermission' Object* using 'FromXml' method.
      socketPermission2->FromXml( securityElement4 );
      
      // Create another 'SocketPermission' Object* with two ip addresses.
      // First 'SocketPermission' ip-address is '192.168.144.238' for 'All' transport types and for 'All' ports for the ip-address.
      SocketPermission^ socketPermission3 = gcnew SocketPermission( NetworkAccess::Connect,TransportType::All,"192.168.144.238",SocketPermission::AllPorts );
      
      // Second 'SocketPermission' ip-address is '192.168.144.239' for 'All' transport types and for 'All' ports for the ip-address.
      socketPermission3->AddPermission( NetworkAccess::Connect, TransportType::All, "192.168.144.239", SocketPermission::AllPorts );
      Console::WriteLine( "\nChecks the Socket permissions using IsUnrestricted method : " );
      if ( socketPermission1->IsUnrestricted() )
            Console::WriteLine( "Socket permission is unrestricted" );
      else
            Console::WriteLine( "Socket permission is restricted" );

      Console::WriteLine();
      Console::WriteLine( "Display result of ConnectList property : \n" );
      IEnumerator^ enumerator = socketPermission3->ConnectList;
      while ( enumerator->MoveNext() )
      {
         Console::WriteLine( "The hostname is       : {0}", dynamic_cast<EndpointPermission^>(enumerator->Current)->Hostname );
         Console::WriteLine( "The port is           : {0}", dynamic_cast<EndpointPermission^>(enumerator->Current)->Port );
         Console::WriteLine( "The Transport type is : {0}", dynamic_cast<EndpointPermission^>(enumerator->Current)->Transport );
      }

      Console::WriteLine( "" );
      Console::WriteLine( "Display Security Elements :\n " );
      PrintSecurityElement( socketPermission2->ToXml(), 0 );
      
      // Get a 'SocketPermission' Object* which is a union of two other 'SocketPermission' objects.
      socketPermission1 = dynamic_cast<SocketPermission^>(socketPermission3->Union( socketPermission2 ));
      
      // Demand that the calling method have the socket permission.
      socketPermission1->Demand();