        Console.WriteLine("Creating the union of the second and first " +
            "permissions.");
        sp4 = (DataProtectionPermission)sp2.Union(sp1);
        Console.WriteLine("Result of the union of the second permission " +
            "with the first: " + sp4.Flags);