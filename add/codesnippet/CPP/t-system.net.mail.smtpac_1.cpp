        static SmtpPermission^ CreateConnectPermission()
        {
            SmtpPermission^ connectAccess = 
                gcnew SmtpPermission(SmtpAccess::Connect);
            Console::WriteLine("Access? {0}", connectAccess->Access);
            return connectAccess;
        }