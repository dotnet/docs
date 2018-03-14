Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
' <Snippet1>
 Private Sub InitializeMyMainMenu()
     ' Create the MainMenu and the MenuItem to add.
     Dim mainMenu1 As New MainMenu()
     Dim menuItem1 As New MenuItem("&File")
        
     ' Use the MenuItems property to call the Add method
     ' to add the MenuItem to the MainMenu menu item collection. 
     mainMenu1.MenuItems.Add(menuItem1)
        
     ' Assign mainMenu1 to the form.
     Me.Menu = mainMenu1
 End Sub

' </Snippet1>
End Class

