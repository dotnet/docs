        static SmtpPermission^ CreateUnrestrictedPermission()
        {
            SmtpPermission^ allAccess = 
                gcnew SmtpPermission(PermissionState::Unrestricted);
            Console::WriteLine("Is unrestricted? {0}", 
                allAccess->IsUnrestricted());
            return allAccess;
        }