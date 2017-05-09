' Walkthrough: Using the Debugger with Async Methods
' 5adb2531-3f09-4b7e-8baa-29de80abee6e

'<Snippet4>
' Step Out Example
Imports System.Threading.Tasks

Module Module1
    Sub Main()
        ProcessAsync.Wait()
    End Sub

    Async Function ProcessAsync() As Task
        Dim theTask = DoSomethingAsync()
        Dim z = 0
        Dim result = Await theTask
    End Function

    Async Function DoSomethingAsync() As Task(Of Integer)
        Debug.WriteLine("before")  ' Step Out from here
        Await Task.Delay(1000)
        Debug.WriteLine("after")
        Return 5
    End Function
End Module
'</Snippet4>
