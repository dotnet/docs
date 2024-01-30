' Visual Basic .NET Document
Option Strict On

' <Snippet8>
Imports System.Threading
Imports System.Threading.Tasks

Module Example4
    Public Sub Main()
        ' Wait on a single task with no timeout specified.
        Dim taskA = Task.Run(Sub() Thread.Sleep(2000))
        Console.WriteLine("taskA Status: {0}", taskA.Status)
        Try
            taskA.Wait()
            Console.WriteLine("taskA Status: {0}", taskA.Status)
        Catch e As AggregateException
            Console.WriteLine("Exception in taskA.")
        End Try
    End Sub
End Module
' The example displays output like the following:
'     taskA Status: WaitingToRun
'     taskA Status: RanToCompletion
' </Snippet8>
