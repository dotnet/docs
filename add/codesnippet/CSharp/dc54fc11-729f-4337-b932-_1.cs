    private static void IntPtrStringConstructor(IntPtr logonToken)
    {
        // Construct a WindowsIdentity object using the input account token 
        // and the specified authentication type.
        string authenticationType = "WindowsAuthentication";
        WindowsIdentity windowsIdentity =
			            new WindowsIdentity(logonToken, authenticationType);

        Console.WriteLine("Created a Windows identity object named " +
            windowsIdentity.Name + ".");
    }