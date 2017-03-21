    Public Class ErrorFilter
        Inherits TraceFilter

        Public Overrides Function ShouldTrace ( cache As TraceEventCache, _
                    source As String, eventType As TraceEventType, _
                    id As Integer, formatOrMessage As String, _
                    args As Object(), data As Object, _
                    dataArray As Object() ) As Boolean
            If eventType = TraceEventType.Error Then
                Return True
            Else
                Return False
            End If
        End Function
    End Class