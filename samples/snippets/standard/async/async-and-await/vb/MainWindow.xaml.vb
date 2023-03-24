
Imports System.Net.Http

' Example that demonstrates Asynchronous Progamming with Async and Await.
' It uses HttpClient.GetStringAsync to download the contents of a website.
' Sample Output:
' Working . . . . . . .
'
' Length of the downloaded string: 39678.

Class MainWindow

    ' Mark the event handler with Async so you can use Await in it.
    Private Async Sub StartButton_Click(sender As Object, e As RoutedEventArgs)

        ' Call and await immediately.
        ' StartButton_Click suspends until AccessTheWebAsync is done.
        Dim contentLength As Integer = Await AccessTheWebAsync()

        ResultsTextBox.Text &= $"{vbCrLf}Length of the downloaded string: {contentLength}.{vbCrLf}"

    End Sub


    ' Three things to note about writing an Async Function:
    '  - The function has an Async modifier.
    '  - Its return type is Task or Task(Of T). (See "Return Types" section.)
    '  - As a matter of convention, its name ends in "Async".
    Async Function AccessTheWebAsync() As Task(Of Integer)

        Using client As New HttpClient()

            ' Call and await separately.
            '  - AccessTheWebAsync can do other things while GetStringAsync is also running.
            '  - getStringTask stores the task we get from the call to GetStringAsync.
            '  - Task(Of String) means it is a task which returns a String when it is done.
            Dim getStringTask As Task(Of String) =
                client.GetStringAsync("https://learn.microsoft.com/dotnet")

            ' You can do other work here that doesn't rely on the string from GetStringAsync.
            DoIndependentWork()

            ' The Await operator suspends AccessTheWebAsync.
            '  - AccessTheWebAsync does not continue until getStringTask is complete.
            '  - Meanwhile, control returns to the caller of AccessTheWebAsync.
            '  - Control resumes here when getStringTask is complete.
            '  - The Await operator then retrieves the String result from getStringTask.
            Dim urlContents As String = Await getStringTask

            ' The Return statement specifies an Integer result.
            ' A method which awaits AccessTheWebAsync receives the Length value.
            Return urlContents.Length

        End Using

    End Function

    Sub DoIndependentWork()
        ResultsTextBox.Text &= $"Working . . . . . . .{vbCrLf}"
    End Sub

End Class
