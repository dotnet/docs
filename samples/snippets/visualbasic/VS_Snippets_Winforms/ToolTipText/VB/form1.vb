' <snippet1>
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Private tabControl1 As TabControl
    Private tabPage1 As TabPage
    Private tabPage2 As TabPage

    Private Sub MyTabs()
        Me.tabControl1 = New TabControl()
        Me.tabPage1 = New TabPage()
        Me.tabPage2 = New TabPage()

        Me.tabControl1.Controls.AddRange(New Control() {Me.tabPage1, Me.tabPage2})
        Me.tabControl1.Location = New Point(35, 25)
        Me.tabControl1.Size = New Size(220, 220)

        ' Shows ToolTipText when the mouse passes over tabs.
        Me.tabControl1.ShowToolTips = True

        ' Assigns string values to ToolTipText.
        Me.tabPage1.ToolTipText = "myTabPage1"
        Me.tabPage2.ToolTipText = "myTabPage2"

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