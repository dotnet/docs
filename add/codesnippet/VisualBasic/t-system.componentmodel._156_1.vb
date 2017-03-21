    ' This event handler updates the progress bar.
    Private Sub backgroundWorker1_ProgressChanged( _
    ByVal sender As Object, ByVal e As ProgressChangedEventArgs) _
    Handles backgroundWorker1.ProgressChanged

        Me.progressBar1.Value = e.ProgressPercentage

    End Sub