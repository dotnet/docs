    Public Function GetAppDomainCount() As String
        ' Get the app domain count.
        Return String.Format( _
        "Application domain count: {0}", _
        processStatistics.AppDomainCount.ToString())
    End Function 'GetAppDomainCount

