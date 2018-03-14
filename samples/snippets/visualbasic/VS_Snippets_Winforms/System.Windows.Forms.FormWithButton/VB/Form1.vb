'<snippet1>
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    '<snippet2>
    Public WithEvents button1 As Button

    Public Sub New()
        button1 = New Button()
        button1.Size = New Size(40, 40)
        button1.Location = New Point(30, 30)
        button1.Text = "Click me"
        Me.Controls.Add(button1)
       
    End Sub
    '</snippet2>
   
    '<snippet3>
    '<snippet4>
    Private Sub button1_Click(ByVal sender As Object, _
        ByVal e As EventArgs) Handles button1.Click
        '</snippet4>
        MessageBox.Show("Hello World")
    End Sub
    '</snippet3>

    <STAThread()> _
    Shared Sub Main()
        Application.EnableVisualStyles()
        Application.Run(New Form1())

    End Sub
End Class
'</snippet1>