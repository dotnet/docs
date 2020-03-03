' System.Diagnostics.Process.SynchronizingObject

'  The following example demonstrates the property 'SynchronizingObject'
'  of 'Process' class.
'
'  It starts a process 'mspaint.exe' on button click. 
'  It attaches 'MyProcessExited' method of 'MyButton' class as EventHandler to
'  'Exited' event of the process.

Imports System.Diagnostics
Imports System.Windows.Forms

Namespace process_SynchronizingObject

    Public Class Form1
        Inherits System.Windows.Forms.Form
        Private components As System.ComponentModel.Container = Nothing

        Public Sub New()
            InitializeComponent()
        End Sub

        Protected Overloads Overrides Sub Dispose(disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Sub InitializeComponent()
            Me.button1 = New process_SynchronizingObject.MyButton()
            Me.SuspendLayout()
            ' 
            ' button1
            ' 
            Me.button1.Location = New System.Drawing.Point(40, 80)
            Me.button1.Name = "button1"
            Me.button1.Size = New System.Drawing.Size(168, 32)
            Me.button1.TabIndex = 0
            Me.button1.Text = "Click Me"
            AddHandler button1.Click, AddressOf button1_Click
            ' 
            ' Form1
            ' 
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(292, 273)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.button1})
            Me.Name = "Form1"
            Me.Text = "Form1"
            Me.ResumeLayout(False)
        End Sub

        <STAThread()> Shared Sub Main()
            Application.Run(New Form1())
        End Sub

        ' <Snippet1>
        Private button1 As MyButton
        Private Sub button1_Click(sender As Object, e As EventArgs)
            Using myProcess As New Process()
                Dim myProcessStartInfo As New ProcessStartInfo("mspaint")
                myProcess.StartInfo = myProcessStartInfo
                myProcess.Start()
                AddHandler myProcess.Exited, AddressOf MyProcessExited
                ' Set 'EnableRaisingEvents' to true, to raise 'Exited' event when process is terminated.
                myProcess.EnableRaisingEvents = True
                ' Set method handling the exited event to be called  ;
                ' on the same thread on which MyButton was created.
                myProcess.SynchronizingObject = button1
                MessageBox.Show("Waiting for the process 'mspaint' to exit....")
                myProcess.WaitForExit()
            End Using
        End Sub

        Private Sub MyProcessExited(source As Object, e As EventArgs)
            MessageBox.Show("The process has exited.")
        End Sub
    End Class

    Public Class MyButton
        Inherits Button

    End Class
    ' </Snippet1>

End Namespace 'process_SynchronizingObject
