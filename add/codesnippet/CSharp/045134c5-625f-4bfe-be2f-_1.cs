        // Get the role using the WindowsBuiltInRole enumeration value.
        Console.WriteLine("{0}? {1}.", WindowsBuiltInRole.Administrator,
           myPrincipal.IsInRole(WindowsBuiltInRole.Administrator));