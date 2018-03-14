Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected menuItem1 As MenuItem
    Protected menuItem2 As MenuItem
    
' <Snippet1>
 Public Sub SwitchMyMenuItems()
     ' Move menuItem1 down one position in the menu order.
     menuItem1.Index = menuItem1.Index + 1
     ' Move menuItem2 up one position in the menu order.
     menuItem2.Index = menuItem2.Index - 1
 End Sub

' </Snippet1>
End Class

