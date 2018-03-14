' <snippet1>
Imports System.Windows.Forms

Public Class Form1
    Inherits Form

    Public Sub New()
        Dim tabText As String() = {"tabPage1", "tabPage2"}
        Dim tabControl1 As New TabControl()
        Dim tabPage1 As New TabPage(tabText(0))
        Dim tabPage2 As New TabPage(tabText(1))

        ' Sets the tabs to appear as buttons.
        tabControl1.Appearance = TabAppearance.Buttons

        tabControl1.Controls.AddRange(New TabPage() {tabPage1, tabPage2})
        Controls.Add(tabControl1)
    End Sub

    Shared Sub Main()
        Application.Run(New Form1())
    End Sub
End Class
' </snippet1>
