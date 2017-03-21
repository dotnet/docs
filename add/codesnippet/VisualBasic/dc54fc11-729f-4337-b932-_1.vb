    Private Sub IntPtrStringConstructor(ByVal logonToken As IntPtr)
        ' Construct a WindowsIdentity object using the input account token 
        ' and the specified authentication type
        Dim authenticationType = "WindowsAuthentication"
        Dim windowsIdentity As _
            New WindowsIdentity(logonToken, authenticationType)

        WriteLine("Created a Windows identity object named " + _
            windowsIdentity.Name + ".")
    End Sub