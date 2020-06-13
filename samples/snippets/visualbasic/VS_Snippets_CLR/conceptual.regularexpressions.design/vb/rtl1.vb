' Visual Basic .NET Document
Option Strict On

' <Snippet6>
Imports System.Text.RegularExpressions

Module Example
    Public Sub Main()
        Dim greedyPattern As String = ".+(\d+)\."
        Dim input As String = "This sentence ends with the number 107325."
        Dim match As Match

        ' Match from left-to-right using lazy quantifier .+?.
        match = Regex.Match(input, greedyPattern)
        If match.Success Then
            Console.WriteLine("Number at end of sentence (left-to-right): {0}",
                              match.Groups(1).Value)
        Else
            Console.WriteLine("{0} finds no match.", greedyPattern)
        End If

        ' Match from right-to-left using greedy quantifier .+.
        match = Regex.Match(input, greedyPattern, RegexOptions.RightToLeft)
        If match.Success Then
            Console.WriteLine("Number at end of sentence (right-to-left): {0}",
                              match.Groups(1).Value)
        Else
            Console.WriteLine("{0} finds no match.", greedyPattern)
        End If
    End Sub
End Module
' The example displays the following output:
'       Number at end of sentence (left-to-right): 5
'       Number at end of sentence (right-to-left): 107325
' </Snippet6>
