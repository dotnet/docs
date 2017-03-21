    public static bool CheckSubSet(SmtpPermission permission)
    {
        SmtpPermission allAccess = new 
            SmtpPermission(System.Security.Permissions.PermissionState.Unrestricted);
        return permission.IsSubsetOf(allAccess);
    }