Imports System
Imports System.Data
Imports System.Diagnostics
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected toolBar1 As ToolBar
    
' <Snippet1>
    Public Sub RemoveMyButton()
        Dim btns As Integer
        btns = toolBar1.Buttons.Count
        
        ' Remove the last toolbar button.
        toolBar1.Buttons.RemoveAt(btns - 1)
    End Sub

' </Snippet1>
End Class

