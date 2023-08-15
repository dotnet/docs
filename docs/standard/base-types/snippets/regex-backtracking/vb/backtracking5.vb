' Visual Basic .NET Document
Option Strict On
Imports System.Text.RegularExpressions

' <Snippet5>
Module Example5
    Public Sub Run()
        Dim sw As Stopwatch
        Dim input As String = "test@contoso.com"
        Dim result As Boolean

        Dim pattern As String = "^[0-9A-Z]([-.\w]*[0-9A-Z])?@"
        sw = Stopwatch.StartNew()
        result = Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase)
        sw.Stop()
        Console.WriteLine("Match: {0} in {1}", result, sw.Elapsed)

        Dim behindPattern As String = "^[0-9A-Z][-.\w]*(?<=[0-9A-Z])@"
        sw = Stopwatch.StartNew()
        result = Regex.IsMatch(input, behindPattern, RegexOptions.IgnoreCase)
        sw.Stop()
        Console.WriteLine("Match with Lookbehind: {0} in {1}", result, sw.Elapsed)
    End Sub
End Module
' The example displays output similar to the following:
'       Match: True in 00:00:00.0017549
'       Match with Lookbehind: True in 00:00:00.0000659
' </Snippet5>
