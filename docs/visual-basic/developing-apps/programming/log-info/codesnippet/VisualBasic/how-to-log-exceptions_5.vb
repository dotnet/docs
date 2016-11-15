    Public Sub ExceptionLogTest(ByVal fileName As String)
        Try
            ' Code that might generate an exception goes here.
            ' For example:
            '    Dim x As Object
            '    MsgBox(x.ToString)
        Catch ex As Exception
            My.Application.Log.WriteException(ex, 
                TraceEventType.Error, 
                "Exception in ExceptionLogTest " & 
                "with argument " & fileName & ".")
        End Try
    End Sub