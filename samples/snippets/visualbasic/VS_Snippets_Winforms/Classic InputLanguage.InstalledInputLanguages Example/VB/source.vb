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
 End Sub

' </Snippet1>
End Class

