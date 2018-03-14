Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
' <Snippet1>
 Public Sub SelectMyString()
     ' Create a string to search for the word "fox".
     Dim searchString As String = "fox"
     ' Determine the starting location of the word "fox".
     Dim index As Integer = textBox1.Text.IndexOf(searchString, 16, 3)
     ' Determine if the word has been found and select it if it was.
     If index <> - 1 Then
         ' Select the string using the index and the length of the string.
         textBox1.Select(index, searchString.Length)
     End If
 End Sub

' </Snippet1>
End Class

