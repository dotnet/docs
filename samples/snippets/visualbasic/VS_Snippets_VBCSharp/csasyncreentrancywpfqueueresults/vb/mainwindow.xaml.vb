
' Add the following Imports statements, and add a reference for System.Net.Http.
Imports System.Net.Http
Imports System.Threading

'<snippet1>
Class MainWindow    ' Class MainPage in Windows Store app.

    ' ***Declare the following variables where all methods can access them. 
    Private pendingWork As Task = Nothing
    Private group As Char = ChrW(AscW("A") - 1)
    '</snippet1>

    '<snippet2>
    Private Async Sub StartButton_Click(sender As Object, e As RoutedEventArgs)
        ' ***Verify that each group's results are displayed together, and that
        ' the groups display in order, by marking each group with a letter.
        group = ChrW(AscW(group) + 1)
        ResultsTextBox.Text &= String.Format(vbCrLf & vbCrLf & "#Starting group {0}.", group)

        Try
            ' *** Pass the group value to AccessTheWebAsync.
            Dim finishedGroup As Char = Await AccessTheWebAsync(group)

            ' The following line verifies a successful return from the download and 
            ' display procedures. 
            ResultsTextBox.Text &= String.Format(vbCrLf & vbCrLf & "#Group {0} is complete." & vbCrLf, finishedGroup)

        Catch ex As Exception
            ResultsTextBox.Text &= vbCrLf & "Downloads failed."

        End Try
    End Sub
    '</snippet2>


    '<snippet3>
    Private Async Function AccessTheWebAsync(grp As Char) As Task(Of Char)

        Dim client = New HttpClient()

        ' Make a list of the web addresses to download.
        Dim urlList As List(Of String) = SetUpURLList()

        ' ***Kick off the downloads. The application of ToArray activates all the download tasks.
        Dim getContentTasks As Task(Of Byte())() =
            urlList.Select(Function(addr) client.GetByteArrayAsync(addr)).ToArray()

        ' ***Call the method that awaits the downloads and displays the results.
        ' Assign the Task that FinishOneGroupAsync returns to the gatekeeper task, pendingWork.
        pendingWork = FinishOneGroupAsync(urlList, getContentTasks, grp)

        ResultsTextBox.Text &=
            String.Format(vbCrLf & "#Task assigned for group {0}. Download tasks are active." & vbCrLf, grp)

        ' ***This task is complete when a group has finished downloading and displaying.
        Await pendingWork

        ' You can do other work here or just return.
        Return grp
    End Function
    '</snippet3>


    '<snippet4>
    Private Async Function FinishOneGroupAsync(urls As List(Of String), contentTasks As Task(Of Byte())(), grp As Char) As Task

        ' Wait for the previous group to finish displaying results.
        If pendingWork IsNot Nothing Then
            Await pendingWork
        End If

        Dim total = 0

        ' contentTasks is the array of Tasks that was created in AccessTheWebAsync.
        For i As Integer = 0 To contentTasks.Length - 1
            ' Await the download of a particular URL, and then display the URL and
            ' its length.
            Dim content As Byte() = Await contentTasks(i)
            DisplayResults(urls(i), content, i, grp)
            total += content.Length
        Next

        ' Display the total count for all of the websites.
        ResultsTextBox.Text &=
            String.Format(vbCrLf & vbCrLf & "TOTAL bytes returned:  " & total & vbCrLf)
    End Function
    '</snippet4>


    ' ***Add a parameter for the group label.
    Private Sub DisplayResults(url As String, content As Byte(), pos As Integer, grp As Char)
        ' Display the length of each website. The string format is designed to be
        ' used with a monospaced font, such as Lucida Console or Global Monospace.

        ' Strip off the "http:'".
        Dim displayURL = url.Replace("http://", "")
        ' Display position in the URL list, the URL, and the number of bytes.
        ResultsTextBox.Text &= String.Format(vbCrLf & "{0}-{1}. {2,-58} {3,8}", grp, pos + 1, displayURL, content.Length)
    End Sub


    Private Function SetUpURLList() As List(Of String)
        Dim urls = New List(Of String) From
        {
            "http://msdn.microsoft.com/en-us/library/hh191443.aspx",
            "http://msdn.microsoft.com/en-us/library/aa578028.aspx",
            "http://msdn.microsoft.com/en-us/library/jj155761.aspx",
            "http://msdn.microsoft.com/en-us/library/hh290140.aspx",
            "http://msdn.microsoft.com/en-us/library/hh524395.aspx",
            "http://msdn.microsoft.com/en-us/library/ms404677.aspx",
            "http://msdn.microsoft.com",
            "http://msdn.microsoft.com/en-us/library/ff730837.aspx"
        }
        Return urls
    End Function

End Class
