        Dim permissions As New PermissionSet(PermissionState.Unrestricted)
        permissions.AddPermission( _
            New SecurityPermission(SecurityPermissionFlag.Execution))
        permissions.AddPermission( _
            New ZoneIdentityPermission(SecurityZone.MyComputer))

        Dim levelFinalAttribute As PolicyStatementAttribute
        levelFinalAttribute = PolicyStatementAttribute.LevelFinal

        ' Instantiate a new policy statement with specified permission set
        ' and the LevelFinal attibute set allowing lower policy levels to be
        ' avoided in a resolve.
        Dim policyStatement As _
            New PolicyStatement(permissions, levelFinalAttribute)