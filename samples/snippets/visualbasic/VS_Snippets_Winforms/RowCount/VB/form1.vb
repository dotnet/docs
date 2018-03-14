' <snippet1>
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Inherits Form

    Public Sub New()
        Dim tabControl1 As New TabControl()
        Dim tabPage1 As New TabPage()
        Dim tabPage2 As New TabPage()
        Dim tabPage3 As New TabPage()
        Dim tabPage4 As New TabPage()
        Dim tabPage5 As New TabPage()
        Dim label1 As New Label()

        ' Allows multiple rows of tabs in the tabControl1 tab strip.
        tabControl1.Multiline = True

        tabControl1.SizeMode = TabSizeMode.FillToRight
        tabControl1.Padding = New Point(15, 5)
        tabControl1.Controls.AddRange(New Control() {tabPage1, tabPage2, tabPage3, tabPage4, tabPage5})
        tabControl1.Location = New Point(35, 65)
        tabControl1.Size = New Size(220, 180)

        ' Gets the number of rows currently in the tabControl1 tab strip.
        ' Assigns int value to the rows variable.
        Dim rows As Integer = tabControl1.RowCount

        label1.Text = "There are " + rows.ToString() + " rows of tabs in the tabControl1 tab strip."
        label1.Location = New Point(35, 25)
        label1.Size = New Size(220, 30)

        Size = New Size(300, 300)
        Controls.AddRange(New Control() {label1, tabControl1})
    End Sub

    Shared Sub Main()
        Application.Run(New Form1())
    End Sub
End Class
' </snippet1>
