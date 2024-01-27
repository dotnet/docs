' Visual Basic .NET Document
Option Strict On

Imports System.Collections.Generic
Imports System.Runtime.CompilerServices

Public Module Library1
    <Extension()>
    Public Function FindOccurrences(s As String, f As String) As Integer()
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

            ' <Snippet8>
            Throw New ArgumentNullException("You must supply a search string.",
                                         e)
            ' </Snippet8>
        End Try
        Return indexes.ToArray()
    End Function
End Module

Module Example4
    Public Sub Main()
        Dim s As String = "It was a cold day when..."
        Dim indexes() As Integer = s.FindOccurrences("a")
        ShowOccurrences(s, "a", indexes)
        Console.WriteLine()

        Dim toFind As String = Nothing
        ' <Snippet9>
        Try
            indexes = s.FindOccurrences(toFind)
            ShowOccurrences(s, toFind, indexes)
        Catch e As ArgumentNullException
            Console.WriteLine("An exception ({0}) occurred.",
                           e.GetType().Name)
            Console.WriteLine("   Message: {1}{0}", vbCrLf, e.Message)
            Console.WriteLine("   Stack Trace:{0}   {1}{0}", vbCrLf, e.StackTrace)
            Dim ie As Exception = e.InnerException
            If ie IsNot Nothing Then
                Console.WriteLine("   The Inner Exception:")
                Console.WriteLine("      Exception Name: {0}", ie.GetType().Name)
                Console.WriteLine("      Message: {1}{0}", vbCrLf, ie.Message)
                Console.WriteLine("      Stack Trace:{0}   {1}{0}", vbCrLf, ie.StackTrace)
            End If
        End Try
        ' The example displays the following output:
        '       'a' occurs at the following character positions: 4, 7, 15
        '
        '       An exception (ArgumentNullException) occurred.
        '          Message: You must supply a search string.
        '
        '          Stack Trace:
        '             at Library.FindOccurrences(String s, String f)
        '          at Example.Main()
        '
        '          The Inner Exception:
        '             Exception Name: ArgumentNullException
        '             Message: Value cannot be null.
        '       Parameter name: value
        '
        '             Stack Trace:
        '             at System.String.IndexOf(String value, Int32 startIndex, Int32 count, Stri
        '       ngComparison comparisonType)
        '          at Library.FindOccurrences(String s, String f)
        ' </Snippet9>
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
