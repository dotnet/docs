' <snippet1>
Imports System.Collections.Generic
Imports System.Threading
Imports System.Threading.Tasks

' Demonstrates how to associate state with task continuations.
Public Module ContinuationState
    ' Simulates a lengthy operation and returns the time at which
    ' the operation completed.
    Public Function DoWork() As Date
        ' Simulate work by suspending the current thread
        ' for two seconds.
        Thread.Sleep(2000)

        ' Return the current time.
        Return Date.Now
    End Function

    Public Sub Main()
        ' Start a root task that performs work.
        Dim t As Task(Of Date) = Task(Of Date).Run(Function() DoWork())

        ' Create a chain of continuation tasks, where each task is
        ' followed by another task that performs work.
        Dim continuations As New List(Of Task(Of DateTime))()
        For i As Integer = 0 To 4
            ' Provide the current time as the state of the continuation.
            t = t.ContinueWith(Function(antecedent, state) DoWork(), DateTime.Now)
            continuations.Add(t)
        Next

        ' Wait for the last task in the chain to complete.
        t.Wait()

        ' Display the creation time of each continuation (the state object)
        ' and the completion time (the result of that task) to the console.
        For Each continuation In continuations
            Dim start As DateTime = CDate(continuation.AsyncState)
            Dim [end] As DateTime = continuation.Result

            Console.WriteLine("Task was created at {0} and finished at {1}.",
               start.TimeOfDay, [end].TimeOfDay)
        Next
    End Sub
End Module
' The example displays output like the following:
'       Task was created at 10:56:21.1561762 and finished at 10:56:25.1672062.
'       Task was created at 10:56:21.1610677 and finished at 10:56:27.1707646.
'       Task was created at 10:56:21.1610677 and finished at 10:56:29.1743230.
'       Task was created at 10:56:21.1610677 and finished at 10:56:31.1779883.
'       Task was created at 10:56:21.1610677 and finished at 10:56:33.1837083.
' </snippet1>
