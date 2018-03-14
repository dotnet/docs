' <snippet1>
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Private tabControl1 As TabControl
    Private tabPage1 As TabPage
    Private tabPage2 As TabPage
    Private tabPage3 As TabPage
    Private label1 As Label

    Public Sub New()
        Me.tabControl1 = New TabControl()
        Me.tabPage1 = New TabPage()
        Me.tabPage2 = New TabPage()
        Me.tabPage3 = New TabPage()
        Me.label1 = New Label()

        Me.tabControl1.TabPages.AddRange(New TabPage() {tabPage1, tabPage2, tabPage3})
        Me.tabControl1.Location = New Point(25, 75)
        Me.tabControl1.Size = New Size(250, 200)

        ' Gets the number of TabPage objects in the tabControl1 controls collection.  
        Dim tabCount As Integer = tabControl1.TabPages.Count

        Me.label1.Location = New Point(25, 25)
        Me.label1.Size = New Size(250, 25)
        Me.label1.Text = "The TabControl below has " + tabCount.ToString() + _
            " TabPage objects in its controls collection."

        Me.ClientSize = New Size(300, 300)
        Me.Controls.AddRange(New Control() {tabControl1, label1})
    End Sub

    Shared Sub Main()
        Application.Run(New Form1())
    End Sub
End Class
' </snippet1>
