' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.Text.RegularExpressions

Module Example
    Public Sub Main()
        Dim inputs() As String = {"Brooklyn Dodgers, National League, 1911, 1912, 1932-1957",
                              "Chicago Cubs, National League, 1903-present" + vbCrLf,
                              "Detroit Tigers, American League, 1901-present" + vbLf,
                              "New York Giants, National League, 1885-1957",
                              "Washington Senators, American League, 1901-1960" + vbCrLf}
        Dim pattern As String = "^((\w+(\s?)){2,}),\s(\w+\s\w+),(\s\d{4}(-(\d{4}|present))?,?)+\r?\Z"

        For Each input As String In inputs
            Console.WriteLine(Regex.Escape(input))
            Dim match As Match = Regex.Match(input, pattern)
            If match.Success Then
                Console.WriteLine("   Match succeeded.")
            Else
                Console.WriteLine("   Match failed.")
            End If
        Next
    End Sub
End Module
' The example displays the following output:
'    Brooklyn\ Dodgers,\ National\ League,\ 1911,\ 1912,\ 1932-1957
'       Match succeeded.
'    Chicago\ Cubs,\ National\ League,\ 1903-present\r\n
'       Match succeeded.
'    Detroit\ Tigers,\ American\ League,\ 1901-present\n
'       Match succeeded.
'    New\ York\ Giants,\ National\ League,\ 1885-1957
'       Match succeeded.
'    Washington\ Senators,\ American\ League,\ 1901-1960\r\n
'       Match succeeded.
' </Snippet4>
