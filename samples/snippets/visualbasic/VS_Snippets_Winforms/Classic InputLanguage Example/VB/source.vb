Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms
Imports Microsoft.VisualBasic


Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
    ' <Snippet1>
    Public Sub GetLanguages()
        ' Gets the list of installed languages.
        Dim lang As InputLanguage
        For Each lang In  InputLanguage.InstalledInputLanguages
            textBox1.Text &= lang.Culture.EnglishName & ControlChars.Cr
        Next lang
    End Sub 'GetLanguages
    
    ' </Snippet1>
    ' <Snippet2>
    Public Sub SetNewCurrentLanguage()
        ' Gets the default, and current languages.
        Dim myDefaultLanguage As InputLanguage = InputLanguage.DefaultInputLanguage
        Dim myCurrentLanguage As InputLanguage = InputLanguage.CurrentInputLanguage
        textBox1.Text = "Current input language is: " & _
            myCurrentLanguage.Culture.EnglishName & ControlChars.Cr
            
        textBox1.Text &= "Default input language is: " & _
            myDefaultLanguage.Culture.EnglishName & ControlChars.Cr
        
        ' Changes the current input language to the default, and prints the new current language.
        InputLanguage.CurrentInputLanguage = myDefaultLanguage
        textBox1.Text &= "Current input language is now: " & _
            myDefaultLanguage.Culture.EnglishName
    End Sub 'SetNewCurrentLanguage
    ' </Snippet2>
End Class 'Form1 
