' <snippet1>
' <snippet2>
Imports System
Imports System.ComponentModel
Imports System.Threading
Imports System.Windows.Forms
' </snippet2>

Public Class Form1
   Inherits Form
   
   ' <snippet3>
   ' This delegate enables asynchronous calls for setting
   ' the text property on a TextBox control.
   Delegate Sub SetTextCallback([text] As String)
    ' </snippet3>

   ' <snippet4>
   ' This thread is used to demonstrate both thread-safe and
   ' unsafe ways to call a Windows Forms control.
   Private demoThread As Thread = Nothing
    ' </snippet4>

   ' <snippet5>
   ' This BackgroundWorker is used to demonstrate the 
   ' preferred way of performing asynchronous operations.
   Private WithEvents backgroundWorker1 As BackgroundWorker
    ' </snippet5>

   Private textBox1 As TextBox
   Private WithEvents setTextUnsafeBtn As Button
   Private WithEvents setTextSafeBtn As Button
   Private WithEvents setTextBackgroundWorkerBtn As Button
   
   Private components As System.ComponentModel.IContainer = Nothing
   
   
   Public Sub New()
      InitializeComponent()
    End Sub
   
   
   Protected Overrides Sub Dispose(disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
         components.Dispose()
      End If
      MyBase.Dispose(disposing)
    End Sub
   
   
   ' <snippet6>
   ' This event handler creates a thread that calls a 
   ' Windows Forms control in an unsafe way.
    Private Sub setTextUnsafeBtn_Click( _
    ByVal sender As Object, _
    ByVal e As EventArgs) Handles setTextUnsafeBtn.Click

        Me.demoThread = New Thread( _
        New ThreadStart(AddressOf Me.ThreadProcUnsafe))

        Me.demoThread.Start()
    End Sub
   
   
   ' This method is executed on the worker thread and makes
   ' an unsafe call on the TextBox control.
   Private Sub ThreadProcUnsafe()
      Me.textBox1.Text = "This text was set unsafely."
   End Sub 
    ' </snippet6>

   ' <snippet7>
   ' This event handler creates a thread that calls a 
   ' Windows Forms control in a thread-safe way.
    Private Sub setTextSafeBtn_Click( _
    ByVal sender As Object, _
    ByVal e As EventArgs) Handles setTextSafeBtn.Click

        Me.demoThread = New Thread( _
        New ThreadStart(AddressOf Me.ThreadProcSafe))

        Me.demoThread.Start()
    End Sub
   
   
   ' This method is executed on the worker thread and makes
   ' a thread-safe call on the TextBox control.
   Private Sub ThreadProcSafe()
      Me.SetText("This text was set safely.")
    End Sub
    ' </snippet7>

    ' <snippet8>
   ' This method demonstrates a pattern for making thread-safe
   ' calls on a Windows Forms control. 
   '
   ' If the calling thread is different from the thread that
   ' created the TextBox control, this method creates a
   ' SetTextCallback and calls itself asynchronously using the
   ' Invoke method.
   '
   ' If the calling thread is the same as the thread that created
    ' the TextBox control, the Text property is set directly. 

    Private Sub SetText(ByVal [text] As String)

        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Me.textBox1.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf SetText)
            Me.Invoke(d, New Object() {[text]})
        Else
            Me.textBox1.Text = [text]
        End If
    End Sub
    ' </snippet8>

   ' <snippet9>
   ' This event handler starts the form's 
   ' BackgroundWorker by calling RunWorkerAsync.
   '
   ' The Text property of the TextBox control is set
   ' when the BackgroundWorker raises the RunWorkerCompleted
   ' event.
    Private Sub setTextBackgroundWorkerBtn_Click( _
    ByVal sender As Object, _
    ByVal e As EventArgs) Handles setTextBackgroundWorkerBtn.Click
        Me.backgroundWorker1.RunWorkerAsync()
    End Sub
   
   
   ' This event handler sets the Text property of the TextBox
   ' control. It is called on the thread that created the 
   ' TextBox control, so the call is thread-safe.
   '
   ' BackgroundWorker is the preferred way to perform asynchronous
   ' operations.
    Private Sub backgroundWorker1_RunWorkerCompleted( _
    ByVal sender As Object, _
    ByVal e As RunWorkerCompletedEventArgs) _
    Handles backgroundWorker1.RunWorkerCompleted
        Me.textBox1.Text = _
        "This text was set safely by BackgroundWorker."
    End Sub
    ' </snippet9>

   #Region "Windows Form Designer generated code"
   
   
   Private Sub InitializeComponent()
      Me.textBox1 = New System.Windows.Forms.TextBox()
      Me.setTextUnsafeBtn = New System.Windows.Forms.Button()
      Me.setTextSafeBtn = New System.Windows.Forms.Button()
      Me.setTextBackgroundWorkerBtn = New System.Windows.Forms.Button()
      Me.backgroundWorker1 = New System.ComponentModel.BackgroundWorker()
      Me.SuspendLayout()
      ' 
      ' textBox1
      ' 
      Me.textBox1.Location = New System.Drawing.Point(12, 12)
      Me.textBox1.Name = "textBox1"
      Me.textBox1.Size = New System.Drawing.Size(240, 20)
      Me.textBox1.TabIndex = 0
      ' 
      ' setTextUnsafeBtn
      ' 
      Me.setTextUnsafeBtn.Location = New System.Drawing.Point(15, 55)
      Me.setTextUnsafeBtn.Name = "setTextUnsafeBtn"
      Me.setTextUnsafeBtn.TabIndex = 1
      Me.setTextUnsafeBtn.Text = "Unsafe Call"
      ' 
      ' setTextSafeBtn
      ' 
      Me.setTextSafeBtn.Location = New System.Drawing.Point(96, 55)
      Me.setTextSafeBtn.Name = "setTextSafeBtn"
      Me.setTextSafeBtn.TabIndex = 2
      Me.setTextSafeBtn.Text = "Safe Call"
      ' 
      ' setTextBackgroundWorkerBtn
      ' 
      Me.setTextBackgroundWorkerBtn.Location = New System.Drawing.Point(177, 55)
      Me.setTextBackgroundWorkerBtn.Name = "setTextBackgroundWorkerBtn"
      Me.setTextBackgroundWorkerBtn.TabIndex = 3
      Me.setTextBackgroundWorkerBtn.Text = "Safe BW Call"
      ' 
      ' backgroundWorker1
      ' 
      ' 
      ' Form1
      ' 
      Me.ClientSize = New System.Drawing.Size(268, 96)
      Me.Controls.Add(setTextBackgroundWorkerBtn)
      Me.Controls.Add(setTextSafeBtn)
      Me.Controls.Add(setTextUnsafeBtn)
      Me.Controls.Add(textBox1)
      Me.Name = "Form1"
      Me.Text = "Form1"
      Me.ResumeLayout(False)
      Me.PerformLayout()
   End Sub 'InitializeComponent 
   
   #End Region
   
   <STAThread()>  _
   Shared Sub Main()
      Application.EnableVisualStyles()
      Application.Run(New Form1())
    End Sub
End Class
' </snippet1>