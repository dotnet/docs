    Public Function GetApplicationTrustLevel() As String
        ' Get the name of the application trust level.
        Return String.Format( _
        "Application trust level: {0}", _
        ApplicationInformation.TrustLevel())
    End Function 'GetApplicationTrustLevel
