    ' This event handler deals with the results of the
    ' background operation.
    Private Sub backgroundWorker1_RunWorkerCompleted( _
    ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) _
    Handles backgroundWorker1.RunWorkerCompleted

        ' First, handle the case where an exception was thrown.
        If (e.Error IsNot Nothing) Then
            MessageBox.Show(e.Error.Message)
        ElseIf e.Cancelled Then
            ' Next, handle the case where the user canceled the 
            ' operation.
            ' Note that due to a race condition in 
            ' the DoWork event handler, the Cancelled
            ' flag may not have been set, even though
            ' CancelAsync was called.
            resultLabel.Text = "Canceled"
        Else
            ' Finally, handle the case where the operation succeeded.
            resultLabel.Text = e.Result.ToString()
        End If

        ' Enable the UpDown control.
        Me.numericUpDown1.Enabled = True

        ' Enable the Start button.
        startAsyncButton.Enabled = True

        ' Disable the Cancel button.
        cancelAsyncButton.Enabled = False
    End Sub 'backgroundWorker1_RunWorkerCompleted