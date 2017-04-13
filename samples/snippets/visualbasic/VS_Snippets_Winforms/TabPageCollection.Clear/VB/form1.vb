' <snippet1>
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Private tabControl1 As TabControl
    Private tabPage1 As TabPage
    Private tabPage2 As TabPage
    Private tabPage3 As TabPage

    Public Sub New()
        Me.tabControl1 = New TabControl()
        Me.tabPage1 = New TabPage("tabPage1")
        Me.tabPage2 = New TabPage("tabPage2")
        Me.tabPage3 = New TabPage("tabPage3")

        ' Populates the tabControl1 with three tab pages.
        Me.tabControl1.TabPages.AddRange(New TabPage() {tabPage1, tabPage2, tabPage3})

        ' Removes all the tab pages from tabControl1.
        Me.tabControl1.TabPages.Clear()

        ' Adds the tabPage1 back to tabControl1.
        Me.tabControl1.TabPages.Add(tabPage2)

        Me.tabControl1.Location = New Point(25, 25)
        Me.tabControl1.Size = New Size(250, 250)
        Me.ClientSize = New Size(300, 300)
        Me.Controls.Add(tabControl1)
    End Sub

    Shared Sub Main()
        Application.Run(New Form1())
    End Sub
End Class
' </snippet1>
