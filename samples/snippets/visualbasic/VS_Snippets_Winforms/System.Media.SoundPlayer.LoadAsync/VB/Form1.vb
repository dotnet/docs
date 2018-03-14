' <snippet1>
Imports System
Imports System.Media
Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form

    Friend WithEvents playSoundButton As System.Windows.Forms.Button
    Private WithEvents Player As New SoundPlayer

    Sub New()

        Me.InitializeComponent()

    End Sub

    Private Sub playSoundButton_Click( _
        ByVal sender As System.Object, _
        ByVal e As System.EventArgs) _
        Handles playSoundButton.Click

        ' Replace this file name with a valid file name.
        Me.Player.SoundLocation = "http://www.tailspintoys.com/sounds/stop.wav"
        Me.Player.LoadAsync()

    End Sub

    Private Sub Player_LoadCompleted( _
        ByVal sender As Object, _
        ByVal e As _
        System.ComponentModel.AsyncCompletedEventArgs) _
        Handles Player.LoadCompleted

        If Me.Player.IsLoadCompleted Then
            Me.Player.Play()
        End If

    End Sub

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
        Me.playSoundButton = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'playSoundButton
        '
        Me.playSoundButton.Location = New System.Drawing.Point(105, 107)
        Me.playSoundButton.Name = "playSoundButton"
        Me.playSoundButton.Size = New System.Drawing.Size(75, 23)
        Me.playSoundButton.TabIndex = 0
        Me.playSoundButton.Text = "Play Sound"
        Me.playSoundButton.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.Add(Me.playSoundButton)
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