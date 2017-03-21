        IntPtr accountToken = WindowsIdentity.GetCurrent().Token;
        Console.WriteLine( "Token number is: " + accountToken.ToString());