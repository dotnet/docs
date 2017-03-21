    private static void IntPtrStringTypeConstructor(IntPtr logonToken)
    {
        // Construct a WindowsIdentity object using the input account token,
        // and the specified authentication type, and Windows account type.
        string authenticationType = "WindowsAuthentication";
        WindowsAccountType guestAccount = WindowsAccountType.Guest;
        WindowsIdentity windowsIdentity =
            new WindowsIdentity(logonToken, authenticationType, guestAccount);

        Console.WriteLine("Created a Windows identity object named " +
            windowsIdentity.Name + ".");
    }