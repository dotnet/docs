' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.Collections.Generic
Imports System.Text.RegularExpressions

Module Multiline2Example
    Public Sub Main()
        Dim scores As New SortedList(Of Integer, String)(New DescendingComparer(Of Integer)())

        Dim input As String = "Joe 164" + vbCrLf +
                              "Sam 208" + vbCrLf +
                              "Allison 211" + vbCrLf +
                              "Gwen 171" + vbCrLf
        Dim pattern As String = "(?m)^(\w+)\s(\d+)\r*$"

        For Each match As Match In Regex.Matches(input, pattern, RegexOptions.Multiline)
            scores.Add(CInt(match.Groups(2).Value), match.Groups(1).Value)
        Next
        ' List scores in descending order. 
        For Each score As KeyValuePair(Of Integer, String) In scores
            Console.WriteLine("{0}: {1}", score.Value, score.Key)
        Next
    End Sub
End Module

Public Class DescendingComparer(Of T) : Implements IComparer(Of T)
    Public Function Compare(x As T, y As T) As Integer _
           Implements IComparer(Of T).Compare
        Return Comparer(Of T).Default.Compare(x, y) * -1
    End Function
End Class
' The example displays the following output:
'    Allison: 211
'    Sam: 208
'    Gwen: 171
'    Joe: 164
' </Snippet4>
