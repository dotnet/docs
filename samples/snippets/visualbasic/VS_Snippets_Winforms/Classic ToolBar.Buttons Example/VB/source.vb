Imports System
Imports System.Data
Imports System.Diagnostics
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    
' <Snippet1>
    Public Sub InitializeMyToolBar()
        ' Create and initialize the ToolBarButton controls and ToolBar.
        Dim toolBar1 As New ToolBar()
        Dim toolBarButton1 As New ToolBarButton()
        Dim toolBarButton2 As New ToolBarButton()
        Dim toolBarButton3 As New ToolBarButton()
        
        ' Set the Text properties of the ToolBarButton controls.
        toolBarButton1.Text = "Open"
        toolBarButton2.Text = "Save"
        toolBarButton3.Text = "Print"
        
        ' Add the ToolBarButton controls to the ToolBar.
        toolBar1.Buttons.Add(toolBarButton1)
        toolBar1.Buttons.Add(toolBarButton2)
        toolBar1.Buttons.Add(toolBarButton3)
        
        ' Add the ToolBar to the Form.
        Controls.Add(toolBar1)
    End Sub

' </Snippet1>
End Class

