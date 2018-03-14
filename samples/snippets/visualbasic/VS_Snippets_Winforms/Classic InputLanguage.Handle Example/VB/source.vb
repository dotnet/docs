Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
' <Snippet1>
 Public Sub MyHandle()
    ' Gets the current input language.
    Dim myCurrentLanguage As InputLanguage = InputLanguage.CurrentInputLanguage
        
    ' Gets a handle for the language  and prints the number.
    Dim myHandle As IntPtr = myCurrentLanguage.Handle
    textBox1.Text = "The handle number is: " & myHandle.ToString()
 End Sub

' </Snippet1>
End Class

