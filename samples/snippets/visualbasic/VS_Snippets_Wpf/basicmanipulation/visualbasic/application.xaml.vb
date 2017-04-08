Class Application

    ' Application-level events, such as Startup, Exit, and DispatcherUnhandledException
    ' can be handled in this file.

    Dim win1 As ReportBoundaryFeedBackExample

    Private Sub Application_Startup(ByVal sender As System.Object, ByVal e As System.Windows.StartupEventArgs)
        win1 = New ReportBoundaryFeedBackExample()
        win1.Show()
    End Sub
End Class
