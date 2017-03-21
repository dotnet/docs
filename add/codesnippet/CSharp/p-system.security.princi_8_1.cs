        // Display the SIDs for the groups the current user belongs to.
        Console.WriteLine("Display the SIDs for the groups the current user belongs to.");
        IdentityReferenceCollection irc = windowsIdentity.Groups;
        foreach (IdentityReference ir in irc)
            Console.WriteLine(ir.Value);