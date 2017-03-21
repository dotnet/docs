    public static SmtpPermission CreateUnrestrictedPermission2()
    {
        SmtpPermission allAccess = new 
            SmtpPermission(true);
        Console.WriteLine("Is unrestricted? {0}", 
            allAccess.IsUnrestricted());
        return allAccess;
    }