      PermissionSet^ permissions = gcnew PermissionSet(
         PermissionState::Unrestricted );
      permissions->AddPermission( gcnew SecurityPermission(
         SecurityPermissionFlag::Execution ) );
      permissions->AddPermission( gcnew ZoneIdentityPermission(
         SecurityZone::MyComputer ) );
      
      // Create a policy statement based on the newly created permission
      // set.
      PolicyStatement^ policyStatement = gcnew PolicyStatement(
         permissions );