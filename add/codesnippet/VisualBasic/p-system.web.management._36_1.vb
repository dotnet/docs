    Public Function GetApplicationVirtualPath() As String
        ' Get the name of the application virtual path.
        Return String.Format( _
        "Application virtual path: {0}", _
        ApplicationInformation.ApplicationVirtualPath())
    End Function 'GetApplicationVirtualPath
