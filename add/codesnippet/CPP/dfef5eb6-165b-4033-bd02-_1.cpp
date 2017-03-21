   MailslotPermission( MailslotPermissionAccess permissionAccess, String^ name, String^ machineName )
   {
      SetNames();
      this->AddPermissionAccess( gcnew MailslotPermissionEntry( permissionAccess,name,machineName ) );
   }

   MailslotPermission( array<MailslotPermissionEntry^>^permissionAccessEntries )
   {
      SetNames();
      if ( permissionAccessEntries == nullptr )
            throw gcnew ArgumentNullException( "permissionAccessEntries" );

      for ( int index = 0; index < permissionAccessEntries->Length; ++index )
         this->AddPermissionAccess( permissionAccessEntries[ index ] );
   }