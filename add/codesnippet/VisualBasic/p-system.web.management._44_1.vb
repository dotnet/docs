    Public Function GetApplicationPath() As String
        ' Get the name of the application  path.
        Return String.Format( _
        "Application path: {0}", _
        ApplicationInformation.ApplicationPath())
    End Function 'GetApplicationPath
