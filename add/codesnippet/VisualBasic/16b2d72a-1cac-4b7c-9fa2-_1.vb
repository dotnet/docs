        Dim roles(10) As String
        Dim windowsIdentity As WindowsIdentity = windowsIdentity.GetCurrent()

        If (windowsIdentity.IsAuthenticated) Then
            ' Add custom NetworkUser role.
            roles(0) = "NetworkUser"
        End If

        If (windowsIdentity.IsGuest) Then
            ' Add custom GuestUser role.
            roles(1) = "GuestUser"
        End If


        If (windowsIdentity.IsSystem) Then
            ' Add custom SystemUser role.
            roles(2) = "SystemUser"
        End If

        ' Construct a GenericIdentity object based on the current Windows
        ' identity name and authentication type.
        Dim authenticationType As String = windowsIdentity.AuthenticationType
        Dim userName As String = windowsIdentity.Name
        Dim genericIdentity = _
            New GenericIdentity(userName, authenticationType)

        ' Construct a GenericPrincipal object based on the generic identity
        ' and custom roles for the user.
        Dim genericPrincipal As New GenericPrincipal(genericIdentity, roles)