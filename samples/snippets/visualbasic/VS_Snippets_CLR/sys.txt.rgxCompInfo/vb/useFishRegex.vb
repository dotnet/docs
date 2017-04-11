'<snippet2>
' This code example demonstrates the RegexCompilationInfo constructor.
' Execute this code example after executing genFishRegex.exe.
' compile: vbc /r:FishRegex.dll useFishRegex.vb

Imports System.Reflection
Imports System.Text.RegularExpressions

Class UseFishRegEx
    Public Shared Sub Main() 
        ' Match against the following target string.
        Dim targetString As String = "One fish two fish red fish blue fish"
        Dim matchCount As Integer = 0
        Dim f As New MyApp.FishRegex()
        
        ' Display the target string.
        Console.WriteLine(vbLf & "Input string = """ & targetString & """")
        
        ' Display each match, capture group, capture, and match position.
        Dim m As Match
        For Each m In f.Matches(targetString)
            matchCount = matchCount + 1
            Console.WriteLine(vbLf & "Match(" & matchCount & ")")

            Dim i As Integer
            For i = 1 to 2
                Dim g As Group = m.Groups(i)
                Console.WriteLine("Group(" & i & ") = """ & g.ToString() & """")
                Dim cc As CaptureCollection = g.Captures
                Dim j As Integer
                For j = 0 To cc.Count-1
                    Dim c As Capture = cc(j)
                    System.Console.WriteLine("Capture(" & j & ") = """ & c.ToString() & _
                                             """, Position = " & c.Index)
                Next j
            Next i
        Next m
    End Sub 'Main
End Class 'UseFishRegEx

'
'This code example produces the following results:
'
'Input string = "One fish two fish red fish blue fish"
'
'Match(1)
'Group(1) = "One"
'Capture(0) = "One", Position = 0
'Group(2) = "fish"
'Capture(0) = "fish", Position = 4
'
'Match(2)
'Group(1) = "two"
'Capture(0) = "two", Position = 9
'Group(2) = "fish"
'Capture(0) = "fish", Position = 13
'
'Match(3)
'Group(1) = "red"
'Capture(0) = "red", Position = 18
'Group(2) = "fish"
'Capture(0) = "fish", Position = 22
'
'Match(4)
'Group(1) = "blue"
'Capture(0) = "blue", Position = 27
'Group(2) = "fish"
'Capture(0) = "fish", Position = 32
'
'</snippet2>
