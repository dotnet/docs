      Console::WriteLine( "Creating a permission with the Flags property ="
      " ProtectData." );
      DataProtectionPermission ^ sp = gcnew DataProtectionPermission( DataProtectionPermissionFlags::ProtectData );
      
	  ProtectData();