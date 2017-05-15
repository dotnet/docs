Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    
' <Snippet1>
 Public Sub CreateMyMenus()
     Dim menuItem1 As New MenuItem("&File")
     Dim menuItem2 As New MenuItem("&New")
     Dim menuItem3 As New MenuItem("&Open")
     ' Make menuItem2 the default menu item.
     menuItem2.DefaultItem = True
 End Sub

' </Snippet1>
End Class

