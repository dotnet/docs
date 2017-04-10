' <snippet1>
Imports System
Imports System.Media
Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form

    Private Player As New SoundPlayer

    Sub New()

        Me.InitializeComponent()

    End Sub

    Private Sub playLoopingButton_Click( _
        ByVal sender As System.Object, _
        ByVal e As System.EventArgs) _
        Handles playLoopingButton.Click

        Try
            ' Note: You may need to change the location specified based on
            ' the sounds loaded on your computer.
            Me.Player.SoundLocation = "C:\Windows\Media\chimes.wav"
            Me.Player.PlayLooping()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error playing sound")
        End Try

    End Sub

    Private Sub stopPlayingButton_Click( _
        ByVal sender As System.Object, _
        ByVal e As System.EventArgs) _
        Handles stopPlayingButton.Click

        Me.Player.Stop()

    End Sub

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    Friend WithEvents playLoopingButton As System.Windows.Forms.Button
    Friend WithEvents stopPlayingButton As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.playLoopingButton = New System.Windows.Forms.Button
        Me.stopPlayingButton = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'playLoopingButton
        '
        Me.playLoopingButton.Location = New System.Drawing.Point(12, 12)
        Me.playLoopingButton.Name = "playLoopingButton"
        Me.playLoopingButton.Size = New System.Drawing.Size(89, 23)
        Me.playLoopingButton.TabIndex = 0
        Me.playLoopingButton.Text = "Play Looping"
        Me.playLoopingButton.UseVisualStyleBackColor = True
        '
        'stopPlayingButton
        '
        Me.stopPlayingButton.Location = New System.Drawing.Point(107, 12)
        Me.stopPlayingButton.Name = "stopPlayingButton"
        Me.stopPlayingButton.Size = New System.Drawing.Size(75, 23)
        Me.stopPlayingButton.TabIndex = 1
        Me.stopPlayingButton.Text = "Stop"
        Me.stopPlayingButton.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(197, 52)
        Me.Controls.Add(Me.stopPlayingButton)
        Me.Controls.Add(Me.playLoopingButton)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    <STAThread()> _
    Shared Sub Main()
        Application.EnableVisualStyles()
        Application.Run(New Form1())
    End Sub

End Class
' </snippet1>