    Public Function GetManagedHeapSize() As String
        ' Get the mamaged heap size.
        Return String.Format( _
        "Managed heap size: {0}", _
        processStatistics.ManagedHeapSize.ToString())
    End Function 'GetManagedHeapSize

