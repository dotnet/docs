        // Get the role using the string value of the role.
        Console.WriteLine("{0}? {1}.", "Administrators",
            myPrincipal.IsInRole("BUILTIN\\" + "Administrators"));
        Console.WriteLine("{0}? {1}.", "Users",
            myPrincipal.IsInRole("BUILTIN\\" + "Users"));