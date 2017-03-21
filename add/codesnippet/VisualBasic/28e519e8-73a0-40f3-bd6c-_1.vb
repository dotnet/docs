        Console.WriteLine("Creating the intersection of the second and " + "first permissions.")
        sp4 = CType(sp2.Intersect(sp1), DataProtectionPermission)
        Console.WriteLine("The value of the Flags property is: " + sp4.Flags.ToString())