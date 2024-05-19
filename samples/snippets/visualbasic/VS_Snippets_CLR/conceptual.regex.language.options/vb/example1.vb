' Visual Basic .NET Document
Option Strict On

Imports System.Text.RegularExpressions

Module ShowOptionsExamples
    Public Sub Main()
        ShowOptionsArgument()
        Console.WriteLine("-----")
        ShowInlineOptions()
        Console.WriteLine("-----")
        ShowGroupOptions()
    End Sub

    Private Sub ShowOptionsArgument()
        ' <Snippet6>
        Dim pattern As String = "d \w+ \s"
        Dim input As String = "Dogs are decidedly good pets."
        Dim options As RegexOptions = RegexOptions.IgnoreCase Or RegexOptions.IgnorePatternWhitespace

        For Each match As Match In Regex.Matches(input, pattern, options)
            Console.WriteLine("'{0}' found at index {1}.", match.Value, match.Index)
        Next
        ' The example displays the following output:
        '    'Dogs ' found at index 0.
        '    'decidedly ' found at index 9.      
        ' </Snippet6>
    End Sub

    Private Sub ShowInlineOptions()
        ' <Snippet7>
        Dim pattern As String = "\b(?ix) d \w+ \s"
        Dim input As String = "Dogs are decidedly good pets."

        For Each match As Match In Regex.Matches(input, pattern)
            Console.WriteLine("'{0}' found at index {1}.", match.Value, match.Index)
        Next
        ' The example displays the following output:
        '    'Dogs ' found at index 0.
        '    'decidedly ' found at index 9.      
        ' </Snippet7>
    End Sub

    Private Sub ShowGroupOptions()
        ' <Snippet8>
        Dim pattern As String = "\b(?ix: d \w+)\s"
        Dim input As String = "Dogs are decidedly good pets."

        For Each match As Match In Regex.Matches(input, pattern)
            Console.WriteLine("'{0}' found at index {1}.", match.Value, match.Index)
        Next
        ' The example displays the following output:
        '    'Dogs ' found at index 0.
        '    'decidedly ' found at index 9.      
        ' </Snippet8>
    End Sub
End Module

