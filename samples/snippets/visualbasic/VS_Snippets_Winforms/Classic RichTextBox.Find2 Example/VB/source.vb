Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected richTextBox1 As RichTextBox
    
' <Snippet1>
    Public Function FindMyText(text As String, start As Integer) As Integer
        ' Initialize the return value to false by default.
        Dim returnValue As Integer = - 1
        
        ' Ensure that a search string has been specified and a valid start point.
        If text.Length > 0 And start >= 0 Then
            ' Obtain the location of the search string in richTextBox1.
            Dim indexToText As Integer = richTextBox1.Find(text, start, _
                RichTextBoxFinds.MatchCase)
            ' Determine whether the text was found in richTextBox1.
            If indexToText >= 0 Then
                returnValue = indexToText
            End If
        End If
        
        Return returnValue
    End Function

' </Snippet1>
End Class

