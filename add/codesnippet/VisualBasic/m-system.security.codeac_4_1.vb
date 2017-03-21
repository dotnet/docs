        Public Overrides Function ToXml() As SecurityElement
            ' Use the SecurityElement class to encode the permission to XML.
            Dim esd As New SecurityElement("IPermission")

            Dim name As String = GetType(NameIdPermission).AssemblyQualifiedName
            esd.AddAttribute("class", name)
            esd.AddAttribute("version", "1.0")

            ' The following code for unrestricted permission is only included as an example for
            ' permissions that allow the unrestricted state. It is of no value for this permission.
            If m_Unrestricted Then
                esd.AddAttribute("Unrestricted", True.ToString())
            End If
            If Not (m_Name Is Nothing) Then
                esd.AddAttribute("Name", m_Name)
            End If
            Return esd
        End Function 'ToXml
    End Class ' NameIdPermission 