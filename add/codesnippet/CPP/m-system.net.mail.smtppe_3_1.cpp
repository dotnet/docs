        static SmtpPermission^ CreateUnrestrictedPermission2()
        {
            SmtpPermission^ allAccess = gcnew SmtpPermission(true);
            Console::WriteLine("Is unrestricted? {0}", 
                allAccess->IsUnrestricted());
            return allAccess;
        }