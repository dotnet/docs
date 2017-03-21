        Console.WriteLine("Creating a permission with the Flags property =" + " ProtectData.")
        Dim sp As New DataProtectionPermission(DataProtectionPermissionFlags.ProtectData)
        sp.PermitOnly()