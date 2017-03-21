        Console.WriteLine("Copying the second permission to the fourth " + "permission.")
        sp4 = CType(sp2.Copy(), DataProtectionPermission)
        rc = sp4.Equals(sp2)
        Console.WriteLine("Is the fourth permission equal to the second " + "permission? " + IIf(rc, "Yes", "No")) 'TODO: For performance reasons this should be changed to nested IF statements