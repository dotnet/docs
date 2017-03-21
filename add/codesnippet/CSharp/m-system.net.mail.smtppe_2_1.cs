    public static SmtpPermission CreatePermissionCopy(SmtpPermission p)
    {
        SmtpPermission copy = (SmtpPermission) p.Copy();
        return copy;
    }