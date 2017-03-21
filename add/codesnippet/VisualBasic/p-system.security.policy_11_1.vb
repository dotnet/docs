        Dim allPerms As New NamedPermissionSet("allPerms")
        allPerms.AddPermission( _
            New SecurityPermission(SecurityPermissionFlag.Execution))
        allPerms.AddPermission( _
            New ZoneIdentityPermission(SecurityZone.MyComputer))
        allPerms.AddPermission( _
            New SiteIdentityPermission("www.contoso.com"))

        policyStatement.PermissionSet = allPerms