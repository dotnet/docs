
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Inherits Form

    Public Sub New()
        Dim tabPage1 As TabPage = New TabPage()

        ' <snippet1>
        tabPage1.Controls.Add(New Button())
        ' </snippet1>

    End Sub

    Shared Sub Main()
        Application.Run(New Form1())
    End Sub
End Class
