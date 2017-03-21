        TokenImpersonationLevel token = windowsIdentity.ImpersonationLevel;
        Console.WriteLine("The impersonation level for the current user is : " + token.ToString());