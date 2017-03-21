    private static void IntPrtStringTypeBoolConstructor(IntPtr logonToken)
    {
        // Construct a WindowsIdentity object using the input account token,
        // and the specified authentication type, Windows account type, and
        // authentication flag.
        string authenticationType = "WindowsAuthentication";
        WindowsAccountType guestAccount = WindowsAccountType.Guest;
        bool isAuthenticated = true;
        WindowsIdentity windowsIdentity = new WindowsIdentity(
            logonToken, authenticationType, guestAccount, isAuthenticated);

        Console.WriteLine("Created a Windows identity object named " +
            windowsIdentity.Name + ".");
    }