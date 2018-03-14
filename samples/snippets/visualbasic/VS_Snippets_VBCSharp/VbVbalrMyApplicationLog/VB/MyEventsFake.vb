Namespace My
    Partial Friend Class MyApplication
        '<snippet3>
        Private Sub MyApplication_Startup(
            ByVal sender As Object,
            ByVal e As ApplicationServices.StartupEventArgs
        ) Handles Me.Startup
            '<snippet1>
            My.Application.Log.WriteEntry("Application started at " &
                My.Computer.Clock.GmtTime.ToString)
            '</snippet1>
        End Sub

        Private Sub MyApplication_Shutdown(
            ByVal sender As Object,
            ByVal e As System.EventArgs
        ) Handles Me.Shutdown
            '<snippet2>
            My.Application.Log.WriteEntry("Application shut down at " &
                My.Computer.Clock.GmtTime.ToString)
            '</snippet2>
        End Sub
        '</snippet3>

        '<snippet5>
        Private Sub MyApplication_UnhandledException(
            ByVal sender As Object,
            ByVal e As ApplicationServices.UnhandledExceptionEventArgs
        ) Handles Me.UnhandledException
            '<snippet4>
            My.Application.Log.WriteException(e.Exception,
                TraceEventType.Critical,
                "Application shut down at " &
                My.Computer.Clock.GmtTime.ToString)
            '</snippet4>
        End Sub
        '</snippet5>

    End Class
End Namespace