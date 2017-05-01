Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected menuItem1 As MenuItem
    
' <Snippet1>
 Public Sub CreateMyMenus()
     ' Create an instance of a MenuItem with a specified caption.
     menuItem1 = New MenuItem("&File")
 End Sub

' </Snippet1>
End Class

