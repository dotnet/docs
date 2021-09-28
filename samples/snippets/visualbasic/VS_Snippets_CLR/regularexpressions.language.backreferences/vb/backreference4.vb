' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.Text.RegularExpressions

Module Example
    Public Sub Main()
        Dim pattern As String = "(?<1>a)(?<1>\1b)*"
        Dim input As String = "aababb"
        For Each match As Match In Regex.Matches(input, pattern)
            Console.WriteLine("Match: " + match.Value)
            For Each group As Group In match.Groups
                Console.WriteLIne("   Group: " + group.Value)
            Next
        Next
    End Sub
End Module
' The example display the following output:
'          Group: aababb
'          Group: abb
' </Snippet4>
