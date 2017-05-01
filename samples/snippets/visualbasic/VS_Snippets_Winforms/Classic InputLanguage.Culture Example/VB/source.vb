Imports System
Imports System.Data
Imports System.Globalization
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
' <Snippet1>
 Public Sub MyCulture()
    ' Gets the current input language.
    Dim myCurrentLanguage As InputLanguage = InputLanguage.CurrentInputLanguage
        
    ' Gets the culture for the language  and prints it.
    Dim myCultureInfo As CultureInfo = myCurrentLanguage.Culture
    textBox1.Text = myCultureInfo.EnglishName
 End Sub

' </Snippet1>
End Class

