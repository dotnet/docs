        FileIOPermission rootFilePermissions =
            new FileIOPermission(PermissionState.None);
        rootFilePermissions.AllLocalFiles = FileIOPermissionAccess.Read;
        rootFilePermissions.SetPathList(FileIOPermissionAccess.Read,"C:\\");

        // Add a permission to a named permission set.
        NamedPermissionSet namedPermissions =
            new NamedPermissionSet("RootPermissions");
        namedPermissions.AddPermission(rootFilePermissions);

        // Create a PolicyStatement with exclusive rights to the policy.
        PolicyStatement policy = new PolicyStatement(
            namedPermissions,PolicyStatementAttribute.Exclusive);

        // Create a FirstMatchCodeGroup with a membership condition that
        // matches all code, and an exclusive policy.
        FirstMatchCodeGroup codeGroup =
            new FirstMatchCodeGroup(
            new AllMembershipCondition(),
            policy);