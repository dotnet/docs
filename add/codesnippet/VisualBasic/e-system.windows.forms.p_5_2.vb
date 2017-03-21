    Private Sub pictureBox1_LoadProgressChanged(ByVal sender As Object, _
        ByVal e As ProgressChangedEventArgs) _
        Handles pictureBox1.LoadProgressChanged

        progressBar1.Value = e.ProgressPercentage

    End Sub 