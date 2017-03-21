    Public Function GetProcessStartTime() As String
        ' Get the process start time.
        Return String.Format( _
        "Process start time: {0}", _
        processStatistics.ProcessStartTime.ToString())
    End Function 'GetProcessStartTime

