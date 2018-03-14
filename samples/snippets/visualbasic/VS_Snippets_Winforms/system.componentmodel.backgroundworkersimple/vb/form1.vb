' <snippet1>
Imports System.ComponentModel

Public Class Form1

    Public Sub New()
        InitializeComponent()
        backgroundWorker1.WorkerReportsProgress = True
        backgroundWorker1.WorkerSupportsCancellation = True
    End Sub

    Private Sub startAsyncButton_Click(ByVal sender As System.Object, _
    ByVal e As System.EventArgs) Handles startAsyncButton.Click
        If backgroundWorker1.IsBusy <> True Then
            ' Start the asynchronous operation.
            backgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub cancelAsyncButton_Click(ByVal sender As System.Object, _
    ByVal e As System.EventArgs) Handles cancelAsyncButton.Click
        If backgroundWorker1.WorkerSupportsCancellation = True Then
            ' Cancel the asynchronous operation.
            backgroundWorker1.CancelAsync()
        End If
    End Sub

    ' This event handler is where the time-consuming work is done.
    Private Sub backgroundWorker1_DoWork(ByVal sender As System.Object, _
    ByVal e As DoWorkEventArgs) Handles backgroundWorker1.DoWork
        Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
        Dim i As Integer

        For i = 1 To 10
            If (worker.CancellationPending = True) Then
                e.Cancel = True
                Exit For
            Else
                ' Perform a time consuming operation and report progress.
                System.Threading.Thread.Sleep(500)
                worker.ReportProgress(i * 10)
            End If
        Next
    End Sub

    ' This event handler updates the progress.
    Private Sub backgroundWorker1_ProgressChanged(ByVal sender As System.Object, _
    ByVal e As ProgressChangedEventArgs) Handles backgroundWorker1.ProgressChanged
        resultLabel.Text = (e.ProgressPercentage.ToString() + "%")
    End Sub

    ' This event handler deals with the results of the background operation.
    Private Sub backgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object, _
    ByVal e As RunWorkerCompletedEventArgs) Handles backgroundWorker1.RunWorkerCompleted
        If e.Cancelled = True Then
            resultLabel.Text = "Canceled!"
        ElseIf e.Error IsNot Nothing Then
            resultLabel.Text = "Error: " & e.Error.Message
        Else
            resultLabel.Text = "Done!"
        End If
    End Sub
End Class
' </snippet1>
