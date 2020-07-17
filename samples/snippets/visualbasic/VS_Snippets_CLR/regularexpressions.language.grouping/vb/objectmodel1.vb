' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.Text.RegularExpressions

Module Example
    Public Sub Main()
        Dim pattern As String = "(\b(\w+)\W+)+"
        Dim input As String = "This is a short sentence."
        Dim match As Match = Regex.Match(input, pattern)
        Console.WriteLine("Match: '{0}'", match.Value)
        For ctr As Integer = 1 To match.Groups.Count - 1
            Console.WriteLine("   Group {0}: '{1}'", ctr, match.Groups(ctr).Value)
            Dim capCtr As Integer = 0
            For Each capture As Capture In match.Groups(ctr).Captures
                Console.WriteLine("      Capture {0}: '{1}'", capCtr, capture.Value)
                capCtr += 1
            Next
        Next
    End Sub
End Module
' The example displays the following output:
'       Match: 'This is a short sentence.'
'          Group 1: 'sentence.'
'             Capture 0: 'This '
'             Capture 1: 'is '
'             Capture 2: 'a '
'             Capture 3: 'short '
'             Capture 4: 'sentence.'
'          Group 2: 'sentence'
'             Capture 0: 'This'
'             Capture 1: 'is'
'             Capture 2: 'a'
'             Capture 3: 'short'
'             Capture 4: 'sentence'
' </Snippet4>

