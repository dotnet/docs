Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected richTextBox1 As RichTextBox
    
' <Snippet1>
    Public Function FindMyText(text As String) As Boolean
        ' Initialize the return value to false by default.
        Dim returnValue As Boolean = False
        
        ' Ensure a search string has been specified.
        If text.Length > 0 Then
            ' Obtain the location of the search string in richTextBox1.
            Dim indexToText As Integer = richTextBox1.Find(text, RichTextBoxFinds.MatchCase)
            ' Determine if the text was found in richTextBox1.
            If indexToText >= 0 Then
                returnValue = True
            End If
        End If
        
        Return returnValue
    End Function

' </Snippet1>
End Class

