        readPerm2 = new RegistryPermission(PermissionState.None);
        readPerm2.FromXml(readPerm1.ToXml());
        Console.WriteLine("Result of ToFromXml = " + readPerm2.ToString() + "\n");