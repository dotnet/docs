' Visual Basic .NET Document
Option Strict On

' <Snippet11>
Imports System.Threading
Imports System.Threading.Tasks

Module Example6
    Public Sub Main()
        ' Wait for all tasks to complete.
        Dim tasks(9) As Task
        For i As Integer = 0 To 9
            tasks(i) = Task.Run(Sub() Thread.Sleep(2000))
        Next
        Try
            Task.WaitAll(tasks)
        Catch ae As AggregateException
            Console.WriteLine("One or more exceptions occurred: ")
            For Each ex In ae.Flatten().InnerExceptions
                Console.WriteLine("   {0}", ex.Message)
            Next
        End Try

        Console.WriteLine("Status of completed tasks:")
        For Each t In tasks
            Console.WriteLine("   Task #{0}: {1}", t.Id, t.Status)
        Next
    End Sub
End Module
' The example displays the following output:
'     Status of completed tasks:
'        Task #2: RanToCompletion
'        Task #1: RanToCompletion
'        Task #3: RanToCompletion
'        Task #4: RanToCompletion
'        Task #6: RanToCompletion
'        Task #5: RanToCompletion
'        Task #7: RanToCompletion
'        Task #8: RanToCompletion
'        Task #9: RanToCompletion
'        Task #10: RanToCompletion
' </Snippet11>
