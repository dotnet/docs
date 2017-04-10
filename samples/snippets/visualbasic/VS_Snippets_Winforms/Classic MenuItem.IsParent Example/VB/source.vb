Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected menuItem2 As MenuItem
    
' <Snippet1>
 Public Sub DisableMyChildMenus()
     ' Determine if menuItem2 is a parent menu.
     If menuItem2.IsParent = True Then
         ' Loop through all the submenus.
         Dim i As Integer
         For i = 0 To menuItem2.MenuItems.Count - 1
             ' Disable all of the submenus of menuItem2.
             menuItem2.MenuItems(i).Enabled = False
         Next i
     End If
 End Sub

' </Snippet1>
End Class

