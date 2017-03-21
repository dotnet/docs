        static bool CheckSubSet(
            SmtpPermission^ permission)
        {
            SmtpPermission^ allAccess = 
                gcnew SmtpPermission(PermissionState::Unrestricted);
            return permission->IsSubsetOf(allAccess);
        }