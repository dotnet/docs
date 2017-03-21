    public static SmtpPermission CreateConnectPermission()
    {
        SmtpPermission connectAccess = new 
            SmtpPermission(SmtpAccess.Connect);
        Console.WriteLine("Access? {0}", connectAccess.Access);
        return connectAccess;
    }