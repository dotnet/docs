    public static SmtpPermission IntersectionWithFull(SmtpPermission permission)
    {
        SmtpPermission allAccess = new 
            SmtpPermission(System.Security.Permissions.PermissionState.Unrestricted);
        return (SmtpPermission) permission.Intersect(allAccess);
    }