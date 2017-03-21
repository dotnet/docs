        Dim windowsIdentity As WindowsIdentity = windowsIdentity.GetCurrent()

        ' Construct a GenericIdentity object based on the current Windows
        ' identity name and authentication type.
        Dim authenticationType As String = windowsIdentity.AuthenticationType
        Dim userName As String = windowsIdentity.Name
        Dim authenticatedGenericIdentity As _
            New GenericIdentity(userName, authenticationType)