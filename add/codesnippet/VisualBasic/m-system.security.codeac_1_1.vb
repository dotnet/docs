        Public Overrides Sub FromXml(ByVal e As SecurityElement)
            ' The following code for unrestricted permission is only included as an example for
            ' permissions that allow the unrestricted state. It is of no value for this permission.
            Dim elUnrestricted As String = e.Attribute("Unrestricted")
            If Nothing <> elUnrestricted Then
                m_Unrestricted = Boolean.Parse(elUnrestricted)
                Return
            End If

            Dim elName As String = e.Attribute("Name")
            m_name = IIf(elName Is Nothing, Nothing, elName)
        End Sub 'FromXml
