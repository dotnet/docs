        PermissionSet permissions 
            = new PermissionSet(PermissionState.Unrestricted);
        permissions.AddPermission(
            new SecurityPermission(SecurityPermissionFlag.Execution));
        permissions.AddPermission(
            new ZoneIdentityPermission(SecurityZone.MyComputer));

        // Create a policy statement based on the newly created permission
        // set.
        PolicyStatement policyStatement = new PolicyStatement(permissions);