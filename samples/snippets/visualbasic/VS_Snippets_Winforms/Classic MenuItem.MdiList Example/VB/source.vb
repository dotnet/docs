Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
' <Snippet1>
 Public Sub SetMDIList()
     ' Create the MenuItem to be used to display an MDI list.
     Dim menuItem1 As New MenuItem()
     ' Set this menu item to be used as an MDI list.
     menuItem1.MdiList = True
 End Sub

' </Snippet1>
End Class

