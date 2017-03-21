    Public Function GetRequestsQueued() As String
        ' Get the requests queued.
        Return String.Format( _
        "Requests queued: {0}", _
        processStatistics.RequestsQueued.ToString())
    End Function 'GetRequestsQueued

