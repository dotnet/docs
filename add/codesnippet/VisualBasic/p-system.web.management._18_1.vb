    Public Function GetRequestsExecuting() As String
        ' Get the requests in execution.
        Return String.Format( _
        "Requests executing: {0}", _
        processStatistics.RequestsExecuting.ToString())
    End Function 'GetRequestsExecuting

