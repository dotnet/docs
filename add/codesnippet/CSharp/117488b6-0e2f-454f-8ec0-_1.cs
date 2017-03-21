        PermissionSet permissions =
            new PermissionSet(PermissionState.Unrestricted);
        permissions.AddPermission(
            new SecurityPermission(SecurityPermissionFlag.Execution));
        permissions.AddPermission(
            new ZoneIdentityPermission(SecurityZone.MyComputer));

        PolicyStatementAttribute levelFinalAttribute = 
            PolicyStatementAttribute.LevelFinal;
        
        // Create a new policy statement with the specified permission set.
        // The LevelFinal attribute is set to prevent the evaluation of lower
        // policy levels in a resolve operation.
        PolicyStatement policyStatement =
            new PolicyStatement(permissions, levelFinalAttribute);