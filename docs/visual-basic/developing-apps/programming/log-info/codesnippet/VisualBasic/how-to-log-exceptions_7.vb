        Private Sub MyApplication_UnhandledException(
            ByVal sender As Object,
            ByVal e As ApplicationServices.UnhandledExceptionEventArgs
        ) Handles Me.UnhandledException
            My.Application.Log.WriteException(e.Exception,
                TraceEventType.Critical,
                "Application shut down at " &
                My.Computer.Clock.GmtTime.ToString)
        End Sub