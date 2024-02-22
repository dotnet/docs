' Visual Basic .NET Document
Option Strict On

' <Snippet22>
Imports System.Threading

Namespace IterationsTwo
    Class CustomData
        Public CreationTime As Long
        Public Name As Integer
        Public ThreadNum As Integer
    End Class

    Module Example
        Public Sub Main()
            ' Create the task object by using an Action(Of Object) to pass in the loop
            ' counter. This produces an unexpected result.
            Dim taskArray(9) As Task
            For i As Integer = 0 To taskArray.Length - 1
                taskArray(i) = Task.Factory.StartNew(Sub(obj As Object)
                                                         Dim data As New CustomData With {.Name = i, .CreationTime = Date.Now.Ticks}
                                                         data.ThreadNum = Environment.CurrentManagedThreadId
                                                         Console.WriteLine("Task #{0} created at {1} on thread #{2}.",
                                                                         data.Name, data.CreationTime, data.ThreadNum)
                                                     End Sub,
                    i)
            Next
            Task.WaitAll(taskArray)
        End Sub
    End Module
    ' The example displays output like the following:
    '       Task #10 created at 635116418427727841 on thread #4.
    '       Task #10 created at 635116418427737842 on thread #4.
    '       Task #10 created at 635116418427737842 on thread #4.
    '       Task #10 created at 635116418427737842 on thread #4.
    '       Task #10 created at 635116418427737842 on thread #4.
    '       Task #10 created at 635116418427737842 on thread #4.
    '       Task #10 created at 635116418427727841 on thread #3.
    '       Task #10 created at 635116418427747843 on thread #3.
    '       Task #10 created at 635116418427747843 on thread #3.
    '       Task #10 created at 635116418427737842 on thread #4.
End Namespace
' </Snippet22>
