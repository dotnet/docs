Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected mainMenu1 As MainMenu
    
' <Snippet1>
 Public Sub CloneMyMenu()
     ' Determine if mainMenu1 is currently hosted on the form.
     If (mainMenu1.GetForm() IsNot Nothing) Then
         ' Create a copy of the MainMenu that is hosted on the form.
         Dim mainMenu2 As MainMenu = mainMenu1.CloneMenu()
         ' Set the RightToLeft property for mainMenu2.
         mainMenu2.RightToLeft = RightToLeft.Yes
     End If
 End Sub

' </Snippet1>
End Class

