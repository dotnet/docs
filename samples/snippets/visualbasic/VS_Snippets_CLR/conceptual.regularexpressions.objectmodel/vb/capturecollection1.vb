' Visual Basic .NET Document
Option Strict On

' <Snippet14>
Imports System.Text.RegularExpressions

Module Example
    Public Sub Main()
        Dim pattern As String = "((a(b))c)+"
        Dim input As STring = "abcabcabc"

        Dim match As Match = Regex.Match(input, pattern)
        If match.Success Then
            Console.WriteLine("Match: '{0}' at position {1}", _
                              match.Value, match.Index)
            Dim groups As GroupCollection = match.Groups
            For ctr As Integer = 0 To groups.Count - 1
                Console.WriteLine("   Group {0}: '{1}' at position {2}", _
                                  ctr, groups(ctr).Value, groups(ctr).Index)
                Dim captures As CaptureCollection = groups(ctr).Captures
                For ctr2 As Integer = 0 To captures.Count - 1
                    Console.WriteLine("      Capture {0}: '{1}' at position {2}", _
                                      ctr2, captures(ctr2).Value, captures(ctr2).Index)
                Next
            Next
        End If
    End Sub
End Module
' The example displays the following output:
'       Match: 'abcabcabc' at position 0
'          Group 0: 'abcabcabc' at position 0
'             Capture 0: 'abcabcabc' at position 0
'          Group 1: 'abc' at position 6
'             Capture 0: 'abc' at position 0
'             Capture 1: 'abc' at position 3
'             Capture 2: 'abc' at position 6
'          Group 2: 'ab' at position 6
'             Capture 0: 'ab' at position 0
'             Capture 1: 'ab' at position 3
'             Capture 2: 'ab' at position 6
'          Group 3: 'b' at position 7
'             Capture 0: 'b' at position 1
'             Capture 1: 'b' at position 4
'             Capture 2: 'b' at position 7
' </Snippet14>
