Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
' <Snippet1>
 Private Sub InitializeMyMainMenu()
     ' Create the MainMenu.
     Dim mainMenu1 As New MainMenu()
        
     ' Use the MenuItems property to call the Add method
     ' to add two new MenuItem objects to the MainMenu. 
     mainMenu1.MenuItems.Add("&File")
     mainMenu1.MenuItems.Add("&Edit")
        
     ' Assign mainMenu1 to the form.
     Me.Menu = mainMenu1
 End Sub

' </Snippet1> 
End Class

