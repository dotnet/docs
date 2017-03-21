      // Display result of ToXml and FromXml operations.
      PermissionSet^ ps6 = gcnew PermissionSet( PermissionState::None );
      ps6->FromXml( ps5->ToXml() );
      Console::WriteLine( "Result of ToFromXml = {0}\n", ps6 );