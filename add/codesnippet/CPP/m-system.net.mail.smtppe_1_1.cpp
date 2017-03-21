        static SmtpPermission^ UnionWithFull(
            SmtpPermission^ permission)
        {
            SmtpPermission^ allAccess = 
                gcnew SmtpPermission(PermissionState::Unrestricted);
            return (SmtpPermission^) permission->Union(allAccess);
        }