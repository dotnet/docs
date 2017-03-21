    // Use the enumeration flags to indicate that this method exposes shared 
    // state, self-affecting threading, and the security infrastructure.
    [HostProtectionAttribute(SharedState=true, SelfAffectingThreading=true,
         SecurityInfrastructure=true)]
    // ApplyIdentity sets the current identity.
    private static int ApplyIdentity()
    {
        string[] roles = {"User"};
        try
        {
            AppDomain mAD = AppDomain.CurrentDomain;
            GenericPrincipal mGenPr = 
                new GenericPrincipal(WindowsIdentity.GetCurrent(), roles);
            mAD.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            mAD.SetThreadPrincipal(mGenPr);
            return Success;
        }
        catch (Exception e)
        {
            Exit(e.ToString(), 5);
        }
        return 0;
    }