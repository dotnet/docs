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