' <snippet1>
' <snippet2>
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Threading
Imports System.Windows.Forms
' </snippet2>

Public Class FibonacciForm
    Inherits System.Windows.Forms.Form

    ' <snippet14>
    Private numberToCompute As Integer = 0
    Private highestPercentageReached As Integer = 0
    ' </snippet14>

    Private numericUpDown1 As System.Windows.Forms.NumericUpDown
    Private WithEvents startAsyncButton As System.Windows.Forms.Button
    Private WithEvents cancelAsyncButton As System.Windows.Forms.Button
    Private progressBar1 As System.Windows.Forms.ProgressBar
    Private resultLabel As System.Windows.Forms.Label
    Private WithEvents backgroundWorker1 As System.ComponentModel.BackgroundWorker


    Public Sub New()
        InitializeComponent()
    End Sub 'New

    ' <snippet13>
    Private Sub startAsyncButton_Click(ByVal sender As System.Object, _
    ByVal e As System.EventArgs) _
    Handles startAsyncButton.Click

        ' Reset the text in the result label.
        resultLabel.Text = [String].Empty

        ' Disable the UpDown control until 
        ' the asynchronous operation is done.
        Me.numericUpDown1.Enabled = False

        ' Disable the Start button until 
        ' the asynchronous operation is done.
        Me.startAsyncButton.Enabled = False

        ' Enable the Cancel button while 
        ' the asynchronous operation runs.
        Me.cancelAsyncButton.Enabled = True

        ' Get the value from the UpDown control.
        numberToCompute = CInt(numericUpDown1.Value)

        ' Reset the variable for percentage tracking.
        highestPercentageReached = 0

        ' <snippet3>

        ' Start the asynchronous operation.
        backgroundWorker1.RunWorkerAsync(numberToCompute)
        ' </snippet3>
    End Sub 
    ' </snippet13>

    ' <snippet4>
    Private Sub cancelAsyncButton_Click( _
    ByVal sender As System.Object, _
    ByVal e As System.EventArgs) _
    Handles cancelAsyncButton.Click
        
        ' Cancel the asynchronous operation.
        Me.backgroundWorker1.CancelAsync()

        ' Disable the Cancel button.
        cancelAsyncButton.Enabled = False
        
    End Sub 'cancelAsyncButton_Click
    ' </snippet4>

    ' <snippet5>
    ' This event handler is where the actual work is done.
    Private Sub backgroundWorker1_DoWork( _
    ByVal sender As Object, _
    ByVal e As DoWorkEventArgs) _
    Handles backgroundWorker1.DoWork

        ' Get the BackgroundWorker object that raised this event.
        Dim worker As BackgroundWorker = _
            CType(sender, BackgroundWorker)

        ' Assign the result of the computation
        ' to the Result property of the DoWorkEventArgs
        ' object. This is will be available to the 
        ' RunWorkerCompleted eventhandler.
        e.Result = ComputeFibonacci(e.Argument, worker, e)
    End Sub 'backgroundWorker1_DoWork
    ' </snippet5>

    ' <snippet6>
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
    ' </snippet6>

    ' <snippet7>
    ' This event handler updates the progress bar.
    Private Sub backgroundWorker1_ProgressChanged( _
    ByVal sender As Object, ByVal e As ProgressChangedEventArgs) _
    Handles backgroundWorker1.ProgressChanged

        Me.progressBar1.Value = e.ProgressPercentage

    End Sub
    ' </snippet7>

    ' <snippet10>
    ' This is the method that does the actual work. For this
    ' example, it computes a Fibonacci number and
    ' reports progress as it does its work.
    Function ComputeFibonacci( _
        ByVal n As Integer, _
        ByVal worker As BackgroundWorker, _
        ByVal e As DoWorkEventArgs) As Long

        ' The parameter n must be >= 0 and <= 91.
        ' Fib(n), with n > 91, overflows a long.
        If n < 0 OrElse n > 91 Then
            Throw New ArgumentException( _
                "value must be >= 0 and <= 91", "n")
        End If

        Dim result As Long = 0

        ' <snippet8>
        ' Abort the operation if the user has canceled.
        ' Note that a call to CancelAsync may have set 
        ' CancellationPending to true just after the
        ' last invocation of this method exits, so this 
        ' code will not have the opportunity to set the 
        ' DoWorkEventArgs.Cancel flag to true. This means
        ' that RunWorkerCompletedEventArgs.Cancelled will
        ' not be set to true in your RunWorkerCompleted
        ' event handler. This is a race condition.
        ' <snippet11>
        If worker.CancellationPending Then
            e.Cancel = True
        ' </snippet11>
        Else
            If n < 2 Then
                result = 1
            Else
                result = ComputeFibonacci(n - 1, worker, e) + _
                         ComputeFibonacci(n - 2, worker, e)
            End If

            ' <snippet12>
            ' Report progress as a percentage of the total task.
            Dim percentComplete As Integer = _
                CSng(n) / CSng(numberToCompute) * 100
            If percentComplete > highestPercentageReached Then
                highestPercentageReached = percentComplete
                worker.ReportProgress(percentComplete)
            End If
            ' </snippet12>

        End If
        ' </snippet8>

        Return result

    End Function
    ' </snippet10>


    Private Sub InitializeComponent()
        Me.numericUpDown1 = New System.Windows.Forms.NumericUpDown
        Me.startAsyncButton = New System.Windows.Forms.Button
        Me.cancelAsyncButton = New System.Windows.Forms.Button
        Me.resultLabel = New System.Windows.Forms.Label
        Me.progressBar1 = New System.Windows.Forms.ProgressBar
        Me.backgroundWorker1 = New System.ComponentModel.BackgroundWorker
        CType(Me.numericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'numericUpDown1
        '
        Me.numericUpDown1.Location = New System.Drawing.Point(16, 16)
        Me.numericUpDown1.Maximum = New Decimal(New Integer() {91, 0, 0, 0})
        Me.numericUpDown1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numericUpDown1.Name = "numericUpDown1"
        Me.numericUpDown1.Size = New System.Drawing.Size(80, 20)
        Me.numericUpDown1.TabIndex = 0
        Me.numericUpDown1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'startAsyncButton
        '
        Me.startAsyncButton.Location = New System.Drawing.Point(16, 72)
        Me.startAsyncButton.Name = "startAsyncButton"
        Me.startAsyncButton.Size = New System.Drawing.Size(120, 23)
        Me.startAsyncButton.TabIndex = 1
        Me.startAsyncButton.Text = "Start Async"
        '
        'cancelAsyncButton
        '
        Me.cancelAsyncButton.Enabled = False
        Me.cancelAsyncButton.Location = New System.Drawing.Point(153, 72)
        Me.cancelAsyncButton.Name = "cancelAsyncButton"
        Me.cancelAsyncButton.Size = New System.Drawing.Size(119, 23)
        Me.cancelAsyncButton.TabIndex = 2
        Me.cancelAsyncButton.Text = "Cancel Async"
        '
        'resultLabel
        '
        Me.resultLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.resultLabel.Location = New System.Drawing.Point(112, 16)
        Me.resultLabel.Name = "resultLabel"
        Me.resultLabel.Size = New System.Drawing.Size(160, 23)
        Me.resultLabel.TabIndex = 3
        Me.resultLabel.Text = "(no result)"
        Me.resultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'progressBar1
        '
        Me.progressBar1.Location = New System.Drawing.Point(18, 48)
        Me.progressBar1.Name = "progressBar1"
        Me.progressBar1.Size = New System.Drawing.Size(256, 8)
        Me.progressBar1.TabIndex = 4
        '
        'backgroundWorker1
        '
        Me.backgroundWorker1.WorkerReportsProgress = True
        Me.backgroundWorker1.WorkerSupportsCancellation = True
        '
        'FibonacciForm
        '
        Me.ClientSize = New System.Drawing.Size(292, 118)
        Me.Controls.Add(Me.progressBar1)
        Me.Controls.Add(Me.resultLabel)
        Me.Controls.Add(Me.cancelAsyncButton)
        Me.Controls.Add(Me.startAsyncButton)
        Me.Controls.Add(Me.numericUpDown1)
        Me.Name = "FibonacciForm"
        Me.Text = "Fibonacci Calculator"
        CType(Me.numericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub 'InitializeComponent

    <STAThread()> _
    Shared Sub Main()
        Application.Run(New FibonacciForm)
    End Sub 'Main
End Class 'FibonacciForm 

' </snippet1>