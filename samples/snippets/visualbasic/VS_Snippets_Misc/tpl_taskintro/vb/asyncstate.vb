' Visual Basic .NET Document
Option Strict On

' <Snippet23>
Imports System.Threading

Namespace AsyncState
    Class CustomData
        Public CreationTime As Long
        Public Name As Integer
        Public ThreadNum As Integer
    End Class

    Module Example
        Public Sub Main()
            Dim taskArray(9) As Task
            For i As Integer = 0 To taskArray.Length - 1
                taskArray(i) = Task.Factory.StartNew(Sub(obj As Object)
                                                         Dim data As CustomData = TryCast(obj, CustomData)
                                                         If data Is Nothing Then Return

                                                         data.ThreadNum = Environment.CurrentManagedThreadId
                                                     End Sub,
                New CustomData With {.Name = i, .CreationTime = Date.Now.Ticks})
            Next
            Task.WaitAll(taskArray)

            For Each task In taskArray
                Dim data = TryCast(task.AsyncState, CustomData)
                If data IsNot Nothing Then
                    Console.WriteLine("Task #{0} created at {1}, ran on thread #{2}.",
                                    data.Name, data.CreationTime, data.ThreadNum)
                End If
            Next
        End Sub
    End Module
    ' The example displays output like the following:
    '     Task #0 created at 635116412924597583, ran on thread #3.
    '     Task #1 created at 635116412924607584, ran on thread #4.
    '     Task #2 created at 635116412924607584, ran on thread #4.
    '     Task #3 created at 635116412924607584, ran on thread #4.
    '     Task #4 created at 635116412924607584, ran on thread #3.
    '     Task #5 created at 635116412924607584, ran on thread #3.
    '     Task #6 created at 635116412924607584, ran on thread #4.
    '     Task #7 created at 635116412924607584, ran on thread #4.
    '     Task #8 created at 635116412924607584, ran on thread #3.
    '     Task #9 created at 635116412924607584, ran on thread #4.
End Namespace
' </Snippet23>