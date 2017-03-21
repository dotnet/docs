        bool rc = sp2.IsSubsetOf(sp3);
        Console.WriteLine("Is the permission with all flags set (AllFlags) " +
            "a subset of \n \tthe permission with an Unrestricted " +
            "permission state? " + (rc ? "Yes" : "No"));
        rc = sp1.IsSubsetOf(sp2);
        Console.WriteLine("Is the permission with ProtectData access a " +
            "subset of the permission with \n" + "\tAllFlags set? " +
            (rc ? "Yes" : "No"));