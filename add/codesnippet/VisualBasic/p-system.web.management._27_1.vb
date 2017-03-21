    Public Function GetWorkingSet() As String
        ' Get the working set.
        Return String.Format( _
        "Working set: {0}", _
        processStatistics.WorkingSet.ToString())
    End Function 'GetWorkingSet

