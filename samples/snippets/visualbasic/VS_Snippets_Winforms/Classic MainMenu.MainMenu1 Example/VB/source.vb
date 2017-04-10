Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
' <Snippet1>
 Public Sub CreateMyMainMenu()
     ' Create two MenuItem objects and assign to array.
     Dim menuItem1 As New MenuItem()
     Dim menuItem2 As New MenuItem()
        
     menuItem1.Text = "&File"
     menuItem2.Text = "&Edit"
        
     ' Create a MainMenu and assign MenuItem objects.
     Dim mainMenu1 As New MainMenu(New MenuItem() {menuItem1, menuItem2})
        
     ' Bind the MainMenu to Form1.
     Menu = mainMenu1
 End Sub

' </Snippet1>
End Class

