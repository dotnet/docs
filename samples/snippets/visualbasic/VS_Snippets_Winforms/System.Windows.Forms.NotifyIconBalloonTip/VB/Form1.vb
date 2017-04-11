
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Class Form1
    Inherits Form
    '
    Public Sub New()
        InitializeComponent()
        SetBalloonTip()
        
    End Sub

    '<snippet1>
    Sub Form1_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) _
            Handles Me.DoubleClick

        notifyIcon1.Visible = True
        notifyIcon1.ShowBalloonTip(20000, "Information", "This is the text", _
                ToolTipIcon.Info)
    End Sub
    '</snippet1>

    '<snippet2>
    Private Sub SetBalloonTip()
        notifyIcon1.Icon = SystemIcons.Exclamation
        notifyIcon1.BalloonTipTitle = "Balloon Tip Title"
        notifyIcon1.BalloonTipText = "Balloon Tip Text."
        notifyIcon1.BalloonTipIcon = ToolTipIcon.Error

    End Sub

    Sub Form1_Click(ByVal sender As Object, ByVal e As EventArgs) _
        Handles Me.Click

        notifyIcon1.Visible = True
        notifyIcon1.ShowBalloonTip(30000)

    End Sub
    '</snippet2>

    '<snippet4>
    Sub notifyIcon1_BalloonTipClosed(ByVal sender As Object, _
        ByVal e As EventArgs) Handles notifyIcon1.BalloonTipClosed

        MessageBox.Show("The balloon tip is now closed.")

    End Sub
    '</snippet4>


    '/ <summary>
    '/ Required designer variable.
    '/ </summary>
    Private components As System.ComponentModel.IContainer = Nothing


    '/ <summary>
    '/ Clean up any resources being used.
    '/ </summary>
    '/ <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)

    End Sub 'Dispose

#Region "Windows Form Designer generated code"


    '/ <summary>
    '/ Required method for Designer support - do not modify
    '/ the contents of this method with the code editor.
    '/ </summary>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.notifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)

        Me.SuspendLayout()
        ' 
        ' notifyIcon1
        ' 
        Me.notifyIcon1.Visible = True
        ' 
        ' 
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub 'InitializeComponent 

#End Region

    Private WithEvents notifyIcon1 As System.Windows.Forms.NotifyIcon


    <STAThread()> _
    Shared Sub Main()
        Application.EnableVisualStyles()
        Application.Run(New Form1())

    End Sub
End Class
