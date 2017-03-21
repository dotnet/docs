    Public Function GetThreadCount() As String
        ' Get the thread count.
        Return String.Format( _
        "Thread count: {0}", _
        processStatistics.ThreadCount.ToString())
    End Function 'GetThreadCount

