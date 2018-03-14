Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    
' <Snippet1>
    Public Sub CreateMyPanel()
        Dim panel1 As New Panel()
        Dim textBox1 As New TextBox()
        Dim label1 As New Label()
        
        ' Initialize the Panel control.
        panel1.Location = New Point(56, 72)
        panel1.Size = New Size(264, 152)
        ' Set the Borderstyle for the Panel to three-dimensional.
        panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        
        ' Initialize the Label and TextBox controls.
        label1.Location = New Point(16, 16)
        label1.Text = "label1"
        label1.Size = New Size(104, 16)
        textBox1.Location = New Point(16, 32)
        textBox1.Text = ""
        textBox1.Size = New Size(152, 20)
        
        ' Add the Panel control to the form.
        Me.Controls.Add(panel1)
        ' Add the Label and TextBox controls to the Panel.
        panel1.Controls.Add(label1)
        panel1.Controls.Add(textBox1)
    End Sub

' </Snippet1>
End Class

