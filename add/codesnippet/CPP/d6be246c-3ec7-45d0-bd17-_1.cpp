      // Open a new PermissionSet.
      PermissionSet^ ps1 = gcnew PermissionSet( PermissionState::None );

      Console::WriteLine( "Adding permission to open a file from a file dialog box." );

      // Add a permission to the permission set.
      ps1->AddPermission( gcnew FileDialogPermission( FileDialogPermissionAccess::Open ) );

      Console::WriteLine( "Demanding permission to open a file." );
      ps1->Demand();
      Console::WriteLine( "Demand succeeded." );