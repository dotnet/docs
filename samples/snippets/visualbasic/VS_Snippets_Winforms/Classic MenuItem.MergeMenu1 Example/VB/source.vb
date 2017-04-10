Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected menuItem1 As MenuItem
    Protected menuItem2 As MenuItem
    Protected contextMenu1 As ContextMenu
    
' <Snippet1>
 Private Sub MergeMyMenus()
     ' Set the merge type to merge the items from both top menu items.
     menuItem1.MergeType = MenuMerge.MergeItems
     menuItem2.MergeType = MenuMerge.MergeItems
     ' Create a copy of my menu item.
     Dim tempMenuItem As New MenuItem()
     ' Create a copy of menuItem1 before doing the merge.
     tempMenuItem = menuItem1.CloneMenu()
     ' Merge menuItem1's copy with a clone of menuItem2
     tempMenuItem.MergeMenu(menuItem2.CloneMenu())
        
     ' Add the merged menu to the ContextMenu control.
     contextMenu1.MenuItems.Add(tempMenuItem)
 End Sub

' </Snippet1>
End Class 

