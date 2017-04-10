' <snippet1>
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Private tabControl1 As TabControl
    Private tabPage1 As TabPage

    Private Sub MyTabs()
        Me.tabControl1 = New TabControl()
        Dim tabPageName As String = "myTabPage"

        ' Constructs a TabPage with a TabPage.Text value.
        Me.tabPage1 = New TabPage(tabPageName)

        Me.tabControl1.Controls.Add(tabPage1)
        Me.tabControl1.Location = New Point(25, 25)
        Me.tabControl1.Size = New Size(250, 250)

        Me.ClientSize = New Size(300, 300)
        Me.Controls.Add(tabControl1)
    End Sub

    Public Sub New()
        MyTabs()
    End Sub

    Shared Sub Main()
        Application.Run(New Form1())
    End Sub
End Class
' </snippet1>