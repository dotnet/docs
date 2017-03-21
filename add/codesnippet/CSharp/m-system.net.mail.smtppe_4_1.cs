    public static SmtpPermission GiveFullAccess(SmtpPermission permission)
    {
        permission.AddPermission(SmtpAccess.Connect);
        return permission;
    }