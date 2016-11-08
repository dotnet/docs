    ' Imports System.Diagnostics
    ' Imports System.Threading.Tasks

    ' This Click event is marked with the Async modifier.
    Private Async Sub startButton_Click(sender As Object, e As RoutedEventArgs) Handles startButton.Click
        Await DoSomethingAsync()
    End Sub

    Private Async Function DoSomethingAsync() As Task
        Dim delayTask As Task(Of Integer) = DelayAsync()
        Dim result As Integer = Await delayTask

        ' The previous two statements may be combined into
        ' the following statement.
        ' Dim result As Integer = Await DelayAsync()

        Debug.WriteLine("Result: " & result)
    End Function

    Private Async Function DelayAsync() As Task(Of Integer)
        Await Task.Delay(100)
        Return 5
    End Function

    '  Output:
    '   Result: 5