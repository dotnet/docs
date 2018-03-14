Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected menuItem1 As MenuItem
    Protected contextMenu1 As ContextMenu
    
' <Snippet1>
 Public Sub CloneMyMenu()
 
     ' Clone the menu item and add it to the collection for the shortcut menu.
     contextMenu1.MenuItems.Add(menuItem1.CloneMenu())
     
 End Sub

' </Snippet1>
End Class


