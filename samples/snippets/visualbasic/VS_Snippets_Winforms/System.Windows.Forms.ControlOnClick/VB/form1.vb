' This example demonstrates overriding the OnClick method of a 
' custom TextBox control.

Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form

    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub

    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As SingleClickTextBox

    Private Sub InitializeComponent()
        Me.TextBox1 = New TextBox
        Me.TextBox2 = New SingleClickTextBox
        Me.SuspendLayout()
        Me.TextBox1.Location = New System.Drawing.Point(40, 60)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Size = New System.Drawing.Size(150, 80)
        Me.TextBox1.Text = "This textbox requires a drag motion for selection."
        Me.TextBox1.Multiline = True
        Me.TextBox1.Select(0, 0)
        Me.SuspendLayout()
        Me.TextBox2.Location = New System.Drawing.Point(40, 150)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.TabIndex = 2
        Me.TextBox2.Size = New System.Drawing.Size(150, 80)
        Me.TextBox2.Text = "One click causes all text to be selected."
        Me.TextBox2.Multiline = True
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.TextBox2)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub

End Class

'<snippet1>
' This is a custom TextBox control that overrides the OnClick method
' to allow one-click selection of the text in the text box.

Public Class SingleClickTextBox
    Inherits TextBox

    Protected Overrides Sub OnClick(ByVal e As EventArgs)
        Me.SelectAll()
        MyBase.OnClick(e)
    End Sub


End Class
'</snippet1>

