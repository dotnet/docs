' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet21>
Imports System.Text.RegularExpressions

Module Ecma2Example
    Dim pattern As String

    Public Sub Main()
        Dim input As String = "aa aaaa aaaaaa "
        pattern = "((a+)(\1) ?)+"

        ' Match input using canonical matching.
        AnalyzeMatch(Regex.Match(input, pattern))

        ' Match input using ECMAScript.
        AnalyzeMatch(Regex.Match(input, pattern, RegexOptions.ECMAScript))
    End Sub

    Private Sub AnalyzeMatch(m As Match)
        If m.Success Then
            Console.WriteLine("'{0}' matches {1} at position {2}.",
                              pattern, m.Value, m.Index)
            Dim grpCtr As Integer = 0
            For Each grp As Group In m.Groups
                Console.WriteLine("   {0}: '{1}'", grpCtr, grp.Value)
                grpCtr += 1
                Dim capCtr As Integer = 0
                For Each cap As Capture In grp.Captures
                    Console.WriteLine("      {0}: '{1}'", capCtr, cap.Value)
                    capCtr += 1
                Next
            Next
        Else
            Console.WriteLine("No match found.")
        End If
        Console.WriteLine()
    End Sub
End Module
' The example displays the following output:
'    No match found.
'    
'    '((a+)(\1) ?)+' matches aa aaaa aaaaaa  at position 0.
'       0: 'aa aaaa aaaaaa '
'          0: 'aa aaaa aaaaaa '
'       1: 'aaaaaa '
'          0: 'aa '
'          1: 'aaaa '
'          2: 'aaaaaa '
'       2: 'aa'
'          0: 'aa'
'          1: 'aa'
'          2: 'aa'
'       3: 'aaaa '
'          0: ''
'          1: 'aa '
'          2: 'aaaa '
' </Snippet21>
