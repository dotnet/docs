' This is kind of a ripoff of 'process_synchronizingobject.cs' for use as a znippet
' for the remarks section.

Imports System
Imports System.Diagnostics
Imports System.Windows.Forms

Namespace SynchronizingObjectTest
    Public Class SyncForm
        Inherits Form

        Private components As System.ComponentModel.Container = Nothing
        Private process1 As Process

        Public Sub New()
            InitializeComponent()
        End Sub

        Protected Overrides Overloads Sub Dispose(disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub 'Dispose

        Private Sub InitializeComponent()
            Me.button1 = new Button()
            Me.label1 = new Label()
            Me.SuspendLayout()
            '
            ' button1
            '
            Me.button1.Location = new System.Drawing.Point(20, 20)
            Me.button1.Name = "button1"
            Me.button1.Size = new System.Drawing.Size(160, 30)
            Me.button1.TabIndex = 0
            Me.button1.Text = "Click Me"
            AddHandler button1.Click, AddressOf button1_Click
            '
            ' textbox
            '
            Me.label1.Location = new System.Drawing.Point(20, 20)
            Me.label1.Name = "textbox1"
            Me.label1.Size = new System.Drawing.Size(160, 30)
            Me.label1.TabIndex = 1
            Me.label1.Text = "Waiting for the process 'notepad' to exit...."
            Me.label1.ForeColor = System.Drawing.Color.Red
            Me.label1.Visible = false
            '
            ' Form1
            '
            Me.AutoScaleBaseSize = new System.Drawing.Size(5, 13)
            Me.ClientSize = new System.Drawing.Size(200, 70)
            Me.Controls.Add(Me.button1)
            Me.Controls.Add(Me.label1)
            Me.Name = "SyncForm"
            Me.Text = "SyncForm"
            Me.ResumeLayout(false)
        End Sub

        <STAThread> _
        Shared Sub Main()
            Application.Run(new SyncForm())
        End Sub

        Private button1 As Button
        Private label1 As Label

        Private Sub button1_Click(sender As Object, e As EventArgs)
            Me.button1.Hide()
            Me.label1.Show()

            process1 = new Process()
            Dim process1StartInfo As new ProcessStartInfo("notepad")

            ' <Snippet2>
            Me.process1.StartInfo.Domain = ""
            Me.process1.StartInfo.LoadUserProfile = False
            Me.process1.StartInfo.Password = Nothing
            Me.process1.StartInfo.StandardErrorEncoding = Nothing
            Me.process1.StartInfo.StandardOutputEncoding = Nothing
            Me.process1.StartInfo.UserName = ""
            Me.process1.SynchronizingObject = Me
            ' </Snippet2>

            ' Set method handling the exited event to be called
            AddHandler process1.Exited, AddressOf TheProcessExited
            ' Set 'EnableRaisingEvents' to true, to raise 'Exited' event when process is terminated.
            process1.EnableRaisingEvents = True

            Me.Refresh()
            process1.StartInfo = process1StartInfo
            process1.Start()

            process1.WaitForExit()
            process1.Close()
        End Sub

        Private Sub TheProcessExited(source As Object, e As EventArgs)
            Me.label1.Hide()
            Me.button1.Show()
            MessageBox.Show("The process has exited.")
        End Sub
    End Class
End Namespace