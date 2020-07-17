' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet8>
Imports System.Text.RegularExpressions

Module Example
    Public Sub Main()
        Dim input As String = "This is one sentence. This is another."
        Dim pattern As String = "\b(\w+[;,]?\s?)+[.?!]"

        For Each match As Match In Regex.Matches(input, pattern)
            Console.WriteLine("Match: '{0}' at index {1}.",
                              match.Value, match.Index)
            Dim grpCtr As Integer = 0
            For Each grp As Group In match.Groups
                Console.WriteLine("   Group {0}: '{1}' at index {2}.",
                                  grpCtr, grp.Value, grp.Index)
                Dim capCtr As Integer = 0
                For Each cap As Capture In grp.Captures
                    Console.WriteLine("      Capture {0}: '{1}' at {2}.",
                                      capCtr, cap.Value, cap.Index)
                    capCtr += 1
                Next
                grpCtr += 1
            Next
            Console.WriteLine()
        Next
    End Sub
End Module
' The example displays the following output:
'       Match: 'This is one sentence.' at index 0.
'          Group 0: 'This is one sentence.' at index 0.
'             Capture 0: 'This is one sentence.' at 0.
'          Group 1: 'sentence' at index 12.
'             Capture 0: 'This ' at 0.
'             Capture 1: 'is ' at 5.
'             Capture 2: 'one ' at 8.
'             Capture 3: 'sentence' at 12.
'       
'       Match: 'This is another.' at index 22.
'          Group 0: 'This is another.' at index 22.
'             Capture 0: 'This is another.' at 22.
'          Group 1: 'another' at index 30.
'             Capture 0: 'This ' at 22.
'             Capture 1: 'is ' at 27.
'             Capture 2: 'another' at 30.
' </Snippet8>
