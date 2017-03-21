        ' Display the SIDs for the groups the current user belongs to.
        Console.WriteLine("Display the SIDs for the groups the current user belongs to.")
        Dim irc As IdentityReferenceCollection
        Dim ir As IdentityReference
        irc = windowsIdentity.Groups
        For Each ir In irc
            Console.WriteLine(ir.Value)
        Next