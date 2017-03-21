    // Use the enumeration flags to indicate that this method exposes 
    // shared state and self-affecting process management.
    // Either of the following attribute statements can be used to set the
    // resource flags.
    [HostProtectionAttribute(SharedState = true, 
        SelfAffectingProcessMgmt = true)]
    [HostProtectionAttribute(Resources = HostProtectionResource.SharedState |
         HostProtectionResource.SelfAffectingProcessMgmt)]
    private static void Exit(string Message, int Code)
    {
        // Exit the sample when an exception is thrown.
        Console.WriteLine("\nFAILED: " + Message + " " + Code.ToString());
        Environment.ExitCode = Code;
        Environment.Exit(Code);
    }