Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
' <Snippet1>
 Public Sub MyDefaultInputLanguage()
    ' Gets the default input language  and prints it in a text box.
    Dim myDefaultLanguage As InputLanguage = InputLanguage.DefaultInputLanguage
    textBox1.Text = "Default input language is: " & _
        myDefaultLanguage.Culture.EnglishName
 End Sub

' </Snippet1>
End Class

