' Visual Basic .NET Document
Option Strict On

' <Snippet11>
Imports System.Text.RegularExpressions

Module Explicit3Example
    Public Sub Main()
        Dim input As String = "This is the first sentence. Is it the beginning " +
                              "of a literary masterpiece? I think not. Instead, " +
                              "it is a nonsensical paragraph."
        Dim pattern As String = "\b\(?(?n:(?>\w+),?\s?)+[\.!?]\)?"

        For Each match As Match In Regex.Matches(input, pattern)
            Console.WriteLine("The match: {0}", match.Value)
            Dim groupCtr As Integer = 0
            For Each group As Group In match.Groups
                Console.WriteLine("   Group {0}: {1}", groupCtr, group.Value)
                groupCtr += 1
                Dim captureCtr As Integer = 0
                For Each capture As Capture In group.Captures
                    Console.WriteLine("      Capture {0}: {1}", captureCtr, capture.Value)
                    captureCtr += 1
                Next
            Next
        Next
    End Sub
End Module
' The example displays the following output:
'       The match: This is the first sentence.
'          Group 0: This is the first sentence.
'             Capture 0: This is the first sentence.
'       The match: Is it the beginning of a literary masterpiece?
'          Group 0: Is it the beginning of a literary masterpiece?
'             Capture 0: Is it the beginning of a literary masterpiece?
'       The match: I think not.
'          Group 0: I think not.
'             Capture 0: I think not.
'       The match: Instead, it is a nonsensical paragraph.
'          Group 0: Instead, it is a nonsensical paragraph.
'             Capture 0: Instead, it is a nonsensical paragraph.
' </Snippet11>
