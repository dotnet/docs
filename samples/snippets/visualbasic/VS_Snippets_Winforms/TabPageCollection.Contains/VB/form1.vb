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
        Dim tabText As String() = {"tabPage1", "tabPage2", "tabPage3"}
        Me.tabPage1 = New TabPage(tabText(0))
        Me.tabPage2 = New TabPage(tabText(1))
        Me.tabPage3 = New TabPage(tabText(2))

        ' Populates the tabControl1 with two tab pages.      
        Me.tabControl1.TabPages.AddRange(New TabPage() {tabPage1, tabPage2})

        ' Checks the tabControl1 controls collection for tabPage3.
        ' Adds tabPage3 to tabControl1 if it is not in the collection.
        If tabControl1.TabPages.Contains(tabPage3) = False Then
            Me.tabControl1.TabPages.Add(tabPage3)
        End If

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
