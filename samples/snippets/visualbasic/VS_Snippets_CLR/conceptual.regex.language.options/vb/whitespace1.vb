' Visual Basic .NET Document
Option Strict On

' <Snippet12>
Imports System.Text.RegularExpressions

Module Whitespace1Example
    Public Sub Main()
        Dim input As String = "This is the first sentence. Is it the beginning " +
                              "of a literary masterpiece? I think not. Instead, " +
                              "it is a nonsensical paragraph."
        Dim pattern As String = "\b \(? ( (?>\w+) ,?\s? )+  [\.!?] \)? # Matches an entire sentence."

        For Each match As Match In Regex.Matches(input, pattern, RegexOptions.IgnorePatternWhitespace)
            Console.WriteLine(match.Value)
        Next
    End Sub
End Module
' The example displays the following output:
'       This is the first sentence.
'       Is it the beginning of a literary masterpiece?
'       I think not.
'       Instead, it is a nonsensical paragraph.
' </Snippet12>
