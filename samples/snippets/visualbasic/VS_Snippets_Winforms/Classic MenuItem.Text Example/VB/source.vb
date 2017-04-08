Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected menuItem1 As MenuItem
    
' <Snippet1>
 Public Sub SetupMyMenuItem()
     ' Set the caption for the menu item.
     menuItem1.Text = "&New"
     ' Assign a shortcut key.
     menuItem1.Shortcut = Shortcut.CtrlN
     ' Make the menu item visible.
     menuItem1.Visible = True
     ' Display the shortcut key combination.
     menuItem1.ShowShortcut = True
 End Sub

' </Snippet1>
End Class

