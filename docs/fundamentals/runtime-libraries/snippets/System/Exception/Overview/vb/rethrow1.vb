' Visual Basic .NET Document
Option Strict On

' <Snippet6>
Imports System.Collections.Generic
Imports System.Runtime.CompilerServices

Public Module Library
    <Extension()>
    Public Function FindOccurrences1(s As String, f As String) As Integer()
        Dim indexes As New List(Of Integer)
        Dim currentIndex As Integer = 0
        Try
            Do While currentIndex >= 0 And currentIndex < s.Length
                currentIndex = s.IndexOf(f, currentIndex)
                If currentIndex >= 0 Then
                    indexes.Add(currentIndex)
                    currentIndex += 1
                End If
            Loop
        Catch e As ArgumentNullException
            ' Perform some action here, such as logging this exception.

            Throw
        End Try
        Return indexes.ToArray()
    End Function
End Module
' </Snippet6>

' <Snippet7>
Module Example1
    Public Sub Main()
        Dim s As String = "It was a cold day when..."
        Dim indexes() As Integer = s.FindOccurrences1("a")
        ShowOccurrences(s, "a", indexes)
        Console.WriteLine()

        Dim toFind As String = Nothing
        Try
            indexes = s.FindOccurrences1(toFind)
            ShowOccurrences(s, toFind, indexes)
        Catch e As ArgumentNullException
            Console.WriteLine("An exception ({0}) occurred.",
                           e.GetType().Name)
            Console.WriteLine("Message:{0}   {1}{0}", vbCrLf, e.Message)
            Console.WriteLine("Stack Trace:{0}   {1}{0}", vbCrLf, e.StackTrace)
        End Try
    End Sub

    Private Sub ShowOccurrences(s As String, toFind As String, indexes As Integer())
        Console.Write("'{0}' occurs at the following character positions: ",
                    toFind)
        For ctr As Integer = 0 To indexes.Length - 1
            Console.Write("{0}{1}", indexes(ctr),
                       If(ctr = indexes.Length - 1, "", ", "))
        Next
        Console.WriteLine()
    End Sub
End Module
' The example displays the following output:
'    'a' occurs at the following character positions: 4, 7, 15
'
'    An exception (ArgumentNullException) occurred.
'    Message:
'       Value cannot be null.
'    Parameter name: value
'
'    Stack Trace:
'          at System.String.IndexOf(String value, Int32 startIndex, Int32 count, Stri
'    ngComparison comparisonType)
'       at Library.FindOccurrences(String s, String f)
'       at Example.Main()
' </Snippet7>

