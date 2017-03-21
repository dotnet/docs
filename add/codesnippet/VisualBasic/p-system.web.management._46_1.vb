    Public Function GetApplicationDomain() As String
        ' Get the name of the application domain.
        Return String.Format( _
        "Application domain: {0}", _
        ApplicationInformation.ApplicationDomain)
    End Function 'GetApplicationDomain
