' Walkthrough: Using the Debugger with Async Methods
' 5adb2531-3f09-4b7e-8baa-29de80abee6e

Public Class Class1

    Private Async Sub Other()
        '<Snippet2>
        Dim theTask = DoSomethingAsync()
        Dim result = Await theTask
        '</Snippet2>
    End Sub


    Async Function DoSomethingAsync() As Task(Of Integer)
        Await Task.Delay(1000)
        Return 5
    End Function

End Class
