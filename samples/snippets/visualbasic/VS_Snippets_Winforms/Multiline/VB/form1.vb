' <snippet1>
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Private tabControl1 As TabControl
    Private tabPage1 As TabPage
    Private tabPage2 As TabPage
    Private tabPage3 As TabPage
    Private tabPage4 As TabPage

    Private Sub MyTabs()
        Me.tabControl1 = New TabControl()
        Me.tabPage1 = New TabPage()
        Me.tabPage2 = New TabPage()
        Me.tabPage3 = New TabPage()
        Me.tabPage4 = New TabPage()

        ' Allows more than one row of tabs.
        Me.tabControl1.Multiline = True

        Me.tabControl1.Padding = New Point(22, 5)
        Me.tabControl1.Controls.AddRange(New Control() {Me.tabPage1, Me.tabPage2, Me.tabPage3, Me.tabPage4})
        Me.tabControl1.Location = New Point(35, 25)
        Me.tabControl1.Size = New Size(220, 220)

        Me.tabPage1.Text = "myTabPage1"
        Me.tabPage2.Text = "myTabPage2"
        Me.tabPage3.Text = "myTabPage3"
        Me.tabPage4.Text = "myTabPage4"

        Me.Size = New Size(300, 300)
        Me.Controls.AddRange(New Control() {Me.tabControl1})
    End Sub

    Public Sub New()
        MyTabs()
    End Sub

    Shared Sub Main()
        Application.Run(New Form1())
    End Sub
End Class
' </snippet1>