    public static SmtpPermission UnionWithFull(SmtpPermission permission)
    {
        SmtpPermission allAccess = new 
            SmtpPermission(System.Security.Permissions.PermissionState.Unrestricted);
        return  (SmtpPermission)  permission.Union(allAccess);
    }