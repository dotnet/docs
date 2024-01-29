' Visual Basic .NET Document
'Option Strict On

Imports System.Diagnostics
Imports System.Numerics

Module Example3
    Public Sub Main()
        ShowSimpleAdd()
        PerformBigIntegerOperation()
        PerformWithIntermediary()
    End Sub

    Private Sub ShowSimpleAdd()
        ' <Snippet1>
        Dim number As BigInteger = BigInteger.Multiply(Int64.MaxValue, 3)
        number += 1
        Console.WriteLine(number)
        ' </Snippet1>
    End Sub

    Private Sub PerformBigIntegerOperation()
        Dim sw As Stopwatch = Stopwatch.StartNew()

        ' <Snippet12>
        Dim number As BigInteger = Int64.MaxValue ^ 5
        Dim repetitions As Integer = 1000000
        ' Perform some repetitive operation 1 million times.
        For ctr As Integer = 0 To repetitions
            ' Perform some operation. If it fails, exit the loop.
            If Not SomeOperationSucceeds() Then Exit For
            ' The following code executes if the operation succeeds.
            number += 1
        Next
        ' </Snippet12>

        sw.Stop()
        Console.WriteLine("Incrementing a BigInteger: " + sw.Elapsed.ToString())
    End Sub

    Private Sub PerformWithIntermediary()
        Dim sw As Stopwatch = Stopwatch.StartNew()

        ' <Snippet3>
        Dim number As BigInteger = Int64.MaxValue ^ 5
        Dim repetitions As Integer = 1000000
        Dim actualRepetitions As Integer = 0
        ' Perform some repetitive operation 1 million times.
        For ctr As Integer = 0 To repetitions
            ' Perform some operation. If it fails, exit the loop.
            If Not SomeOperationSucceeds() Then Exit For
            ' The following code executes if the operation succeeds.
            actualRepetitions += 1
        Next
        number += actualRepetitions
        ' </Snippet3>

        sw.Stop()
        Console.WriteLine("Incrementing a BigInteger: " + sw.Elapsed.ToString())
    End Sub

    Private Function SomeOperationSucceeds() As Boolean
        Return True
    End Function
End Module

' <Snippet2>
' CAPS bug: snippet2 is seen as duplicated, even though it isn't.
' </Snippet2>
