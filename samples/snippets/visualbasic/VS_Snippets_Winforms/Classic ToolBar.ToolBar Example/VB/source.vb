Imports System
Imports System.Data
Imports System.Diagnostics
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected toolBar1 As ToolBar
    
    Protected printDialog1 As PrintDialog
    Protected openFileDialog1 As OpenFileDialog
    Protected saveFileDialog1 As SaveFileDialog
        
' <Snippet1>
    Public Sub InitializeMyToolBar()
        ' Create and initialize the ToolBar and ToolBarButton controls.
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
        
        ' Add the event-handler delegate.
        AddHandler toolBar1.ButtonClick, AddressOf Me.toolBar1_ButtonClick
        
        ' Add the ToolBar to the Form.
        Controls.Add(toolBar1)
    End Sub    
    
    Private Sub toolBar1_ButtonClick(ByVal sender As Object, _
    ByVal e As ToolBarButtonClickEventArgs)

        ' Evaluate the Button property to determine which button was clicked.
        Select Case toolBar1.Buttons.IndexOf(e.Button)
            Case 0
                openFileDialog1.ShowDialog()
                ' Insert code to open the file.
            Case 1
                saveFileDialog1.ShowDialog()
                ' Insert code to save the file.
            Case 2
                printDialog1.ShowDialog()
                ' Insert code to print the file.
        End Select
    End Sub

' </Snippet1>
End Class
