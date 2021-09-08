Public Class AsyncExceptionExamples

    ' Try...Catch...Finally Statement (Visual Basic)
    ' try-catch (C# Reference)

    ' Snippet1 in VB is equivalent to Snippet2 in C#.

    '<Snippet1>
    Public Async Function DoSomethingAsync() As Task
        Dim theTask As Task(Of String) = DelayAsync()

        Try
            Dim result As String = Await theTask
            Debug.WriteLine("Result: " & result)
        Catch ex As Exception
            Debug.WriteLine("Exception Message: " & ex.Message)
        End Try

        Debug.WriteLine("Task IsCanceled: " & theTask.IsCanceled)
        Debug.WriteLine("Task IsFaulted:  " & theTask.IsFaulted)
        If theTask.Exception IsNot Nothing Then
            Debug.WriteLine("Task Exception Message: " &
                theTask.Exception.Message)
            Debug.WriteLine("Task Inner Exception Message: " &
                theTask.Exception.InnerException.Message)
        End If
    End Function

    Private Async Function DelayAsync() As Task(Of String)
        Await Task.Delay(100)

        ' Uncomment each of the following lines to
        ' demonstrate exception handling.

        'Throw New OperationCanceledException("canceled")
        'Throw New Exception("Something happened.")
        Return "Done"
    End Function


    ' Output when no exception is thrown in the awaited method:
    '   Result: Done
    '   Task IsCanceled: False
    '   Task IsFaulted:  False

    ' Output when an Exception is thrown in the awaited method:
    '   Exception Message: Something happened.
    '   Task IsCanceled: False
    '   Task IsFaulted:  True
    '   Task Exception Message: One or more errors occurred.
    '   Task Inner Exception Message: Something happened.

    ' Output when an OperationCanceledException or TaskCanceledException
    ' is thrown in the awaited method:
    '   Exception Message: canceled
    '   Task IsCanceled: True
    '   Task IsFaulted:  False
    '</Snippet1>


    ' Snippet3 in VB is equivalent to Snippet4 in C#.

    '<Snippet3>
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
    '</Snippet3>

End Class
