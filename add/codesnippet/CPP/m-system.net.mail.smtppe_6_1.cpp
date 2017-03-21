        static SmtpPermission^ IntersectionWithFull(
            SmtpPermission^ permission)
        {
            SmtpPermission^ allAccess = 
                gcnew SmtpPermission(PermissionState::Unrestricted);
            return (SmtpPermission^) permission->Intersect(allAccess);
        }