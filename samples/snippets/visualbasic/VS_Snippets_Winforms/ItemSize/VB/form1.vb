' <snippet1>
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Private tabControl1 As TabControl
    Private tabPage1 As TabPage
    Private tabPage2 As TabPage

    Public Sub New()
        Me.tabControl1 = New TabControl()
        Me.tabPage1 = New TabPage()
        Me.tabPage2 = New TabPage()

        ' Sizes the tabs of tabControl1.
        Me.tabControl1.ItemSize = New Size(90, 50)

        ' Makes the tab width definable. 
        Me.tabControl1.SizeMode = TabSizeMode.Fixed

        Me.tabControl1.Controls.AddRange(New Control() {tabPage1, tabPage2})
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