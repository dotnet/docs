' Imports System.Collections.Concurrent
Class CS_Singles

    ' Demonstrates:
    ' ConcurrentStack<T>.Push();
    ' ConcurrentStack<T>.TryPeek();
    ' ConcurrentStack<T>.TryPop();
    ' ConcurrentStack<T>.Clear();
    ' ConcurrentStack<T>.IsEmpty;
    Shared Sub Main()
        Dim errorCount As Integer = 0

        ' Construct a ConcurrentStack
        Dim cs As New ConcurrentStack(Of Integer)()

        ' Push some elements onto the stack
        cs.Push(1)
        cs.Push(2)

        Dim result As Integer

        ' Peek at the top of the stack
        If Not cs.TryPeek(result) Then
            Console.WriteLine("CS: TryPeek() failed when it should have succeeded")
            errorCount += 1
        ElseIf result <> 2 Then
            Console.WriteLine("CS: TryPeek() saw {0} instead of 2", result)
            errorCount += 1
        End If

        ' Pop a number off of the stack
        If Not cs.TryPop(result) Then
            Console.WriteLine("CS: TryPop() failed when it should have succeeded")
            errorCount += 1
        ElseIf result <> 2 Then
            Console.WriteLine("CS: TryPop() saw {0} instead of 2", result)
            errorCount += 1
        End If

        ' Clear the stack, and verify that it is empty
        cs.Clear()
        If Not cs.IsEmpty Then
            Console.WriteLine("CS: IsEmpty not true after Clear()")
            errorCount += 1
        End If

        If errorCount = 0 Then
            Console.WriteLine(" OK!")
        End If
    End Sub
End Class