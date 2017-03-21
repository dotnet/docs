        WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();
        string[] roles = new string[10];
        if (windowsIdentity.IsAuthenticated)
        {
            // Add custom NetworkUser role.
            roles[0] = "NetworkUser";
        }

        if (windowsIdentity.IsGuest)
        {
            // Add custom GuestUser role.
            roles[1] = "GuestUser";
        }

        if (windowsIdentity.IsSystem)
        {
            // Add custom SystemUser role.
            roles[2] = "SystemUser";
        }

        // Construct a GenericIdentity object based on the current Windows
        // identity name and authentication type.
        string authenticationType = windowsIdentity.AuthenticationType;
        string userName = windowsIdentity.Name;
        GenericIdentity genericIdentity =
            new GenericIdentity(userName, authenticationType);

        // Construct a GenericPrincipal object based on the generic identity
        // and custom roles for the user.
        GenericPrincipal genericPrincipal =
            new GenericPrincipal(genericIdentity, roles);