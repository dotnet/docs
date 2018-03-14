'<snippet1>
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Public Class Form1
    Inherits Form

    Dim textBox1 As TextBox

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()

        Me.textBox1 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        ' 
        ' textBox1
        ' 
        Me.textBox1.AcceptsReturn = True
        Me.textBox1.AcceptsTab = True
        Me.textBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.textBox1.Multiline = True
        Me.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        ' 
        ' Form1
        ' 
        Me.ClientSize = New System.Drawing.Size(284, 264)
        Me.Controls.Add(Me.textBox1)
        Me.Text = "TextBox Example"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

End Class
'</snippet1>