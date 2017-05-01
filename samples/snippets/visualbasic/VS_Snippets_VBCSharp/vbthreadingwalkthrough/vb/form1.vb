Public Class Form1

    ' <snippet4>
    Private Sub BackgroundWorker1_RunWorkerCompleted( 
        ByVal sender As Object, 
        ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs
      ) Handles BackgroundWorker1.RunWorkerCompleted

        ' This event handler is called when the background thread finishes.
        ' This method runs on the main thread.
        If e.Error IsNot Nothing Then
            MessageBox.Show("Error: " & e.Error.Message)
        ElseIf e.Cancelled Then
            MessageBox.Show("Word counting canceled.")
        Else
            MessageBox.Show("Finished counting words.")
        End If
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged( 
        ByVal sender As Object, 
        ByVal e As System.ComponentModel.ProgressChangedEventArgs
      ) Handles BackgroundWorker1.ProgressChanged

        ' This method runs on the main thread.
        Dim state As Words.CurrentState = 
            CType(e.UserState, Words.CurrentState)
        Me.LinesCounted.Text = state.LinesCounted.ToString
        Me.WordsCounted.Text = state.WordsMatched.ToString
    End Sub
    ' </snippet4>

    ' <snippet6>
    Private Sub BackgroundWorker1_DoWork( 
        ByVal sender As Object, 
        ByVal e As System.ComponentModel.DoWorkEventArgs
      ) Handles BackgroundWorker1.DoWork

        ' This event handler is where the actual work is done.
        ' This method runs on the background thread.

        ' Get the BackgroundWorker object that raised this event.
        Dim worker As System.ComponentModel.BackgroundWorker
        worker = CType(sender, System.ComponentModel.BackgroundWorker)

        ' Get the Words object and call the main method.
        Dim WC As Words = CType(e.Argument, Words)
        WC.CountWords(worker, e)
    End Sub

    Sub StartThread()
        ' This method runs on the main thread.
        Me.WordsCounted.Text = "0"

        ' Initialize the object that the background worker calls.
        Dim WC As New Words
        WC.CompareString = Me.CompareString.Text
        WC.SourceFile = Me.SourceFile.Text

        ' Start the asynchronous operation.
        BackgroundWorker1.RunWorkerAsync(WC)
    End Sub
    ' </snippet6>

    ' <snippet8>
    Private Sub Start_Click() Handles Start.Click
        StartThread()
    End Sub
    ' </snippet8>

    ' <snippet10>
    Private Sub Cancel_Click() Handles Cancel.Click
        ' Cancel the asynchronous operation.
        Me.BackgroundWorker1.CancelAsync()
    End Sub
    ' </snippet10>

End Class
