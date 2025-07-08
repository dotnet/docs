' Visual Basic .NET Document
Option Strict On

' <Snippet10>
Imports System.Threading

Module Example8
    Public Sub Main()
        Dim tasks(2) As Task
        Dim rnd As New Random()
        For ctr As Integer = 0 To 2
            tasks(ctr) = Task.Run(Sub() Thread.Sleep(rnd.Next(500, 3000)))
        Next

        Try
            Dim index As Integer = Task.WaitAny(tasks)
            Console.WriteLine("Task #{0} completed first.", tasks(index).Id)
            Console.WriteLine()
            Console.WriteLine("Status of all tasks:")
            For Each t In tasks
                Console.WriteLine("   Task #{0}: {1}", t.Id, t.Status)
            Next
        Catch e As AggregateException
            Console.WriteLine("An exception occurred.")
        End Try
    End Sub
End Module
' The example displays output like the following:
'     Task #1 completed first.
'     
'     Status of all tasks:
'        Task #3: Running
'        Task #1: RanToCompletion
'        Task #4: Running
' </Snippet10>
