    Private Sub downloadButton_Click( _
        ByVal sender As Object, _
        ByVal e As EventArgs) _
        Handles downloadButton.Click

        ' Start the download operation in the background.
        Me.backgroundWorker1.RunWorkerAsync()

        ' Disable the button for the duration of the download.
        Me.downloadButton.Enabled = False

        ' Once you have started the background thread you 
        ' can exit the handler and the application will 
        ' wait until the RunWorkerCompleted event is raised.

        ' If you want to do something else in the main thread,
        ' such as update a progress bar, you can do so in a loop 
        ' while checking IsBusy to see if the background task is
        ' still running.
        While Me.backgroundWorker1.IsBusy
            progressBar1.Increment(1)
            ' Keep UI messages moving, so the form remains 
            ' responsive during the asynchronous operation.
            Application.DoEvents()
        End While
    End Sub