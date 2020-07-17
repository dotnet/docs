' Visual Basic .NET Document
Option Strict On

' <Snippet5>
Imports System.Diagnostics
Imports System.IO
Imports System.Text.RegularExpressions

Module Example
    Public Sub Main()
        Dim pattern As String = "\b(\w+((\r?\n)|,?\s))*\w+[.?:;!]"
        Dim sw As Stopwatch
        Dim match As Match
        Dim ctr As Integer

        Dim inFile As New StreamReader(".\Dreiser_TheFinancier.txt")
        Dim input As String = inFile.ReadToEnd()
        inFile.Close()

        ' Read first ten sentences with interpreted regex.
        Console.WriteLine("10 Sentences with Interpreted Regex:")
        sw = Stopwatch.StartNew()
        Dim int10 As New Regex(pattern, RegexOptions.SingleLine)
        match = int10.Match(input)
        For ctr = 0 To 9
            If match.Success Then
                ' Do nothing with the match except get the next match.
                match = match.NextMatch()
            Else
                Exit For
            End If
        Next
        sw.Stop()
        Console.WriteLine("   {0} matches in {1}", ctr, sw.Elapsed)

        ' Read first ten sentences with compiled regex.
        Console.WriteLine("10 Sentences with Compiled Regex:")
        sw = Stopwatch.StartNew()
        Dim comp10 As New Regex(pattern,
                     RegexOptions.SingleLine Or RegexOptions.Compiled)
        match = comp10.Match(input)
        For ctr = 0 To 9
            If match.Success Then
                ' Do nothing with the match except get the next match.
                match = match.NextMatch()
            Else
                Exit For
            End If
        Next
        sw.Stop()
        Console.WriteLine("   {0} matches in {1}", ctr, sw.Elapsed)

        ' Read all sentences with interpreted regex.
        Console.WriteLine("All Sentences with Interpreted Regex:")
        sw = Stopwatch.StartNew()
        Dim intAll As New Regex(pattern, RegexOptions.SingleLine)
        match = intAll.Match(input)
        Dim matches As Integer = 0
        Do While match.Success
            matches += 1
            ' Do nothing with the match except get the next match.
            match = match.NextMatch()
        Loop
        sw.Stop()
        Console.WriteLine("   {0:N0} matches in {1}", matches, sw.Elapsed)

        ' Read all sentences with compiled regex.
        Console.WriteLine("All Sentences with Compiled Regex:")
        sw = Stopwatch.StartNew()
        Dim compAll As New Regex(pattern,
                       RegexOptions.SingleLine Or RegexOptions.Compiled)
        match = compAll.Match(input)
        matches = 0
        Do While match.Success
            matches += 1
            ' Do nothing with the match except get the next match.
            match = match.NextMatch()
        Loop
        sw.Stop()
        Console.WriteLine("   {0:N0} matches in {1}", matches, sw.Elapsed)
    End Sub
End Module
' The example displays output like the following:
'       10 Sentences with Interpreted Regex:
'          10 matches in 00:00:00.0047491
'       10 Sentences with Compiled Regex:
'          10 matches in 00:00:00.0141872
'       All Sentences with Interpreted Regex:
'          13,443 matches in 00:00:01.1929928
'       All Sentences with Compiled Regex:
'          13,443 matches in 00:00:00.7635869
'       
'       >compare1
'       10 Sentences with Interpreted Regex:
'          10 matches in 00:00:00.0046914
'       10 Sentences with Compiled Regex:
'          10 matches in 00:00:00.0143727
'       All Sentences with Interpreted Regex:
'          13,443 matches in 00:00:01.1514100
'       All Sentences with Compiled Regex:
'          13,443 matches in 00:00:00.7432921
' </Snippet5>
