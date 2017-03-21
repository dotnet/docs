      // Check for an unrestricted permission set.
      PermissionSet^ ps7 = gcnew PermissionSet( PermissionState::Unrestricted );
      Console::WriteLine( "Permission set is unrestricted = {0}", ps7->IsUnrestricted() );