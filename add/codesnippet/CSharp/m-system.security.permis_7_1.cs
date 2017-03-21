        Console.WriteLine("Copying the second permission to the fourth " +
            "permission.");
        sp4 = (DataProtectionPermission)sp2.Copy();
        rc = sp4.Equals(sp2);
        Console.WriteLine("Is the fourth permission equal to the second " +
            "permission? " + (rc ? "Yes" : "No"));