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
     ' Clone the existing MenuItem into the new MenuItem.
     Dim tempMenuItem As MenuItem = menuItem1.CloneMenu()
        
     ' Assign the cloned MenuItem to the ContextMenu.
     contextMenu1.MenuItems.Add(tempMenuItem)
 End Sub

' </Snippet1>
End Class

