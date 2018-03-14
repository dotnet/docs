Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
' <Snippet1>
 Public Sub CreateMyMenu()
     ' Create an empty menu item object.
     Dim menuItem1 As New MenuItem()
     ' Intialize the menu item using the parameterless version of the constructor.
     ' Set the caption of the menu item.
     menuItem1.Text = "&File"
 End Sub

' </Snippet1>
End Class

