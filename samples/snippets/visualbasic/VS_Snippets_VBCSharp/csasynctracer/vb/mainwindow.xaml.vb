
'<snippet1>
' Add an Imports statement and a reference for System.Net.Http.
Imports System.Net.Http

Class MainWindow

    Private Async Sub StartButton_Click(sender As Object, e As RoutedEventArgs) Handles StartButton.Click

        ' The display lines in the example lead you through the control shifts.
        ResultsTextBox.Text &= "ONE:   Entering StartButton_Click." & vbCrLf &
            "           Calling AccessTheWebAsync." & vbCrLf

        '<snippet4>
        Dim getLengthTask As Task(Of Integer) = AccessTheWebAsync()
        '</snippet4>

        ResultsTextBox.Text &= vbCrLf & "FOUR:  Back in StartButton_Click." & vbCrLf &
            "           Task getLengthTask is started." & vbCrLf &
            "           About to await getLengthTask -- no caller to return to." & vbCrLf

        '<snippet5>
        Dim contentLength As Integer = Await getLengthTask
        '</snippet5>

        ResultsTextBox.Text &= vbCrLf & "SIX:   Back in StartButton_Click." & vbCrLf &
            "           Task getLengthTask is finished." & vbCrLf &
            "           Result from AccessTheWebAsync is stored in contentLength." & vbCrLf &
            "           About to display contentLength and exit." & vbCrLf

        ResultsTextBox.Text &=
            String.Format(vbCrLf & "Length of the downloaded string: {0}." & vbCrLf, contentLength)
    End Sub


    Async Function AccessTheWebAsync() As Task(Of Integer)

        ResultsTextBox.Text &= vbCrLf & "TWO:   Entering AccessTheWebAsync."

        ' Declare an HttpClient object.
        Dim client As HttpClient = New HttpClient()

        ResultsTextBox.Text &= vbCrLf & "           Calling HttpClient.GetStringAsync." & vbCrLf

        ' GetStringAsync returns a Task(Of String). 
        '<snippet2>
        Dim getStringTask As Task(Of String) = client.GetStringAsync("http://msdn.microsoft.com")
        '</snippet2>

        ResultsTextBox.Text &= vbCrLf & "THREE: Back in AccessTheWebAsync." & vbCrLf &
            "           Task getStringTask is started."

        ' AccessTheWebAsync can continue to work until getStringTask is awaited.

        ResultsTextBox.Text &=
            vbCrLf & "           About to await getStringTask & return a Task(Of Integer) to StartButton_Click." & vbCrLf

        ' Retrieve the website contents when task is complete.
        '<snippet3>
        Dim urlContents As String = Await getStringTask
        '</snippet3>

        ResultsTextBox.Text &= vbCrLf & "FIVE:  Back in AccessTheWebAsync." &
            vbCrLf & "           Task getStringTask is complete." &
            vbCrLf & "           Processing the return statement." &
            vbCrLf & "           Exiting from AccessTheWebAsync." & vbCrLf

        Return urlContents.Length
    End Function

End Class
'</snippet1>

' Sample Output:

' ONE:   Entering StartButton_Click.
'           Calling AccessTheWebAsync.

' TWO:   Entering AccessTheWebAsync.
'           Calling HttpClient.GetStringAsync.

' THREE: Back in AccessTheWebAsync.
'           Task getStringTask is started.
'           About to await getStringTask & return a Task(Of Integer) to StartButton_Click.

' FOUR:  Back in StartButton_Click.
'           Task getLengthTask is started.
'           About to await getLengthTask -- no caller to return to.

' FIVE:  Back in AccessTheWebAsync.
'           Task getStringTask is complete.
'           Processing the return statement.
'           Exiting from AccessTheWebAsync.

' SIX:   Back in StartButton_Click.
'           Task getLengthTask is finished.
'           Result from AccessTheWebAsync is stored in contentLength.
'           About to display contentLength and exit.

' Length of the downloaded string: 44286.
