' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.Text.RegularExpressions

Module Example4
    Public Sub Run()
        Dim input As String = "b51:4:1DB:9EE1:5:27d60:f44:D4:cd:E:5:0A5:4a:D24:41Ad:"
        Dim matched As Boolean
        Dim sw As Stopwatch

        Console.WriteLine("With backtracking:")
        Dim backPattern As String = "^(([0-9a-fA-F]{1,4}:)*([0-9a-fA-F]{1,4}))*(::)$"
        sw = Stopwatch.StartNew()
        matched = Regex.IsMatch(input, backPattern)
        sw.Stop()
        Console.WriteLine("Match: {0} in {1}", Regex.IsMatch(input, backPattern), sw.Elapsed)
        Console.WriteLine()

        Console.WriteLine("Without backtracking:")
        Dim noBackPattern As String = "^((?>[0-9a-fA-F]{1,4}:)*(?>[0-9a-fA-F]{1,4}))*(::)$"
        sw = Stopwatch.StartNew()
        matched = Regex.IsMatch(input, noBackPattern)
        sw.Stop()
        Console.WriteLine("Match: {0} in {1}", Regex.IsMatch(input, noBackPattern), sw.Elapsed)
    End Sub
End Module
' The example displays the following output:
'       With backtracking:
'       Match: False in 00:00:27.4282019
'       
'       Without backtracking:
'       Match: False in 00:00:00.0001391
' </Snippet4>
