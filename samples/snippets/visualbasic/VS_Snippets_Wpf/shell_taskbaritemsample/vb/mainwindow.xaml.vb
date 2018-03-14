' <snippet100>
' MainWindow.xaml.vb
Imports System.ComponentModel
Imports System.Windows.Shell

Class MainWindow
    Private _backgroundWorker As New BackgroundWorker

    Public Sub New()
        InitializeComponent()

        ' Set up the BackgroundWorker
        Me._backgroundWorker.WorkerReportsProgress = True
        Me._backgroundWorker.WorkerSupportsCancellation = True
        AddHandler Me._backgroundWorker.DoWork, AddressOf bw_DoWork
        AddHandler Me._backgroundWorker.ProgressChanged, AddressOf bw_ProgressChanged
        AddHandler Me._backgroundWorker.RunWorkerCompleted, AddressOf bw_RunWorkerCompleted
    End Sub

    Private Sub StartCommand_CanExecute(ByVal sender As System.Object, ByVal e As System.Windows.Input.CanExecuteRoutedEventArgs)
        e.CanExecute = True
        e.Handled = True
    End Sub

    ' <snippet110>
    Private Sub StartCommand_Executed(ByVal sender As System.Object, ByVal e As System.Windows.Input.ExecutedRoutedEventArgs)
        If Me._backgroundWorker.IsBusy = False Then
            Me._backgroundWorker.RunWorkerAsync()
            ' When the task is started, change the ProgressState and Overlay
            ' of the taskbar item to indicate an active task.
            Me.taskBarItemInfo1.ProgressState = Shell.TaskbarItemProgressState.Normal
            Me.taskBarItemInfo1.Overlay = Me.FindResource("PlayImage")
        End If
        e.Handled = True
    End Sub
    ' </snippet110>

    Private Sub StopCommand_CanExecute(ByVal sender As System.Object, ByVal e As System.Windows.Input.CanExecuteRoutedEventArgs)
        e.CanExecute = Me._backgroundWorker.WorkerSupportsCancellation
        e.Handled = True
    End Sub

    Private Sub StopCommand_Executed(ByVal sender As System.Object, ByVal e As System.Windows.Input.ExecutedRoutedEventArgs)
        Me._backgroundWorker.CancelAsync()
        e.Handled = True
    End Sub

    ' <snippet120>
    Private Sub bw_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)
        ' When the task ends, change the ProgressState and Overlay
        ' of the taskbar item to indicate a stopped task.
        If e.Cancelled = True Then
            ' The task was stopped by the user. Show the progress indicator
            ' in the paused state.
            Me.taskBarItemInfo1.ProgressState = TaskbarItemProgressState.Paused
        ElseIf e.Error IsNot Nothing Then
            ' The task ended with an error. Show the progress indicator
            ' in the error state.
            Me.taskBarItemInfo1.ProgressState = TaskbarItemProgressState.Error
        Else
            ' The task completed normally. Remove the progress indicator.
            Me.taskBarItemInfo1.ProgressState = TaskbarItemProgressState.None
            ' In all cases, show the 'Stopped' overlay.
            ' <snippet121>
            Me.taskBarItemInfo1.Overlay = Me.FindResource("StopImage")
            ' </snippet121>
        End If
    End Sub
    ' </snippet120>

    ' <snippet130>
    Private Sub bw_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs)
        Me.tbCount.Text = e.ProgressPercentage.ToString()
        ' Update the value of the task bar progress indicator.
        Me.taskBarItemInfo1.ProgressValue = e.ProgressPercentage / 100
    End Sub
    ' </snippet130>

    Private Sub bw_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        Dim _worker As BackgroundWorker = CType(sender, BackgroundWorker)
        If _worker IsNot Nothing Then
            For i As Integer = 1 To 100 Step 1
                If _worker.CancellationPending = True Then
                    e.Cancel = True
                    Return
                Else
                    System.Threading.Thread.Sleep(25)
                    _worker.ReportProgress(i)
                End If
            Next
        End If
    End Sub
End Class
' </snippet100>
