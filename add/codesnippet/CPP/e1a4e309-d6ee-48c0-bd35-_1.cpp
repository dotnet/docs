      FileIOPermission^ rootFilePermissions =
         gcnew FileIOPermission( PermissionState::None );
      rootFilePermissions->AllLocalFiles = FileIOPermissionAccess::Read;
      rootFilePermissions->SetPathList( FileIOPermissionAccess::Read, L"C:\\" );
      
      // Add a permission to a named permission set.
      NamedPermissionSet^ namedPermissions =
         gcnew NamedPermissionSet( L"RootPermissions" );
      namedPermissions->AddPermission( rootFilePermissions );
      
      // Create a PolicyStatement with exclusive rights to the policy.
      PolicyStatement^ policy = gcnew PolicyStatement(
         namedPermissions,PolicyStatementAttribute::Exclusive );
      
      // Create a FirstMatchCodeGroup with a membership condition that
      // matches all code, and an exclusive policy.
      FirstMatchCodeGroup^ codeGroup = gcnew FirstMatchCodeGroup(
         gcnew AllMembershipCondition,policy );