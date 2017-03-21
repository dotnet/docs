    ' Produce XML from the permission's fields.
    Public Overrides Function ToXml() As SecurityElement
        ' These first three lines create an element with the required format.
        Dim e As New SecurityElement("IPermission")
        ' Replace the double quotation marks (“”) with single quotation marks (‘’)
        ' to remain XML compliant when the culture is not neutral.
        e.AddAttribute("class", [GetType]().AssemblyQualifiedName.Replace(ControlChars.Quote, "'"c))
        e.AddAttribute("version", "1")

        If Not m_specifiedAsUnrestricted Then
            e.AddAttribute("Flags", [Enum].Format(GetType(SoundPermissionState), m_flags, "G"))
        Else
            e.AddAttribute("Unrestricted", "true")
        End If
        Return e

    End Function 'ToXml