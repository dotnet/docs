' Walkthrough: Using the Debugger with Async Methods
' 5adb2531-3f09-4b7e-8baa-29de80abee6e

'<Snippet3>
' Step Into and Step Over Example
Imports System.Threading.Tasks

Module Module1
    Sub Main()
        ProcessAsync.Wait()
    End Sub

    Async Function ProcessAsync() As Task
        Dim result = Await DoSomethingAsync()  ' Step Into or Step Over from here

        Dim y = 0
    End Function

    Async Function DoSomethingAsync() As Task(Of Integer)
        Await Task.Delay(1000)
        Return 5
    End Function
End Module
'</Snippet3>
