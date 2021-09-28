' Visual Basic .NET Document
Option Strict On

' <Snippet6>
Imports System.Text.RegularExpressions

Module Example
    Public Sub Main()
        Dim pattern As String = "\b\w+(?=\sis\b)"
        Dim inputs() As String = {"The dog is a Malamute.", _
                                   "The island has beautiful birds.", _
                                   "The pitch missed home plate.", _
                                   "Sunday is a weekend day."}

        For Each input As String In inputs
            Dim match As Match = Regex.Match(input, pattern)
            If match.Success Then
                Console.WriteLine("'{0}' precedes 'is'.", match.Value)
            Else
                Console.WriteLine("'{0}' does not match the pattern.", input)
            End If
        Next
    End Sub
End Module
' The example displays the following output:
'       'dog' precedes 'is'.
'       'The island has beautiful birds.' does not match the pattern.
'       'The pitch missed home plate.' does not match the pattern.
'       'Sunday' precedes 'is'.
' </Snippet6>
