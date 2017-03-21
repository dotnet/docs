    ' Populate the permission's fields from XML.
    Public Overrides Sub FromXml(ByVal e As SecurityElement)
        m_specifiedAsUnrestricted = False
        m_flags = 0

        ' If XML indicates an unrestricted permission, make this permission unrestricted.
        Dim s As String = CStr(e.Attributes("Unrestricted"))
        If Not (s Is Nothing) Then
            m_specifiedAsUnrestricted = Convert.ToBoolean(s)
            If m_specifiedAsUnrestricted Then
                m_flags = SoundPermissionState.PlayAnySound
            End If
        End If
        ' If XML indicates a restricted permission, parse the flags.
        If Not m_specifiedAsUnrestricted Then
            s = CStr(e.Attributes("Flags"))
            If Not (s Is Nothing) Then
                m_flags = CType(Convert.ToInt32([Enum].Parse(GetType(SoundPermission), s, True)), SoundPermissionState)
            End If
        End If

    End Sub 'FromXml
