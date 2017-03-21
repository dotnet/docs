        Dim rootFilePermissions As New FileIOPermission(PermissionState.None)
        rootFilePermissions.AllLocalFiles = FileIOPermissionAccess.Read
        rootFilePermissions.SetPathList(FileIOPermissionAccess.Read, "C:\\")

        ' Add a permission to a named permission set.
        Dim namedPermissions As New NamedPermissionSet("RootPermissions")
        namedPermissions.AddPermission(rootFilePermissions)

        ' Create a PolicyStatement with exclusive rights to the policy.
        Dim policy As New PolicyStatement( _
            namedPermissions, _
            PolicyStatementAttribute.Exclusive)

        ' Create a FirstMatchCodeGroup with a membership condition that 
        ' matches all code, and an exclusive policy.
        Dim codeGroup As New FirstMatchCodeGroup( _
            New AllMembershipCondition, _
            policy)