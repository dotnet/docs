
'<snippet6>
' Add an Imports directive and a reference for System.Net.Http.
Imports System.Net.Http

' Add the following Imports directive for System.Threading.
Imports System.Threading

Class MainWindow

    ' Declare a System.Threading.CancellationTokenSource.
    Dim cts As CancellationTokenSource


    Private Async Sub startButton_Click(sender As Object, e As RoutedEventArgs)

        ' Instantiate the CancellationTokenSource.
        cts = New CancellationTokenSource()

        resultsTextBox.Clear()

        Try
            Await AccessTheWebAsync(cts.Token)
            resultsTextBox.Text &= vbCrLf & "Downloads complete."

        Catch ex As OperationCanceledException
            resultsTextBox.Text &= vbCrLf & "Downloads canceled." & vbCrLf

        Catch ex As Exception
            resultsTextBox.Text &= vbCrLf & "Downloads failed." & vbCrLf
        End Try

        ' Set the CancellationTokenSource to Nothing when the download is complete.
        cts = Nothing
    End Sub


    ' You can still include a Cancel button if you want to.
    Private Sub cancelButton_Click(sender As Object, e As RoutedEventArgs)

        If cts IsNot Nothing Then
            cts.Cancel()
        End If
    End Sub


    ' Provide a parameter for the CancellationToken.
    ' Change the return type to Task because the method has no return statement.
    Async Function AccessTheWebAsync(ct As CancellationToken) As Task

        Dim client As HttpClient = New HttpClient()

        ' Call SetUpURLList to make a list of web addresses.
        Dim urlList As List(Of String) = SetUpURLList()

        ' ***Create a query that, when executed, returns a collection of tasks.
        '<snippet1>
        Dim downloadTasksQuery As IEnumerable(Of Task(Of Integer)) =
            From url In urlList Select ProcessURLAsync(url, client, ct)
        '</snippet1>

        ' ***Use ToList to execute the query and start the download tasks. 
        '<snippet2>
        Dim downloadTasks As List(Of Task(Of Integer)) = downloadTasksQuery.ToList()
        '</snippet2>

        ' ***Add a loop to process the tasks one at a time until none remain.
        While downloadTasks.Count > 0
            ' ***Identify the first task that completes.
            '<snippet3>
            Dim firstFinishedTask As Task(Of Integer) = Await Task.WhenAny(downloadTasks)
            '</snippet3>

            ' ***Remove the selected task from the list so that you don't
            ' process it more than once.
            '<snippet4>
            downloadTasks.Remove(firstFinishedTask)
            '</snippet4>

            ' ***Await the first completed task and display the results.
            '<snippet5>
            Dim length = Await firstFinishedTask
            resultsTextBox.Text &= String.Format(vbCrLf & "Length of the downloaded website:  {0}" & vbCrLf, length)
            '</snippet5>
        End While

    End Function


    ' Bundle the processing steps for a website into one async method.
    Async Function ProcessURLAsync(url As String, client As HttpClient, ct As CancellationToken) As Task(Of Integer)

        ' GetAsync returns a Task(Of HttpResponseMessage). 
        Dim response As HttpResponseMessage = Await client.GetAsync(url, ct)

        ' Retrieve the website contents from the HttpResponseMessage.
        Dim urlContents As Byte() = Await response.Content.ReadAsByteArrayAsync()

        Return urlContents.Length
    End Function


    ' Add a method that creates a list of web addresses.
    Private Function SetUpURLList() As List(Of String)

        Dim urls = New List(Of String) From
            {
                "http://msdn.microsoft.com",
                "http://msdn.microsoft.com/en-us/library/hh290138.aspx",
                "http://msdn.microsoft.com/en-us/library/hh290140.aspx",
                "http://msdn.microsoft.com/en-us/library/dd470362.aspx",
                "http://msdn.microsoft.com/en-us/library/aa578028.aspx",
                "http://msdn.microsoft.com/en-us/library/ms404677.aspx",
                "http://msdn.microsoft.com/en-us/library/ff730837.aspx"
            }
        Return urls
    End Function

End Class


' Sample output:

' Length of the download:  226093
' Length of the download:  412588
' Length of the download:  175490
' Length of the download:  204890
' Length of the download:  158855
' Length of the download:  145790
' Length of the download:  44908
' Downloads complete.
'</snippet6>




