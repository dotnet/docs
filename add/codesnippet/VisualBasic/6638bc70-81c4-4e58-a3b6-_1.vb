        Dim permissions As New PermissionSet(PermissionState.Unrestricted)

        permissions.AddPermission( _
            New SecurityPermission(SecurityPermissionFlag.Execution))
        permissions.AddPermission( _
            New ZoneIdentityPermission(SecurityZone.MyComputer))

        ' Instantiate a new policy statement with specified permission set.
        Dim policyStatement As New PolicyStatement(permissions)