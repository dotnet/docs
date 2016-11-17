    Public Async Function DoMultipleAsync() As Task
        Dim theTask1 As Task = ExcAsync(info:="First Task")
        Dim theTask2 As Task = ExcAsync(info:="Second Task")
        Dim theTask3 As Task = ExcAsync(info:="Third Task")

        Dim allTasks As Task = Task.WhenAll(theTask1, theTask2, theTask3)

        Try
            Await allTasks
        Catch ex As Exception
            Debug.WriteLine("Exception: " & ex.Message)
            Debug.WriteLine("Task IsFaulted: " & allTasks.IsFaulted)
            For Each inEx In allTasks.Exception.InnerExceptions
                Debug.WriteLine("Task Inner Exception: " + inEx.Message)
            Next
        End Try
    End Function

    Private Async Function ExcAsync(info As String) As Task
        Await Task.Delay(100)

        Throw New Exception("Error-" & info)
    End Function

    ' Output:
    '   Exception: Error-First Task
    '   Task IsFaulted: True
    '   Task Inner Exception: Error-First Task
    '   Task Inner Exception: Error-Second Task
    '   Task Inner Exception: Error-Third Task