    ' Handler for the SoundLocationChanged event.
    Private Sub player_LocationChanged(ByVal sender As Object, _
        ByVal e As EventArgs)
        Dim message As String = [String].Format("SoundLocationChanged: {0}", _
            player.SoundLocation)
        ReportStatus(message)
    End Sub