' Visual Basic .NET Document
Option Strict On

' <Snippet0>
Imports System.Text.RegularExpressions

Public Module Test

    Public Sub Main()
' <Snippet1>
        ' Define a regular expression for repeated words.
        Dim rx As New Regex("\b(?<word>\w+)\s+(\k<word>)\b", _
               RegexOptions.Compiled Or RegexOptions.IgnoreCase)
' </Snippet1>

        ' Define a test string.        
        Dim text As String = "The the quick brown fox  fox jumps over the lazy dog dog."
        
' <Snippet2>
        ' Find matches.
        Dim matches As MatchCollection = rx.Matches(text)
' </Snippet2>

' <Snippet3>
        ' Report the number of matches found.
        Console.WriteLine("{0} matches found in:", matches.Count)
        Console.WriteLine("   {0}", text)
' </Snippet3>

' <Snippet4>
        ' Report on each match.
        For Each match As Match In matches
            Dim groups As GroupCollection = match.Groups
            Console.WriteLine("'{0}' repeated at positions {1} and {2}", _ 
                              groups.Item("word").Value, _
                              groups.Item(0).Index, _
                              groups.Item(1).Index)
        Next
' </Snippet4>        
    End Sub
End Module
' The example produces the following output to the console:
'       3 matches found in:
'          The the quick brown fox  fox jumps over the lazy dog dog.
'       'The' repeated at positions 0 and 4
'       'fox' repeated at positions 20 and 25
'       'dog' repeated at positions 49 and 53
' </Snippet0>

