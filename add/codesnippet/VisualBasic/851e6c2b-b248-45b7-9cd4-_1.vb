    Private Sub IntPrtStringTypeBoolConstructor(ByVal logonToken As IntPtr)
        ' Construct a WindowsIdentity object using the input account token,
        ' and the specified authentication type, Windows account type, and
        ' authentication flag.
        Dim authenticationType As String = "WindowsAuthentication"
        Dim guestAccount As WindowsAccountType = WindowsAccountType.Guest
        Dim isAuthenticated As Boolean = True
        Dim windowsIdentity As New WindowsIdentity( _
            logonToken, authenticationType, guestAccount, isAuthenticated)

        WriteLine("Created a Windows identity object named " + _
            windowsIdentity.Name + ".")
    End Sub