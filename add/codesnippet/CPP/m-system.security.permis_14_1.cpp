      // Change the permission set using SetPermission.
      ps5->SetPermission( gcnew EnvironmentPermission( EnvironmentPermissionAccess::AllAccess,"USERNAME" ) );
      Console::WriteLine( "Permission set after SetPermission = {0}", ps5 );