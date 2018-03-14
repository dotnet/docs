Imports System
Imports System.Data
Imports System.Diagnostics
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected toolBar1 As ToolBar
    
' <Snippet1>
    Public Sub AddMyButton()
        Dim toolBarButton1 As New ToolBarButton()
        toolBarButton1.Text = "Print"
        
        ' Add the new toolbar button to the toolbar.
        toolBar1.Buttons.Add(toolBarButton1)
    End Sub

' </Snippet1>
End Class

