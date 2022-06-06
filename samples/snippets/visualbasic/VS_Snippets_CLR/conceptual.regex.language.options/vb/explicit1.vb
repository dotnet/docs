' Visual Basic .NET Document
Option Strict On

' <Snippet9>
Imports System.Text.RegularExpressions

Module Explicit1Example
    Public Sub Main()
        Dim input As String = "This is the first sentence. Is it the beginning " +
                              "of a literary masterpiece? I think not. Instead, " +
                              "it is a nonsensical paragraph."
        Dim pattern As String = "\b\(?((?>\w+),?\s?)+[\.!?]\)?"
        Console.WriteLine("With implicit captures:")
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
        Console.WriteLine()
        Console.WriteLine("With explicit captures only:")
        For Each match As Match In Regex.Matches(input, pattern, RegexOptions.ExplicitCapture)
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
'    With implicit captures:
'    The match: This is the first sentence.
'       Group 0: This is the first sentence.
'          Capture 0: This is the first sentence.
'       Group 1: sentence
'          Capture 0: This
'          Capture 1: is
'          Capture 2: the
'          Capture 3: first
'          Capture 4: sentence
'       Group 2: sentence
'          Capture 0: This
'          Capture 1: is
'          Capture 2: the
'          Capture 3: first
'          Capture 4: sentence
'    The match: Is it the beginning of a literary masterpiece?
'       Group 0: Is it the beginning of a literary masterpiece?
'          Capture 0: Is it the beginning of a literary masterpiece?
'       Group 1: masterpiece
'          Capture 0: Is
'          Capture 1: it
'          Capture 2: the
'          Capture 3: beginning
'          Capture 4: of
'          Capture 5: a
'          Capture 6: literary
'          Capture 7: masterpiece
'       Group 2: masterpiece
'          Capture 0: Is
'          Capture 1: it
'          Capture 2: the
'          Capture 3: beginning
'          Capture 4: of
'          Capture 5: a
'          Capture 6: literary
'          Capture 7: masterpiece
'    The match: I think not.
'       Group 0: I think not.
'          Capture 0: I think not.
'       Group 1: not
'          Capture 0: I
'          Capture 1: think
'          Capture 2: not
'       Group 2: not
'          Capture 0: I
'          Capture 1: think
'          Capture 2: not
'    The match: Instead, it is a nonsensical paragraph.
'       Group 0: Instead, it is a nonsensical paragraph.
'          Capture 0: Instead, it is a nonsensical paragraph.
'       Group 1: paragraph
'          Capture 0: Instead,
'          Capture 1: it
'          Capture 2: is
'          Capture 3: a
'          Capture 4: nonsensical
'          Capture 5: paragraph
'       Group 2: paragraph
'          Capture 0: Instead
'          Capture 1: it
'          Capture 2: is
'          Capture 3: a
'          Capture 4: nonsensical
'          Capture 5: paragraph
'    
'    With explicit captures only:
'    The match: This is the first sentence.
'       Group 0: This is the first sentence.
'          Capture 0: This is the first sentence.
'    The match: Is it the beginning of a literary masterpiece?
'       Group 0: Is it the beginning of a literary masterpiece?
'          Capture 0: Is it the beginning of a literary masterpiece?
'    The match: I think not.
'       Group 0: I think not.
'          Capture 0: I think not.
'    The match: Instead, it is a nonsensical paragraph.
'       Group 0: Instead, it is a nonsensical paragraph.
'          Capture 0: Instead, it is a nonsensical paragraph.
' </Snippet9>
