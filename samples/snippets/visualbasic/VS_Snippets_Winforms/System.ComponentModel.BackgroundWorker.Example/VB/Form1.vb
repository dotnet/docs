' <snippet1>
' <snippet7>
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Threading
Imports System.Windows.Forms
' </snippet7>

Public Class Form1
   Inherits Form
   
   Public Sub New()
      InitializeComponent()
   End Sub
   
   
   ' <snippet2>
   Private Sub backgroundWorker1_DoWork( _
   sender As Object, e As DoWorkEventArgs) _
   Handles backgroundWorker1.DoWork

      ' Do not access the form's BackgroundWorker reference directly.
      ' Instead, use the reference provided by the sender parameter.
      Dim bw As BackgroundWorker = CType( sender, BackgroundWorker )
      
      ' Extract the argument.
      Dim arg As Integer = Fix(e.Argument)
      
      ' Start the time-consuming operation.
      e.Result = TimeConsumingOperation(bw, arg)
      
      ' If the operation was canceled by the user, 
      ' set the DoWorkEventArgs.Cancel property to true.
      If bw.CancellationPending Then
         e.Cancel = True
      End If

   End Sub   
   ' </snippet2>

   ' <snippet3>
   ' This event handler demonstrates how to interpret 
   ' the outcome of the asynchronous operation implemented
   ' in the DoWork event handler.
   Private Sub backgroundWorker1_RunWorkerCompleted( _
   sender As Object, e As RunWorkerCompletedEventArgs) _
   Handles backgroundWorker1.RunWorkerCompleted

      If e.Cancelled Then
         ' The user canceled the operation.
         MessageBox.Show("Operation was canceled")
      ElseIf (e.Error IsNot Nothing) Then
         ' There was an error during the operation.
         Dim msg As String = String.Format("An error occurred: {0}", e.Error.Message)
         MessageBox.Show(msg)
      Else
         ' The operation completed normally.
         Dim msg As String = String.Format("Result = {0}", e.Result)
         MessageBox.Show(msg)
      End If
   End Sub   
   ' </snippet3>

   ' <snippet4>
   ' This method models an operation that may take a long time 
   ' to run. It can be cancelled, it can raise an exception,
   ' or it can exit normally and return a result. These outcomes
   ' are chosen randomly.
   Private Function TimeConsumingOperation( _
   bw As BackgroundWorker, _
   sleepPeriod As Integer) As Integer

      Dim result As Integer = 0
      
      Dim rand As New Random()
      
        While Not bw.CancellationPending
            Dim [exit] As Boolean = False

            Select Case rand.Next(3)
                ' Raise an exception.
                Case 0
                    Throw New Exception("An error condition occurred.")
                    Exit While

                    ' Sleep for the number of milliseconds
                    ' specified by the sleepPeriod parameter.
                Case 1
                    Thread.Sleep(sleepPeriod)
                    Exit While

                    ' Exit and return normally.
                Case 2
                    result = 23
                    [exit] = True
                    Exit While

                Case Else
                    Exit While
            End Select

            If [exit] Then
                Exit While
            End If
        End While
      
      Return result
   End Function
   ' </snippet4>

   ' <snippet5>
    Private Sub startButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles startBtn.Click
        Me.backgroundWorker1.RunWorkerAsync(2000)
    End Sub
    ' </snippet5>

    ' <snippet6>
    Private Sub cancelButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cancelBtn.Click
        Me.backgroundWorker1.CancelAsync()
    End Sub
    ' </snippet6>

    ' <summary>
    ' Required designer variable.
    ' </summary>
    Private components As System.ComponentModel.IContainer = Nothing


    ' <summary>
    ' Clean up any resources being used.
    ' </summary>
    ' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub 'Dispose

#Region "Windows Form Designer generated code"


    ' <summary>
    ' Required method for Designer support - do not modify
    ' the contents of this method with the code editor.
    ' </summary>
    Private Sub InitializeComponent()
        Me.backgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.startBtn = New System.Windows.Forms.Button()
        Me.cancelBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        ' 
        ' backgroundWorker1
        ' 
        Me.backgroundWorker1.WorkerSupportsCancellation = True
        ' 
        ' startButton
        ' 
        Me.startBtn.Location = New System.Drawing.Point(12, 12)
        Me.startBtn.Name = "startButton"
        Me.startBtn.Size = New System.Drawing.Size(75, 23)
        Me.startBtn.TabIndex = 0
        Me.startBtn.Text = "Start"
        ' 
        ' cancelButton
        ' 
        Me.cancelBtn.Location = New System.Drawing.Point(94, 11)
        Me.cancelBtn.Name = "cancelButton"
        Me.cancelBtn.Size = New System.Drawing.Size(75, 23)
        Me.cancelBtn.TabIndex = 1
        Me.cancelBtn.Text = "Cancel"
        ' 
        ' Form1
        ' 
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(183, 49)
        Me.Controls.Add(cancelBtn)
        Me.Controls.Add(startBtn)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
    End Sub

#End Region

    Private WithEvents backgroundWorker1 As System.ComponentModel.BackgroundWorker
    Private WithEvents startBtn As System.Windows.Forms.Button
    Private WithEvents cancelBtn As System.Windows.Forms.Button
End Class 


Public Class Program

    Private Sub New()

    End Sub

    ' <summary>
    ' The main entry point for the application.
    ' </summary>
    <STAThread()> _
    Shared Sub Main()
        Application.EnableVisualStyles()
        Application.Run(New Form1())
    End Sub


End Class
' </snippet1>