    Public Function GetRequestsRejected() As String
        ' Get the requests rejected.
        Return String.Format( _
        "Requests rejected: {0}", _
        processStatistics.RequestsRejected.ToString())
    End Function 'GetRequestsRejected

