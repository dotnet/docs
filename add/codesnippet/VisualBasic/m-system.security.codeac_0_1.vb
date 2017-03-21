        Public Overrides Function Copy() As IPermission
            Dim name As String
            name = m_name
            Return New NameIdPermission(name)
        End Function 'Copy
