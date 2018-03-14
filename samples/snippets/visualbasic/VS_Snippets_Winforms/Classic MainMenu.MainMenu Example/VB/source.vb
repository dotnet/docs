Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
' <Snippet1>
 Public Sub CreateMyMainMenu()
     ' Create an empty MainMenu.
     Dim mainMenu1 As New MainMenu()
        
     Dim menuItem1 As New MenuItem()
     Dim menuItem2 As New MenuItem()
        
     menuItem1.Text = "File"
     menuItem2.Text = "Edit"
     ' Add two MenuItem objects to the MainMenu.
     mainMenu1.MenuItems.Add(menuItem1)
     mainMenu1.MenuItems.Add(menuItem2)
        
     ' Bind the MainMenu to Form1.
     Menu = mainMenu1
 End Sub

' </Snippet1>
End Class

