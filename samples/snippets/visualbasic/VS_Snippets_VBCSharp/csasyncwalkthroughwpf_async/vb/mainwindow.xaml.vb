
'<snippet10>
' Add the following Imports statements, and add a reference for System.Net.Http.
'<snippet11>
Imports System.Net.Http
Imports System.Net
Imports System.IO
'</snippet11>

Class MainWindow

    '<snippet24>
    Async Sub startButton_Click(sender As Object, e As RoutedEventArgs) Handles startButton.Click
        '</snippet24>

        '<snippet25>
        ' Disable the button until the operation is complete.
        startButton.IsEnabled = False
        '</snippet25>

        resultsTextBox.Clear()

        '<snippet23>
        '' One-step async call.
        Await SumPageSizesAsync()

        ' Two-step async call.
        'Dim sumTask As Task = SumPageSizesAsync()
        'Await sumTask
        '</snippet23>

        resultsTextBox.Text &= vbCrLf & "Control returned to button1_Click."

        '<snippet26>
        ' Reenable the button in case you want to run the operation again.
        startButton.IsEnabled = True
        '</snippet26>
    End Sub


    '<snippet22>
    Private Async Function SumPageSizesAsync() As Task
        '</snippet22>

        ' Make a list of web addresses.
        Dim urlList As List(Of String) = SetUpURLList()

        Dim total = 0
        For Each url In urlList
            '<snippet19>
            Dim urlContents As Byte() = Await GetURLContentsAsync(url)
            '</snippet19>

            ' The previous line abbreviates the following two assignment statements.

            '<snippet21>
            ' GetURLContentsAsync returns a task. At completion, the task
            ' produces a byte array.
            'Dim getContentsTask As Task(Of Byte()) = GetURLContentsAsync(url)
            'Dim urlContents As Byte() = Await getContentsTask
            '</snippet21>

            DisplayResults(url, urlContents)

            ' Update the total.
            total += urlContents.Length
        Next

        ' Display the total count for all of the websites.
        resultsTextBox.Text &= String.Format(vbCrLf & vbCrLf &
                                             "Total bytes returned:  {0}" & vbCrLf, total)
    End Function


    Private Function SetUpURLList() As List(Of String)

        Dim urls = New List(Of String) From
            {
                "http://msdn.microsoft.com/library/windows/apps/br211380.aspx",
                "http://msdn.microsoft.com",
                "http://msdn.microsoft.com/en-us/library/hh290136.aspx",
                "http://msdn.microsoft.com/en-us/library/ee256749.aspx",
                "http://msdn.microsoft.com/en-us/library/hh290138.aspx",
                "http://msdn.microsoft.com/en-us/library/hh290140.aspx",
                "http://msdn.microsoft.com/en-us/library/dd470362.aspx",
                "http://msdn.microsoft.com/en-us/library/aa578028.aspx",
                "http://msdn.microsoft.com/en-us/library/ms404677.aspx",
                "http://msdn.microsoft.com/en-us/library/ff730837.aspx"
            }
        Return urls
    End Function


    '<snippet18>
    Private Async Function GetURLContentsAsync(url As String) As Task(Of Byte())
        '</snippet18>

        ' The downloaded resource ends up in the variable named content.
        Dim content = New MemoryStream()

        ' Initialize an HttpWebRequest for the current URL.
        Dim webReq = CType(WebRequest.Create(url), HttpWebRequest)

        ' Send the request to the Internet resource and wait for
        ' the response.
        '<snippet14>
        Using response As WebResponse = Await webReq.GetResponseAsync()
            '</snippet14>

            ' The previous statement abbreviates the following two statements.

            '<snippet12>
            'Dim responseTask As Task(Of WebResponse) = webReq.GetResponseAsync()
            'Using response As WebResponse = Await responseTask
            '</snippet12>

            ' Get the data stream that is associated with the specified URL.
            Using responseStream As Stream = response.GetResponseStream()
                ' Read the bytes in responseStream and copy them to content.  
                '<snippet15>
                Await responseStream.CopyToAsync(content)
                '</snippet15>

                ' The previous statement abbreviates the following two statements.

                '<snippet17>
                ' CopyToAsync returns a Task, not a Task<T>.
                'Dim copyTask As Task = responseStream.CopyToAsync(content)

                ' When copyTask is completed, content contains a copy of
                ' responseStream.
                'Await copyTask
                '</snippet17>
            End Using
        End Using

        ' Return the result as a byte array.
        Return content.ToArray()
    End Function


    Private Sub DisplayResults(url As String, content As Byte())

        ' Display the length of each website. The string format 
        ' is designed to be used with a monospaced font, such as
        ' Lucida Console or Global Monospace.
        Dim bytes = content.Length
        ' Strip off the "http://".
        Dim displayURL = url.Replace("http://", "")
        resultsTextBox.Text &= String.Format(vbCrLf & "{0,-58} {1,8}", displayURL, bytes)
    End Sub

End Class
'</snippet10>

