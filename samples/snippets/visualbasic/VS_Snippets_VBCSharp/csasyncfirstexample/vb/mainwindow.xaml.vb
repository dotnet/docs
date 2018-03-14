
'<snippet2>
' Add an Imports statement and a reference for System.Net.Http
Imports System.Net.Http

Class MainWindow

    ' Mark the event handler with async so you can use Await in it.
    Private Async Sub StartButton_Click(sender As Object, e As RoutedEventArgs)

        ' Call and await separately.
        'Task<int> getLengthTask = AccessTheWebAsync();
        '' You can do independent work here.
        'int contentLength = await getLengthTask;

        Dim contentLength As Integer = Await AccessTheWebAsync()

        ResultsTextBox.Text &=
            String.Format(vbCrLf & "Length of the downloaded string: {0}." & vbCrLf, contentLength)
    End Sub


    '<snippet1>
    ' Three things to note in the signature:
    '  - The method has an Async modifier. 
    '  - The return type is Task or Task(Of T). (See "Return Types" section.)
    '    Here, it is Task(Of Integer) because the return statement returns an integer.
    '  - The method name ends in "Async."
    Async Function AccessTheWebAsync() As Task(Of Integer)

        ' You need to add a reference to System.Net.Http to declare client.
        Dim client As HttpClient = New HttpClient()

        ' GetStringAsync returns a Task(Of String). That means that when you await the
        ' task you'll get a string (urlContents).
        Dim getStringTask As Task(Of String) = client.GetStringAsync("http://msdn.microsoft.com")


        ' You can do work here that doesn't rely on the string from GetStringAsync.
        DoIndependentWork()

        ' The Await operator suspends AccessTheWebAsync.
        '  - AccessTheWebAsync can't continue until getStringTask is complete.
        '  - Meanwhile, control returns to the caller of AccessTheWebAsync.
        '  - Control resumes here when getStringTask is complete. 
        '  - The Await operator then retrieves the string result from getStringTask.
        Dim urlContents As String = Await getStringTask

        ' The return statement specifies an integer result.
        ' Any methods that are awaiting AccessTheWebAsync retrieve the length value.
        Return urlContents.Length
    End Function
    '</snippet1>


    Sub DoIndependentWork()
        ResultsTextBox.Text &= "Working . . . . . . ." & vbCrLf
    End Sub
End Class

' Sample Output:

' Working . . . . . . .

' Length of the downloaded string: 41763.
'</snippet2>