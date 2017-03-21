    ' Handler for the LoadCompleted event.
    Private Sub player_LoadCompleted(ByVal sender As Object, _
        ByVal e As AsyncCompletedEventArgs)

        Dim message As String = [String].Format("LoadCompleted: {0}", _
            Me.filepathTextbox.Text)
        ReportStatus(message)
        EnablePlaybackControls(True)

    End Sub