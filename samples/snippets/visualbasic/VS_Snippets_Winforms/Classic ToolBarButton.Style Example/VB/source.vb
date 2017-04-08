Imports System
Imports System.Data
Imports System.Diagnostics
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected imageList1 As ImageList
    Protected contextMenu1 As ContextMenu
    Protected menuItem1 As MenuItem

    
' <Snippet1>
    Public Sub InitializeMyToolBar()
        ' Create the ToolBar, ToolBarButton controls, and menus.
        Dim toolBarButton1 As New ToolBarButton("Open")
        Dim toolBarButton2 As New ToolBarButton()
        Dim toolBarButton3 As New ToolBarButton()
        Dim toolBar1 As New ToolBar()
	Dim menuItem1 As New MenuItem("Print")
	Dim contextMenu1 As New ContextMenu(New MenuItem(){menuItem1})
        
        ' Add the ToolBarButton controls to the ToolBar.
        toolBar1.Buttons.Add(toolBarButton1)
        toolBar1.Buttons.Add(toolBarButton2)
        toolBar1.Buttons.Add(toolBarButton3)
        
        ' Assign an ImageList to the ToolBar and show ToolTips.
        toolBar1.ImageList = imageList1
        toolBar1.ShowToolTips = True
        
        ' Assign ImageIndex, ContextMenu, Text, ToolTip, and
        ' Style properties of the ToolBarButton controls. 
        toolBarButton2.Style = ToolBarButtonStyle.Separator
        toolBarButton3.Text = "Print"
        toolBarButton3.Style = ToolBarButtonStyle.DropDownButton
        toolBarButton3.ToolTipText = "Print"
        toolBarButton3.ImageIndex = 0
        toolBarButton3.DropDownMenu = contextMenu1
        
        ' Add the ToolBar to a form.
        Controls.Add(toolBar1)
    End Sub

' </Snippet1>
End Class

