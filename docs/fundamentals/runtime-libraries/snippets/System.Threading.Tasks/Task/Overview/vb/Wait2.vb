' Visual Basic .NET Document
Option Strict On

' <Snippet9>
Imports System.Threading
Imports System.Threading.Tasks

Module Example5
    Public Sub Main()
        ' Wait on a single task with a timeout specified.
        Dim taskA As Task = Task.Run(Sub() Thread.Sleep(2000))
        Try
            taskA.Wait(1000)        ' Wait for 1 second.
            Dim completed As Boolean = taskA.IsCompleted
            Console.WriteLine("Task.Completed: {0}, Status: {1}",
                           completed, taskA.Status)
            If Not completed Then
                Console.WriteLine("Timed out before task A completed.")
            End If
        Catch e As AggregateException
            Console.WriteLine("Exception in taskA.")
        End Try
    End Sub
End Module
' The example displays the following output:
'     Task A completed: False, Status: Running
'     Timed out before task A completed.
' </Snippet9>
