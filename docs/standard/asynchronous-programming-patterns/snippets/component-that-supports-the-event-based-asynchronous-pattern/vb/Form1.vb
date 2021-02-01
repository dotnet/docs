' <snippet1>
Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form

    Sub New()

        InitializeComponent()

    End Sub

    ' <snippet2>
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    ' </snippet2>
    Friend WithEvents loadButton As System.Windows.Forms.Button
    Friend WithEvents cancelLoadButton As System.Windows.Forms.Button

    ' <snippet3>
    Private Sub loadButton_Click( _
        ByVal sender As System.Object, _
        ByVal e As System.EventArgs) _
        Handles loadButton.Click

        ' Replace with a real url.
        PictureBox1.LoadAsync("https://unsplash.com/photos/qhixfmpqN8s/download?force=true&w=1920")

    End Sub
    ' </snippet3>

    ' <snippet4>
    Private Sub cancelLoadButton_Click( _
        ByVal sender As System.Object, _
        ByVal e As System.EventArgs) _
        Handles cancelLoadButton.Click

        PictureBox1.CancelAsync()

    End Sub
    ' </snippet4>

    ' <snippet5>
    Private Sub PictureBox1_LoadCompleted( _
        ByVal sender As System.Object, _
        ByVal e As System.ComponentModel.AsyncCompletedEventArgs) _
        Handles PictureBox1.LoadCompleted

        If (e.Error IsNot Nothing) Then
            MessageBox.Show(e.Error.Message, "Load Error")
        ElseIf e.Cancelled Then
            MessageBox.Show("Load cancelled", "Canceled")
        Else
            MessageBox.Show("Load completed", "Completed")
        End If

    End Sub
    ' </snippet5>

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub


    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.loadButton = New System.Windows.Forms.Button
        Me.cancelLoadButton = New System.Windows.Forms.Button
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Location = New System.Drawing.Point(10, 10)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(311, 300)
        Me.PictureBox1.SizeMode = PictureBoxSizeMode.AutoSize.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'loadButton
        '
        Me.loadButton.Location = New System.Drawing.Point(87, 330)
        Me.loadButton.Name = "loadButton"
        Me.loadButton.Size = New System.Drawing.Size(75, 23)
        Me.loadButton.TabIndex = 1
        Me.loadButton.Text = "Load"
        '
        'cancelLoadButton
        '
        Me.cancelLoadButton.Location = New System.Drawing.Point(168, 330)
        Me.cancelLoadButton.Name = "cancelLoadButton"
        Me.cancelLoadButton.Size = New System.Drawing.Size(75, 23)
        Me.cancelLoadButton.TabIndex = 2
        Me.cancelLoadButton.Text = "Cancel"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(331, 385)
        Me.Controls.Add(Me.cancelLoadButton)
        Me.Controls.Add(Me.loadButton)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "Form1"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.Text = "Form1"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

End Class
' </snippet1>
