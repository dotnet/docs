' Visual Basic .NET Document
Option Strict On

' <Snippet5>
Imports System.Collections.Generic
Imports System.Threading.Tasks

Module Example
    Public Sub Main()
        Dim tasks As New List(Of Task(Of Integer))()
        For ctr As Integer = 1 To 10
            Dim baseValue As Integer = ctr
            tasks.Add(Task.Factory.StartNew(Function(b)
                                                Dim i As Integer = CInt(b)
                                                Return i * i
                                            End Function, baseValue))
        Next
        Dim continuation = Task.WhenAll(tasks)

        Dim sum As Long = 0
        For ctr As Integer = 0 To continuation.Result.Length - 1
            Console.Write("{0} {1} ", continuation.Result(ctr),
                          If(ctr = continuation.Result.Length - 1, "=", "+"))
            sum += continuation.Result(ctr)
        Next
        Console.WriteLine(sum)
    End Sub
End Module
' The example displays the following output:
'       1 + 4 + 9 + 16 + 25 + 36 + 49 + 64 + 81 + 100 = 385
' </Snippet5>
