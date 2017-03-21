        WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();

        // Construct a GenericIdentity object based on the current Windows
        // identity name and authentication type.
        string authenticationType = windowsIdentity.AuthenticationType;
        string userName = windowsIdentity.Name;
        GenericIdentity authenticatedGenericIdentity =
            new GenericIdentity(userName, authenticationType);