Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected menuItem1 As MenuItem
    
' <Snippet1>
 Public Sub InitMyFileMenu()
     ' Set the MergeType to Add so that the menu item is added to the merged menu.
     menuItem1.MergeType = MenuMerge.Add
     ' Set the MergeOrder to 1 so that this menu item is placed lower in the merged menu order.
     menuItem1.MergeOrder = 1
 End Sub

' </Snippet1>
End Class

