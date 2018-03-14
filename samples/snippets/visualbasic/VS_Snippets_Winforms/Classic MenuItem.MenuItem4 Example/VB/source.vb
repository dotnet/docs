Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
' <Snippet1>
 Public Sub CreateMyMenuItem()
     ' submenu item array.
     Dim subMenus(3) As MenuItem
     ' Create three menu items to add to the submenu item array.
     Dim subMenuItem1 As New MenuItem("Red")
     Dim subMenuItem2 As New MenuItem("Blue")
     Dim subMenuItem3 As New MenuItem("Green")
     ' Add the submenu items to the array.
     subMenus(0) = subMenuItem1
     subMenus(1) = subMenuItem2
     subMenus(2) = subMenuItem3
     ' Create an instance of a MenuItem with caption and an array of submenu
     ' items specified.
     Dim MenuItem1 As New MenuItem("&Colors", subMenus)
 End Sub
' </Snippet1>
End Class

