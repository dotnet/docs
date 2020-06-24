' Visual Basic .NET Document
Option Strict On

Imports System.Collections.Generic
Imports System.Runtime.CompilerServices

' <Snippet3>
Module Example
    Public Sub Main()
        Dim dbl As Double = 0.0 - Double.Epsilon
        Console.WriteLine(NumericLib.NearZero(dbl))

        Dim s As String = "war and peace"
        Console.WriteLine(s.ToTitleCase())
    End Sub
End Module
' The example displays the following output:
'       True
'       War and Peace
' </Snippet3>

Public Module StringLib
    Private exclusions As List(Of String)

    Sub New()
        Dim words() As String = {"a", "an", "and", "of", "the"}
        exclusions = New List(Of String)
        exclusions.AddRange(words)
    End Sub

    <Extension()> _
    Public Function ToTitleCase(title As String) As String
        Dim words() As String = title.Split()
        Dim result As String = String.Empty

        For ctr As Integer = 0 To words.Length - 1
            Dim word As String = words(ctr)
            If ctr = 0 OrElse Not exclusions.Contains(word.ToLower()) Then
                result += word.Substring(0, 1).ToUpper() + _
                          word.Substring(1).ToLower()
            Else
                result += word.ToLower()
            End If
            If ctr <= words.Length - 1 Then
                result += " "
            End If
        Next
        Return result
    End Function
End Module

Public Module NumericLib
    <Extension()> _
    Public Function IsEven(number As IConvertible) As Boolean
        If TypeOf (number) Is Byte OrElse
           TypeOf (number) Is SByte OrElse
            TypeOf (number) Is Int16 OrElse
            TypeOf (number) Is UInt16 OrElse
            TypeOf (number) Is Int32 OrElse
            TypeOf (number) Is UInt32 OrElse
            TypeOf (number) Is Int64 Then
            Return CLng(number) Mod 2 = 0
        ElseIf TypeOf (number) Is UInt64 Then
            return CULng(number) Mod 2 = 0
        Else
            Throw New NotSupportedException("IsEven called for a non-integer value.")
        End If
    End Function

    Public Function NearZero(number As Double) As Boolean
        Return number < .00001
    End Function
End Module
