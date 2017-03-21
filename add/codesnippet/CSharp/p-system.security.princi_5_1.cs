        // Display the SID for the owner.
        Console.Write("The SID for the owner is : ");
        SecurityIdentifier si = windowsIdentity.Owner;
        Console.WriteLine(si.ToString());