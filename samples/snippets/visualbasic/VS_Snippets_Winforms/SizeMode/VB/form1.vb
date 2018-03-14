' <snippet1>
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Private tabControl1 As TabControl

    Public Sub New()
        Me.tabControl1 = New TabControl()
        Dim tabPage1 As New TabPage()
        Dim tabPage2 As New TabPage()
        Dim tabPage3 As New TabPage()
        Dim tabPage4 As New TabPage()
        Dim tabPage5 As New TabPage()

        ' Sizes the tabs so that each row fills the entire width of tabControl1.
        Me.tabControl1.SizeMode = TabSizeMode.FillToRight

        Me.tabControl1.Multiline = True
        Me.tabControl1.Padding = New Point(15, 5)
        Me.tabControl1.Controls.AddRange(New Control() {tabPage1, tabPage2, tabPage3, tabPage4, tabPage5})
        Me.tabControl1.Location = New Point(35, 25)
        Me.tabControl1.Size = New Size(220, 220)

        Me.Size = New Size(300, 300)
        Me.Controls.Add(tabControl1)
    End Sub

    Shared Sub Main()
        Application.Run(New Form1())
    End Sub
End Class
' </snippet1>
