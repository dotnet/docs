        readPerm2 = New RegistryPermission(PermissionState.None)
        readPerm2.FromXml(readPerm1.ToXml())
        Console.WriteLine("Result of ToFromXml = " + readPerm2.ToString() + vbLf)