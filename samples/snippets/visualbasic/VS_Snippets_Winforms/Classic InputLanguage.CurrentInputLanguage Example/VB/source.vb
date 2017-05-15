Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
' <Snippet1>
 Public Sub MyCurrentInputLanguage()
    ' Gets the current input language  and prints it in a text box.
    Dim myCurrentLanguage As InputLanguage = InputLanguage.CurrentInputLanguage
    textBox1.Text = "Current input language is: " & _
        myCurrentLanguage.Culture.EnglishName
 End Sub

' </Snippet1>
End Class

