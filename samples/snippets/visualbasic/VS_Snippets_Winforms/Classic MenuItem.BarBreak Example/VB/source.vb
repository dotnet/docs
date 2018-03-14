Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
' <Snippet1>
 Public Sub CreateMyMenus()
     ' Create three top-level menu items.
     Dim menuItem1 As New MenuItem("&File")
     Dim menuItem2 As New MenuItem("&New")
     Dim menuItem3 As New MenuItem("&Open")
     ' Set the BarBreak property to display horizontally.
     menuItem2.BarBreak = True
     menuItem3.BarBreak = True
     ' Add menuItem2 and menuItem3 to the menuItem1's list of menu items.
     menuItem1.MenuItems.Add(menuItem2)
     menuItem1.MenuItems.Add(menuItem3)
 End Sub

' </Snippet1> 
End Class

