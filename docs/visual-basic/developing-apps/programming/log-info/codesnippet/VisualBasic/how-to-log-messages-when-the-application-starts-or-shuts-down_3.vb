        Private Sub MyApplication_Startup(
            ByVal sender As Object,
            ByVal e As ApplicationServices.StartupEventArgs
        ) Handles Me.Startup
            My.Application.Log.WriteEntry("Application started at " &
                My.Computer.Clock.GmtTime.ToString)
        End Sub

        Private Sub MyApplication_Shutdown(
            ByVal sender As Object,
            ByVal e As System.EventArgs
        ) Handles Me.Shutdown
            My.Application.Log.WriteEntry("Application shut down at " &
                My.Computer.Clock.GmtTime.ToString)
        End Sub