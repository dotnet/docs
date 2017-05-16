Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
' <Snippet1>
 Public Sub SetNewCurrentLanguage()
    ' Gets the default, and current languages.
    Dim myDefaultLanguage As InputLanguage = InputLanguage.DefaultInputLanguage
    Dim myCurrentLanguage As InputLanguage = InputLanguage.CurrentInputLanguage
    textBox1.Text = "Current input language is: " & _
        myCurrentLanguage.Culture.EnglishName + ControlChars.Cr
    textBox1.Text &= "Default input language is: " & _
        myDefaultLanguage.Culture.EnglishName + ControlChars.Cr
        
    'Print the new current input language.
    Dim myCurrentLanguage2 As InputLanguage = InputLanguage.CurrentInputLanguage
    textBox1.Text &= "New current input language is: " & _
        myCurrentLanguage2.Culture.EnglishName
 End Sub

' </Snippet1>
End Class

