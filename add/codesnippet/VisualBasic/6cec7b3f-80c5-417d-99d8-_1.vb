    Private Sub IntPtrStringTypeConstructor(ByVal logonToken As IntPtr)
        ' Construct a WindowsIdentity object using the input account token,
        ' and the specified authentication type and Windows account type.
        Dim authenticationType As String = "WindowsAuthentication"
        Dim guestAccount As WindowsAccountType = WindowsAccountType.Guest
        Dim windowsIdentity As _
            New WindowsIdentity(logonToken, authenticationType, guestAccount)

        WriteLine("Created a Windows identity object named " + _
            windowsIdentity.Name + ".")
    End Sub