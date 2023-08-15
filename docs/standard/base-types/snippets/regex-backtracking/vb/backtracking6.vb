' Visual Basic .NET Document
Option Strict On

' <Snippet6>
Imports System.Text.RegularExpressions

Module Example6
    Public Sub Run()
        Dim input As String = "aaaaaaaaaaaaaaaaaaaaaa."
        Dim result As Boolean
        Dim sw As Stopwatch

        Dim pattern As String = "^(([A-Z]\w*)+\.)*[A-Z]\w*$"
        sw = Stopwatch.StartNew()
        result = Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase)
        sw.Stop()
        Console.WriteLine("{0} in {1}", result, sw.Elapsed)

        Dim aheadPattern As String = "^((?=[A-Z])\w+\.)*[A-Z]\w*$"
        sw = Stopwatch.StartNew()
        result = Regex.IsMatch(input, aheadPattern, RegexOptions.IgnoreCase)
        sw.Stop()
        Console.WriteLine("{0} in {1}", result, sw.Elapsed)
    End Sub
End Module
' The example displays the following output:
'       False in 00:00:03.8003793
'       False in 00:00:00.0000866
' </Snippet6>
