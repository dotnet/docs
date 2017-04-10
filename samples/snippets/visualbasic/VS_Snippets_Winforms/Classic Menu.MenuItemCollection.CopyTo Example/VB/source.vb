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
 Private Sub CopyMyMenus()
     ' Create empty array to store MenuItem objects.
     Dim myItems(menuItem1.MenuItems.Count + menuItem2.MenuItems.Count) As MenuItem
        
     ' Copy elements of the first MenuItem collection to array.
     menuItem1.MenuItems.CopyTo(myItems, 0)
     ' Copy elements of the second MenuItem collection, after the first set.
     menuItem2.MenuItems.CopyTo(myItems, myItems.Length)
        
     ' Add the array to the menu item collection of the ContextMenu.
     contextMenu1.MenuItems.AddRange(myItems)
 End Sub

' </Snippet1>
End Class

