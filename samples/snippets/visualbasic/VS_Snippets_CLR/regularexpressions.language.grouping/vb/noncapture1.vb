' Visual Basic .NET Document
Option Strict On

' <Snippet5>
Imports System.Text.RegularExpressions

Module Example
    Public Sub Main()
        Dim pattern As String = "(?:\b(?:\w+)\W*)+\."
        Dim input As String = "This is a short sentence."
        Dim match As Match = Regex.Match(input, pattern)
        Console.WriteLine("Match: {0}", match.Value)
        For ctr As Integer = 1 To match.Groups.Count - 1
            Console.WriteLine("   Group {0}: {1}", ctr, match.Groups(ctr).Value)
        Next
    End Sub
End Module
' The example displays the following output:
'       Match: This is a short sentence.
' </Snippet5>

