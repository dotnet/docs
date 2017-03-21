        Console.WriteLine("Creating a permission with the Flags property =" +
            " ProtectData.");
        DataProtectionPermission sp = new DataProtectionPermission(
            DataProtectionPermissionFlags.ProtectData);
        sp.PermitOnly();