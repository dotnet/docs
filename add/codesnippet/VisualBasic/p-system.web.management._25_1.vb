    Public Function GetApplicationMachineName() As String
        ' Get the name of the application machine name.
        Return String.Format( _
        "Application machine name: {0}", _
        ApplicationInformation.MachineName())
    End Function 'GetApplicationMachineName
