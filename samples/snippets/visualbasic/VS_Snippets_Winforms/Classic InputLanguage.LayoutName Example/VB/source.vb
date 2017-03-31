Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms


Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
' <Snippet1>
 Public Sub MyLayoutName()
    ' Gets the current input language.
    Dim myCurrentLanguage As InputLanguage = InputLanguage.CurrentInputLanguage
        
    If (myCurrentLanguage IsNot Nothing) Then
       textBox1.Text = "Layout: " & myCurrentLanguage.LayoutName
    Else
       textBox1.Text = "There is no current language"
    End If
 End Sub

' </Snippet1>
End Class
