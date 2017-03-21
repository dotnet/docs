        NamedPermissionSet allPerms = new NamedPermissionSet("allPerms");
        allPerms.AddPermission(
            new SecurityPermission(SecurityPermissionFlag.Execution));
        allPerms.AddPermission(
            new ZoneIdentityPermission(SecurityZone.MyComputer));
        allPerms.AddPermission(
            new SiteIdentityPermission("www.contoso.com"));

        policyStatement.PermissionSet = allPerms;