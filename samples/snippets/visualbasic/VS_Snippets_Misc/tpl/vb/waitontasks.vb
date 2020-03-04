'<snippet11>
' How to: Wait on One or More Tasks to Complete
Imports System.Threading
Imports System.Threading.Tasks

Module WaitOnTasks

    Dim rand As New Random()
    Sub Main()

        ' Wait on a single task with no timeout specified.
        Dim taskA = Task.Factory.StartNew(Sub() DoSomeWork(10000000))
        taskA.Wait()
        Console.WriteLine("taskA has completed.")


        ' Wait on a single task with a timeout specified.
        Dim taskB = Task.Factory.StartNew(Sub() DoSomeWork(10000000))
        taskB.Wait(100) 'Wait for 100 ms.

        If (taskB.IsCompleted) Then
            Console.WriteLine("taskB has completed.")
        Else
            Console.WriteLine("Timed out before task2 completed.")
        End If

        ' Wait for all tasks to complete.
        Dim myTasks(9) As Task
        For i As Integer = 0 To myTasks.Length - 1
            myTasks(i) = Task.Factory.StartNew(Sub() DoSomeWork(10000000))
        Next
        Task.WaitAll(myTasks)

        ' Wait for first task to complete.
        Dim tasks2(2) As Task(Of Double)

        ' Try three different approaches to the problem. Take the first one.
        tasks2(0) = Task(Of Double).Factory.StartNew(Function() TrySolution1())
        tasks2(1) = Task(Of Double).Factory.StartNew(Function() TrySolution2())
        tasks2(2) = Task(Of Double).Factory.StartNew(Function() TrySolution3())


        Dim index As Integer = Task.WaitAny(tasks2)
        Dim d As Double = tasks2(index).Result
        Console.WriteLine("task(0) completed first with result of {1}.", index, d)
        Console.ReadKey()

    End Sub


    ' Dummy Functions to Simulate Work

    Function DoSomeWork(ByVal val As Integer)
        ' Pretend to do something.
        Thread.SpinWait(val)
    End Function

    Function TrySolution1()

        Dim i As Integer = rand.Next(1000000)
        ' Simulate work by spinning
        Thread.SpinWait(i)
        Return i
    End Function
    Function TrySolution2()

        Dim i As Integer = rand.Next(1000000)
        ' Simulate work by spinning
        Thread.SpinWait(i)
        Return i
    End Function
    Function TrySolution3()

        Dim i As Integer = rand.Next(1000000)
        ' Simulate work by spinning
        Thread.SpinWait(i)
        Thread.SpinWait(1000000)
        Return i
    End Function

End Module
'</snippet11>