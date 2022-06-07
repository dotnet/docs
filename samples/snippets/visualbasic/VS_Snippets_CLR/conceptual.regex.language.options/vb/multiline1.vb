' Visual Basic .NET Document
Option Strict On

' <Snippet3>
Imports System.Collections.Generic
Imports System.Text.RegularExpressions

Module Multiline1Example
    Public Sub Main()
        Dim scores As New SortedList(Of Integer, String)(New DescendingComparer1(Of Integer)())

        Dim input As String = "Joe 164" + vbCrLf +
                              "Sam 208" + vbCrLf +
                              "Allison 211" + vbCrLf +
                              "Gwen 171" + vbCrLf
        Dim pattern As String = "^(\w+)\s(\d+)$"
        Dim matched As Boolean = False

        Console.WriteLine("Without Multiline option:")
        For Each match As Match In Regex.Matches(input, pattern)
            scores.Add(CInt(match.Groups(2).Value), match.Groups(1).Value)
            matched = True
        Next
        If Not matched Then Console.WriteLine("   No matches.")
        Console.WriteLine()

        ' Redefine pattern to handle multiple lines.
        pattern = "^(\w+)\s(\d+)\r*$"
        Console.WriteLine("With multiline option:")
        For Each match As Match In Regex.Matches(input, pattern, RegexOptions.Multiline)
            scores.Add(CInt(match.Groups(2).Value), match.Groups(1).Value)
        Next
        ' List scores in descending order. 
        For Each score As KeyValuePair(Of Integer, String) In scores
            Console.WriteLine("{0}: {1}", score.Value, score.Key)
        Next
    End Sub
End Module

Public Class DescendingComparer1(Of T) : Implements IComparer(Of T)
    Public Function Compare(x As T, y As T) As Integer _
           Implements IComparer(Of T).Compare
        Return Comparer(Of T).Default.Compare(x, y) * -1
    End Function
End Class
' The example displays the following output:
'    Without Multiline option:
'       No matches.
'    
'    With multiline option:
'    Allison: 211
'    Sam: 208
'    Gwen: 171
'    Joe: 164
' </Snippet3>
