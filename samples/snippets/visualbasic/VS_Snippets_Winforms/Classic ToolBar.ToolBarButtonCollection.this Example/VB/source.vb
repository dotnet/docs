Imports System
Imports System.Data
Imports System.Diagnostics
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected toolBar1 As ToolBar
    
' <Snippet1>
    Public Sub ReplaceMyToolBarButton()
        Dim btns As Integer
        btns = toolBar1.Buttons.Count
        Dim toolBarButton1 As New ToolBarButton()
        toolBarButton1.Text = "myButton"
        
        ' Replace the last ToolBarButton in the collection.
        toolBar1.Buttons(btns - 1) = toolBarButton1
    End Sub

' </Snippet1>
End Class

