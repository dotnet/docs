    public static SmtpPermission CreateUnrestrictedPermission()
    {
        SmtpPermission allAccess = new 
            SmtpPermission(System.Security.Permissions.PermissionState.Unrestricted);
        Console.WriteLine("Is unrestricted? {0}", 
            allAccess.IsUnrestricted());
        return allAccess;
    }