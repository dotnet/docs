      PermissionSet^ permissions = gcnew PermissionSet(
         PermissionState::Unrestricted );
      permissions->AddPermission( gcnew SecurityPermission(
         SecurityPermissionFlag::Execution ) );
      permissions->AddPermission( gcnew ZoneIdentityPermission(
         SecurityZone::MyComputer ) );

      PolicyStatementAttribute levelFinalAttribute =
         PolicyStatementAttribute::LevelFinal;
      
      // Create a new policy statement with the specified permission set.
      // The LevelFinal attribute is set to prevent the evaluation of lower
      // policy levels in a resolve operation.
      PolicyStatement^ policyStatement = gcnew PolicyStatement(
         permissions,levelFinalAttribute );