' <snippet1>
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Private tabControl1 As TabControl
    Private tabPage1 As TabPage
    Private button1 As Button

    Public Sub New()
        Me.tabControl1 = New TabControl()
        Me.tabPage1 = New TabPage()
        Me.button1 = New Button()

        Me.tabControl1.TabPages.Add(tabPage1)
        Me.tabControl1.Location = New Point(25, 25)
        Me.tabControl1.Size = New Size(250, 250)

        ' Gets the controls collection for tabPage1.
        ' Adds button1 to this collection.
        Me.tabPage1.Controls.Add(button1)

        Me.button1.Text = "button1"
        Me.button1.Location = New Point(25, 25)

        Me.ClientSize = New Size(300, 300)
        Me.Controls.Add(tabControl1)
    End Sub

    Shared Sub Main()
        Application.Run(New Form1())
    End Sub
End Class
' </snippet1>