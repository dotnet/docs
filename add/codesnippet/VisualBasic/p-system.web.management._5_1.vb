    Public Function GetPeakWorkingSet() As String
        ' Get the peak working set.
        Return String.Format( _
        "Peak working set: {0}", _
        processStatistics.PeakWorkingSet.ToString())
    End Function 'GetPeakWorkingSet

